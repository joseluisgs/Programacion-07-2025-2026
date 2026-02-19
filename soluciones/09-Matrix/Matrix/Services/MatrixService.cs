using Matrix.Comparisons;
using Matrix.Configuration;
using Matrix.Data;
using Matrix.Models;

namespace Matrix.Services;

using static Console;

public class MatrixService(int dimension, int tiempoMax) {
    private readonly Queue<Generico> _almacen = new();
    private readonly SortedSet<Persona> _eliminados = new(new PersonaByDateComparer());
    private readonly List<Persona> _usados = [];
    private readonly List<Smith> _virus = [];

    private Matriz<Persona?> _matrix = null!;
    private Matriz<Persona?> _tempMatrix = null!;
    private int _totalPersonajes;


    public void Inicializar() {
        _matrix = new Matriz<Persona?>(dimension, dimension);
        _tempMatrix = new Matriz<Persona?>(dimension, dimension);

        InicializarAlmacen();
        InicializarNeo();
        InicializarSmith();
        RellenarConGenericos();
    }

    private void InicializarAlmacen() {
        for (var i = 0; i < Config.AlmacenInitSize; i++) {
            var generico = CrearGenerico();
            _almacen.Enqueue(generico);
            _totalPersonajes++;
        }
    }

    private void InicializarNeo() {
        int fila, columna;
        do {
            fila = Random.Shared.Next(dimension);
            columna = Random.Shared.Next(dimension);
        } while (_matrix[fila, columna] != null);

        var neo = new Neo {
            Localizacion = {
                Latitud = fila,
                Longitud = columna
            }
        };

        _matrix[fila, columna] = neo;
        _usados.Add(neo);
        _totalPersonajes++;
    }

    private void InicializarSmith() {
        int fila, columna;
        do {
            fila = Random.Shared.Next(dimension);
            columna = Random.Shared.Next(dimension);
        } while (_matrix[fila, columna] != null);

        var smith = CrearSmith();
        smith.Localizacion.Latitud = fila;
        smith.Localizacion.Longitud = columna;

        _matrix[fila, columna] = smith;
        _usados.Add(smith);
        _virus.Add(smith);
        _totalPersonajes++;
    }

    private void RellenarConGenericos() {
        for (var f = 0; f < dimension; f++) {
            for (var c = 0; c < dimension; c++)
                if (_matrix[f, c] == null)
                    if (_almacen.Dequeue() is { } generico) {
                        generico.Localizacion.Latitud = f;
                        generico.Localizacion.Longitud = c;
                        _matrix[f, c] = generico;
                        _usados.Add(generico);
                    }
        }
    }

    public void Ejecutar() {
        var tiempo = 0;
        var salir = false;

        do {
            if (!IsOutputRedirected) Clear();
            WriteLine();
            EscribirCabeceraAzul("═══════════════════════════════════════════════════");
            EscribirCabeceraAzul("                    THE MATRIX");
            EscribirCabeceraAzul("═══════════════════════════════════════════════════");
            WriteLine();
            WriteLine(_matrix.ToString());

            tiempo += 1000;
            var iteracion = tiempo / 1000;

            WriteLine($"\n  ⏱ Iteración: {iteracion}");

            _tempMatrix = _matrix.Clonar();

            if (tiempo % Config.IntervaloProcesarGenericos == 0) AccionGenericos();

            if (tiempo % Config.IntervaloProcesarSmiths == 0) AccionSmith();

            if (tiempo % Config.IntervaloProcesarNeo == 0) AccionNeo();

            if (tiempo % Config.IntervaloAgregarNuevos == 0) AccionNuevosGenericos();

            _matrix = _tempMatrix.Clonar();

            Thread.Sleep(1000);

            salir = tiempo >= tiempoMax || _almacen.Count == 0;
        } while (!salir);
    }

    private void AccionGenericos() {
        WriteLine("\n  ⚙ Evaluando personajes genéricos...");

        for (var f = 0; f < dimension; f++) {
            for (var c = 0; c < dimension; c++) {
                var personaje = _matrix[f, c];
                if (personaje is Generico generico) {
                    if (generico.DebeMorir) {
                        EscribirRojo($"  ✖ Muere: {generico.Nombre} (ID:{generico.Id}) en {generico.Localizacion}");

                        if (_almacen.Count > 0) {
                            if (_almacen.Dequeue() is { } nuevoGenerico) {
                                nuevoGenerico.Localizacion.Latitud = f;
                                nuevoGenerico.Localizacion.Longitud = c;
                                _tempMatrix[f, c] = nuevoGenerico;
                                _usados.Add(nuevoGenerico);
                                EscribirVerde(
                                    $"  ➕ Nuevo: {nuevoGenerico.Nombre} (ID:{nuevoGenerico.Id}) en {nuevoGenerico.Localizacion}");
                            }
                        }
                        else {
                            EscribirAmarillo("  ⚠ No hay personajes en el almacén");
                            _tempMatrix[f, c] = null;
                        }
                    }
                    else {
                        generico.ProbMorir -= 10;
                    }
                }
            }
        }
    }

    private void AccionSmith() {
        for (var f = 0; f < dimension; f++) {
            for (var c = 0; c < dimension; c++) {
                var personaje = _matrix[f, c];
                if (personaje is Smith smith) {
                    var intentos = smith.ProbInfectar;
                    EscribirMorado($"  ⚡ Smith: {smith.Nombre} | Intentos: {intentos} | Pos: {smith.Localizacion}");

                    for (var i = -1; i <= 1; i++) {
                        for (var j = -1; j <= 1; j++) {
                            if (intentos <= 0) break;

                            var nuevaFila = f + i;
                            var nuevaCol = c + j;

                            if (nuevaFila >= 0 && nuevaFila < dimension &&
                                nuevaCol >= 0 && nuevaCol < dimension)
                                if (_matrix[nuevaFila, nuevaCol] is Generico) {
                                    intentos--;
                                    var nuevoSmith = CrearSmith();
                                    nuevoSmith.Localizacion.Latitud = nuevaFila;
                                    nuevoSmith.Localizacion.Longitud = nuevaCol;

                                    _tempMatrix[nuevaFila, nuevaCol] = nuevoSmith;
                                    _usados.Add(nuevoSmith);
                                    _virus.Add(nuevoSmith);
                                    _totalPersonajes++;

                                    EscribirRojo(
                                        $"    ⚡ INFECTA [{nuevaFila + 1},{nuevaCol + 1}] - Quedan: {intentos} intentos");
                                }
                        }
                    }
                }
            }
        }
    }

    private void AccionNeo() {
        for (var f = 0; f < dimension; f++) {
            for (var c = 0; c < dimension; c++) {
                var personaje = _matrix[f, c];
                if (personaje is Neo neo) {
                    neo.ActualizarElegido();

                    EscribirAmarillo($"\n  ♔ Neo aparece en: {neo.Localizacion}");

                    if (neo.EsElegido) {
                        EscribirAmarillo("  ★ Neo es el ELEGIDO! Elimina agentes Smith cercanos...");
                        var eliminados = 0;

                        for (var i = -1; i <= 1; i++) {
                            for (var j = -1; j <= 1; j++) {
                                var nuevaFila = f + i;
                                var nuevaCol = c + j;

                                if (nuevaFila >= 0 && nuevaFila < dimension &&
                                    nuevaCol >= 0 && nuevaCol < dimension)
                                    if (_tempMatrix[nuevaFila, nuevaCol] is Smith smith) {
                                        EscribirRojo(
                                            $"    ⚔ ELIMINA: {smith.Nombre} en [{nuevaFila + 1},{nuevaCol + 1}]");
                                        _eliminados.Add(smith);
                                        _tempMatrix[nuevaFila, nuevaCol] = null;
                                        eliminados++;
                                    }
                            }
                        }

                        if (eliminados == 0) EscribirAmarillo("    No había agentes Smith cerca");
                    }
                    else {
                        EscribirGris("  ☺ Neo decide no actuar esta vez");
                    }

                    WriteLine("  ⇔ Neo cambia de posición...");
                    int nuevaFilaNeo, nuevaColNeo;
                    do {
                        nuevaFilaNeo = Random.Shared.Next(dimension);
                        nuevaColNeo = Random.Shared.Next(dimension);
                    } while (_matrix[nuevaFilaNeo, nuevaColNeo] != null &&
                             _matrix[nuevaFilaNeo, nuevaColNeo] is not Persona);

                    WriteLine($"    Se mueve a: [{nuevaFilaNeo + 1},{nuevaColNeo + 1}]");

                    _tempMatrix[f, c] = null;

                    if (_matrix[nuevaFilaNeo, nuevaColNeo] is Smith smithTarget) {
                        EscribirRojo($"    ⚔ Elimina a Smith: {smithTarget.Nombre}");
                        _eliminados.Add(smithTarget);
                        _tempMatrix[nuevaFilaNeo, nuevaColNeo] = null;
                    }
                    else if (_matrix[nuevaFilaNeo, nuevaColNeo] is Generico genericoTarget) {
                        EscribirVerde($"    ⇄ Intercambia con: {genericoTarget.Nombre}");
                        _tempMatrix[f, c] = genericoTarget;
                        genericoTarget.Localizacion.Latitud = f;
                        genericoTarget.Localizacion.Longitud = c;
                    }

                    neo.Localizacion.Latitud = nuevaFilaNeo;
                    neo.Localizacion.Longitud = nuevaColNeo;
                    _tempMatrix[nuevaFilaNeo, nuevaColNeo] = neo;
                }
            }
        }
    }

    private void AccionNuevosGenericos() {
        var huecos = ContarHuecos();
        WriteLine($"\n  ⚡ Espacios libres: {huecos} | En almacén: {_almacen.Count}");

        var max = Math.Min(_almacen.Count, Math.Min(huecos, Config.MaxNuevosGenericos));

        for (var i = 0; i < max; i++) {
            var personaje = _almacen.Dequeue();
            if (personaje == null) break;

            _usados.Add(personaje);

            int fila, columna;
            var asignado = false;
            do {
                fila = Random.Shared.Next(dimension);
                columna = Random.Shared.Next(dimension);

                if (_tempMatrix[fila, columna] == null) {
                    personaje.Localizacion.Latitud = fila;
                    personaje.Localizacion.Longitud = columna;
                    _tempMatrix[fila, columna] = personaje;
                    asignado = true;
                    EscribirVerde($"  ➕ Nuevo personaje: {personaje.Nombre} en [{fila + 1},{columna + 1}]");
                }
            } while (!asignado);
        }
    }

    private int ContarHuecos() {
        var huecos = 0;
        for (var f = 0; f < dimension; f++) {
            for (var c = 0; c < dimension; c++)
                if (_matrix[f, c] == null)
                    huecos++;
        }

        return huecos;
    }

    private Generico CrearGenerico() {
        var nombre = Config.NombresGenericos[Random.Shared.Next(Config.NombresGenericos.Length)];
        var ciudad = Config.Ciudades[Random.Shared.Next(Config.Ciudades.Length)];
        var localizacion = new Localizacion(0, 0, ciudad);
        return new Generico(nombre, localizacion);
    }

    private Smith CrearSmith() {
        var nombre = $"Smith-{_usados.Count + 1}";
        var ciudad = Config.Ciudades[Random.Shared.Next(Config.Ciudades.Length)];
        var localizacion = new Localizacion(0, 0, ciudad);
        var probInfectar = Random.Shared.Next(1, 11);
        return new Smith(nombre, localizacion, probInfectar);
    }

    public void MostrarInforme() {
        WriteLine();
        EscribirCabeceraAzul("═══════════════════════════════════════════════════");
        EscribirCabeceraAzul("              INFORME FINAL");
        EscribirCabeceraAzul("═══════════════════════════════════════════════════");

        WriteLine("\nEstado final de The Matrix:");
        WriteLine(_matrix.ToString());

        WriteLine();
        EscribirCabeceraVerde("ESTADÍSTICAS");
        WriteLine($"\n  ⚙ Total personajes: {_totalPersonajes}");
        WriteLine($"  ☺ Personajes usados: {_usados.Count}");
        WriteLine($"  ☑ En almacén: {_almacen.Count}");
        WriteLine($"  ⚡ Smith generados: {_virus.Count}");
        WriteLine($"  ⚔ Smith eliminados: {_eliminados.Count}");

        foreach (var persona in _usados)
            if (persona is Neo neo) {
                EscribirAmarillo($"\n  ♔ Neo está en: {neo.Localizacion}");
                break;
            }

        WriteLine();
        EscribirCabeceraVerde("PERSONAJES USADOS (ordenados por ID)");
        var ordenados = new List<Persona>(_usados);
        ordenados.Sort((a, b) => a.Id.CompareTo(b.Id));

        foreach (var persona in ordenados.Take(20))
            WriteLine($"  ID:{persona.Id,3} | {persona.Nombre,-12} | {persona.MarcaTiempo}");

        WriteLine();
        EscribirCabeceraMorado("AGENTES SMITH (más recientes)");
        var smithsOrdenados = new List<Smith>(_virus);
        smithsOrdenados.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));

        foreach (var smith in smithsOrdenados.Take(15))
            WriteLine(
                $"  ID:{smith.Id,3} | {smith.Nombre,-10} | Prob:{smith.ProbInfectar} | {smith.MarcaTiempo}");

        WriteLine();
        EscribirRojo("SMITH ELIMINADOS POR NEO:");
        if (_eliminados.Count == 0)
            EscribirGris("  No se ha eliminado ningun agente Smith");
        else
            foreach (var eliminado in _eliminados)
                WriteLine($"  ID:{eliminado.Id,3} | {eliminado.Nombre,-10} | {eliminado.MarcaTiempo}");

        WriteLine();
        EscribirCabeceraAzul("================================================");
    }

    private static void EscribirCabeceraAzul(string texto) {
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirCabeceraVerde(string texto) {
        ForegroundColor = ConsoleColor.Green;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirCabeceraMorado(string texto) {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirRojo(string texto) {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirVerde(string texto) {
        ForegroundColor = ConsoleColor.Green;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirAmarillo(string texto) {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirMorado(string texto) {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine(texto);
        ResetColor();
    }

    private static void EscribirGris(string texto) {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine(texto);
        ResetColor();
    }
}