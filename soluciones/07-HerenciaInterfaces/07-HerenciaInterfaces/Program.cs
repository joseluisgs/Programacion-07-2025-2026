using System.Linq;
using static System.Console;
using _07_HerenciaInterfaces.Models;

// Lista principal con todas las personas del equipo
var personas = new List<Persona>
{
    // Jugadores de campo
    new Jugador(1, "Lionel", "Messi", 36, "Argentina", "Delantero", 800, 400, true),
    new Jugador(2, "Cristiano", "Ronaldo", 39, "Portugal", "Delantero", 850, 300, true),
    new Jugador(3, "Andrés", "Iniesta", 40, "España", "Centrocampista", 200, 350),
    new Jugador(4, "Gerard", "Piqué", 37, "España", "Defensa", 50, 80),
    new Jugador(5, "Xavi", "Hernández", 44, "España", "Centrocampista", 150, 400),
    new Jugador(6, "Iker", "Casillas", 42, "España", "Portero", 0, 0, true),
    new Jugador(7, "Sergio", "Ramos", 38, "España", "Defensa", 100, 60),
    new Jugador(8, "Vinícius", "Jr", 24, "Brasil", "Delantero", 120, 80),
    new Jugador(9, "Kylian", "Mbappé", 25, "Francia", "Delantero", 300, 200),
    new Jugador(10, "Luka", "Modric", 39, "Croacia", "Centrocampista", 150, 250),
    
    // Porteros (heredan de Jugador e implementan IPortero)
    new Portero(11, "Thibaut", "Courtois", 32, "Bélgica", 150, 75.5, 200, 5),
    new Portero(12, "Keylor", "Navas", 38, "Costa Rica", 300, 80.0, 350, 12),
    
    // Entrenadores (implementan IEntrenar e ICapitan)
    new Entrenador(13, "Pep", "Guardiola", 53, "España", "Fútbol", 20, "Manchester City", 35),
    new Entrenador(14, "Carlo", "Ancelotti", 65, "Italia", "Fútbol", 30, "Real Madrid", 28),
    new Entrenador(15, "Luis", "Enrique", 54, "España", "Fútbol", 15, "Selección España", 10),
    
    // Masajistas
    new Masajista(16, "Juan Carlos", "Navarro", 50, "España", "Fisioterapeuta", 25, new() { "Lesiones musculares", "Recuperación" }),
    new Masajista(17, "Antonio", "García", 45, "España", "Masajista deportivo", 20, new() { "Masajes", "Estiramientos" })
};

// ============================================================
// CONSULTAS DE HERENCIA E INTERFACES (OFTYPE)
// ============================================================

// Obtener todos los jugadores (incluye porteros ya que heredan de Jugador)
// SQL: SELECT * FROM Persona WHERE Tipo = 'Jugador'
WriteLine("*** Lista de Jugadores (OfType) ***");
var listaJugadores = personas.OfType<Jugador>().ToList();
listaJugadores.ForEach(WriteLine);

// Obtener solo los porteros (filtramos por tipo Portero)
// SQL: SELECT * FROM Persona WHERE Tipo = 'Portero'
WriteLine("\n*** Lista de Porteros (OfType) ***");
var listaPorteros = personas.OfType<Portero>().ToList();
listaPorteros.ForEach(WriteLine);

// Obtener los entrenadores
// SQL: SELECT * FROM Persona WHERE Tipo = 'Entrenador'
WriteLine("\n*** Lista de Entrenadores (OfType) ***");
var listaEntrenadores = personas.OfType<Entrenador>().ToList();
listaEntrenadores.ForEach(WriteLine);

// Obtener los masajistas
// SQL: SELECT * FROM Persona WHERE Tipo = 'Masajista'
WriteLine("\n*** Lista de Masajistas (OfType) ***");
var listaMasajistas = personas.OfType<Masajista>().ToList();
listaMasajistas.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE FILTRADO CON WHERE + IS (PATTERN MATCHING)
// ============================================================

// Obtener las personas mayores de 35 años
// SQL: SELECT * FROM Persona WHERE Edad > 35
WriteLine("\n*** Personas mayores de 35 años ***");
var personasMayores35 = personas
    .Where(p => p is { Edad: > 35 })
    .ToList();

personasMayores35.ForEach(WriteLine);

// Obtener los jugadores que son capitanes
// SQL: SELECT * FROM Jugador WHERE EsCapitan = 1
WriteLine("\n*** Jugadores que son capitanes ***");
var jugadoresCapitanes = personas
    .Where(p => p is Jugador j && j.EsCapitan)
    .Select(p => (Jugador)p)
    .ToList();

jugadoresCapitanes.ForEach(WriteLine);

// Obtener las personas que implementan IPortero
// SQL: SELECT * FROM Persona WHERE implements IPortero
WriteLine("\n*** Personas que implementan IPortero ***");
var personasInterfazPortero = personas
    .OfType<IPortero>()
    .ToList();

personasInterfazPortero.ForEach(p => WriteLine($"  - Paradas: {p.Paradas}, Porcentaje: {p.PorcentajeParadas}%"));

// Obtener las personas que implementan IEntrenar
// SQL: SELECT * FROM Persona WHERE implements IEntrenar
WriteLine("\n*** Personas que implementan IEntrenar ***");
var personasInterfazEntrenar = personas
    .OfType<IEntrenar>()
    .ToList();

personasInterfazEntrenar.ForEach(e => WriteLine($"  - Especialidad: {e.Especialidad}, Años: {e.AñosExperiencia}"));

// Obtener las personas que implementan ICapitan
// SQL: SELECT * FROM Persona WHERE implements ICapitan
WriteLine("\n*** Personas que implementan ICapitan ***");
var personasInterfazCapitan = personas
    .OfType<ICapitan>()
    .ToList();

personasInterfazCapitan.ForEach(c => WriteLine("  - Captain interface"));

// ============================================================
// CONSULTAS DE PROYECCIÓN CON SELECT
// ============================================================

// Obtener nombre completo y posición de todos los jugadores
// SQL: SELECT Nombre, Apellidos, Posicion FROM Jugador
WriteLine("\n*** Proyección: Nombre completo y posición ***");
var proyeccionNombrePosicion = personas
    .OfType<Jugador>()
    .Select(j => new { NombreCompleto = $"{j.Nombre} {j.Apellidos}", j.Posicion })
    .ToList();

proyeccionNombrePosicion.ForEach(n => WriteLine($"  - {n.NombreCompleto}: {n.Posicion}"));

// Obtener estadísticas de los porteros
// SQL: SELECT Paradas, PorcentajeParadas FROM Portero
WriteLine("\n*** Proyección: Estadísticas de porteros ***");
var estadisticasPorteros = personas
    .OfType<Portero>()
    .Select(p => new { p.Paradas, p.PorcentajeParadas, p.GolesRecibidos })
    .ToList();

estadisticasPorteros.ForEach(p => WriteLine($"  - Paradas: {p.Paradas}, Porcentaje: {p.PorcentajeParadas}%, Goles Recibidos: {p.GolesRecibidos}"));

// Proyección con propiedades calculadas
// SQL: SELECT Nombre, Goles, Goles * 1000 as Puntos FROM Jugador
WriteLine("\n*** Proyección: Goles en puntos (x1000) ***");
var puntosJugadores = personas
    .OfType<Jugador>()
    .Select(j => new { j.Nombre, j.Goles, Puntos = j.Goles * 1000 })
    .ToList();

puntosJugadores.ForEach(p => WriteLine($"  - {p.Nombre}: {p.Goles} goles = {p.Puntos} puntos"));

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar personas por tipo y contar
// SQL: SELECT Tipo, COUNT(*) FROM Persona GROUP BY Tipo
WriteLine("\n*** Personas agrupadas por tipo ***");
var personasPorTipo = personas
    .GroupBy(p => p.GetType().Name)
    .ToList();

personasPorTipo.ForEach(g => 
{
    WriteLine($"\n  Tipo: {g.Key}");
    g.ToList().ForEach(p => WriteLine($"    - {p.Nombre} {p.Apellidos}"));
});

// Agrupar jugadores por posición
// SQL: SELECT Posicion, SUM(Goles) FROM Jugador GROUP BY Posicion
WriteLine("\n*** Goles totales por posición ***");
var golesPorPosicion = personas
    .OfType<Jugador>()
    .GroupBy(j => j.Posicion)
    .ToDictionary(g => g.Key, g => new { TotalGoles = g.Sum(j => j.Goles), Cantidad = g.Count() });

golesPorPosicion.ToList().ForEach(kv => WriteLine($"  - {kv.Key}: {kv.Value.TotalGoles} goles en {kv.Value.Cantidad} jugadores"));

// Obtener el mejor goles de cada posición
// SQL: SELECT * FROM Jugador WHERE Goles = (SELECT MAX(Goles) FROM Jugador WHERE Posicion = ...)
WriteLine("\n*** Mejor goleador por posición ***");
var mejoresGoleadores = personas
    .OfType<Jugador>()
    .GroupBy(j => j.Posicion)
    .Select(g => g.MaxBy(j => j.Goles))
    .ToList();

mejoresGoleadores.ForEach(j => WriteLine($"  - {j.Posicion}: {j.Nombre} {j.Apellidos} ({j.Goles} goles)"));

// ============================================================
// CONSULTAS DE ESTADÍSTICAS Y AGREGACIÓN
// ============================================================

// Obtener estadísticas de los porteros
// SQL: SELECT SUM(Paradas), AVG(PorcentajeParadas), MAX(GolesRecibidos) FROM Portero
WriteLine("\n*** Estadísticas de porteros ***");
var totalParadas = personas.OfType<Portero>().Sum(p => p.Paradas);
var mediaPorcentaje = personas.OfType<Portero>().Average(p => p.PorcentajeParadas);
var maxGolesRecibidos = personas.OfType<Portero>().Max(p => p.GolesRecibidos);
var numPorteros = personas.OfType<Portero>().Count();

WriteLine($"  Total paradas: {totalParadas}");
WriteLine($"  Porcentaje medio: {mediaPorcentaje:F2}%");
WriteLine($"  Máx goles recibidos: {maxGolesRecibidos}");
WriteLine($"  Número de porteros: {numPorteros}");

// Obtener el jugador con más goles
// SQL: SELECT TOP 1 * FROM Jugador ORDER BY Goles DESC
WriteLine("\n*** Jugador con más goles ***");
var mejorGoleador = personas
    .OfType<Jugador>()
    .OrderByDescending(j => j.Goles)
    .First();

WriteLine(mejorGoleador);

// Obtener el jugador más mayor
// SQL: SELECT TOP 1 * FROM Jugador ORDER BY Edad DESC
WriteLine("\n*** Jugador más mayor ***");
var jugadorMasMayor = personas
    .OfType<Jugador>()
    .OrderByDescending(j => j.Edad)
    .First();

WriteLine(jugadorMasMayor);

// ============================================================
// CONSULTAS DE ORDENACIÓN (ORDER BY)
// ============================================================

// Obtener los jugadores ordenados por goles
// SQL: SELECT * FROM Jugador ORDER BY Goles DESC
WriteLine("\n*** Jugadores ordenados por goles (descendente) ***");
var jugadoresOrdenados = personas
    .OfType<Jugador>()
    .OrderByDescending(j => j.Goles)
    .ToList();

jugadoresOrdenados.ForEach(WriteLine);

// Obtener los porteros ordenados por porcentaje de paradas
// SQL: SELECT * FROM Portero ORDER BY PorcentajeParadas DESC
WriteLine("\n*** Porteros ordenados por porcentaje de paradas ***");
var porterosOrdenados = personas
    .OfType<Portero>()
    .OrderByDescending(p => p.PorcentajeParadas)
    .ToList();

porterosOrdenados.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Obtener los 3 primeros jugadores por goles
// SQL: SELECT TOP 3 * FROM Jugador ORDER BY Goles DESC
WriteLine("\n*** Top 3 jugadores por goles ***");
var top3Jugadores = personas
    .OfType<Jugador>()
    .OrderByDescending(j => j.Goles)
    .Take(3)
    .ToList();

top3Jugadores.ForEach(WriteLine);

// Obtener los siguientes 3 jugadores (página 2)
// SQL: SELECT * FROM Jugador ORDER BY Goles DESC OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Siguientes 3 jugadores (página 2) ***");
var pagina2 = personas
    .OfType<Jugador>()
    .OrderByDescending(j => j.Goles)
    .Skip(3)
    .Take(3)
    .ToList();

pagina2.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE VERIFICACIÓN (ANY, ALL, CONTAINS)
// ============================================================

// Verificar si hay algún jugador español
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Jugador WHERE Nacionalidad = 'España') THEN 1 ELSE 0 END
WriteLine("\n*** ¿Hay algún jugador español? ***");
var hayJugadorEspañol = personas
    .OfType<Jugador>()
    .Any(j => j.Nacionalidad == "España");

WriteLine(hayJugadorEspañol ? "  Sí, hay jugadores españoles" : "  No hay jugadores españoles");

// Verificar si todos los delanteros tienen goles
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Jugador WHERE Posicion = 'Delantero' AND Goles > 0) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los delanteros tienen goles? ***");
var todosDelanteroGoles = personas
    .OfType<Jugador>()
    .Where(j => j.Posicion == "Delantero")
    .All(j => j.Goles > 0);

WriteLine(todosDelanteroGoles ? "  Sí, todos los delanteros tienen goles" : "  No todos los delanteros tienen goles");

// Verificar si hay algún portero con más de 100 paradas
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Portero WHERE Paradas > 100) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Hay algún portero con más de 100 paradas? ***");
var hayPortero100Paradas = personas
    .OfType<Portero>()
    .Any(p => p.Paradas > 100);

WriteLine(hayPortero100Paradas ? "  Sí, hay porteros con más de 100 paradas" : "  No hay porteros con más de 100 paradas");

// ============================================================
// CONSULTAS DE SUBCONSULTAS
// ============================================================

// Obtener los jugadores con más goles que la media
// SQL: SELECT * FROM Jugador WHERE Goles > (SELECT AVG(Goles) FROM Jugador)
WriteLine("\n*** Jugadores con más goles que la media ***");
var mediaGoles = personas.OfType<Jugador>().Average(j => j.Goles);
var jugadoresSobreMedia = personas
    .OfType<Jugador>()
    .Where(j => j.Goles > mediaGoles)
    .ToList();

WriteLine($"  Media de goles: {mediaGoles:F2}");
jugadoresSobreMedia.ForEach(j => WriteLine($"  - {j.Nombre} {j.Apellidos}: {j.Goles} goles"));

// Obtener la posición con más goles en total
// SQL: SELECT Posicion FROM Jugador GROUP BY Posicion ORDER BY SUM(Goles) DESC
WriteLine("\n*** Posición con más goles ***");
var posicionTopGoles = personas
    .OfType<Jugador>()
    .GroupBy(j => j.Posicion)
    .OrderByDescending(g => g.Sum(j => j.Goles))
    .First();

WriteLine($"  - {posicionTopGoles.Key}: {posicionTopGoles.Sum(j => j.Goles)} goles");

// ============================================================
// CONSULTAS DE CONJUNTOS (UNION, INTERSECT, EXCEPT)
// ============================================================

// Obtener posiciones únicas de los jugadores
// SQL: SELECT DISTINCT Posicion FROM Jugador
WriteLine("\n*** Posiciones únicas de jugadores ***");
var posicionesUnicas = personas
    .OfType<Jugador>()
    .Select(j => j.Posicion)
    .Distinct()
    .ToList();

posicionesUnicas.ForEach(WriteLine);

// Obtener la unión de jugadores y porteros
// SQL: SELECT * FROM Jugador UNION SELECT * FROM Portero
WriteLine("\n*** Unión de jugadores y porteros (cuenta) ***");
var unionJugadoresPorteros = personas
    .OfType<Jugador>()
    .Cast<Persona>()
    .Union(personas.OfType<Portero>().Cast<Persona>())
    .Count();

WriteLine($"  Total: {unionJugadoresPorteros} personas");

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE
// ============================================================

// Obtener delanteros con más de 100 goles ordenados por edad
// SQL: SELECT * FROM Jugador WHERE Posicion = 'Delantero' AND Goles > 100 ORDER BY Edad DESC
WriteLine("\n*** Delanteros con más de 100 goles ordenados por edad ***");
var delantGoles = personas
    .OfType<Jugador>()
    .Where(j => j.Posicion == "Delantero" && j.Goles > 100)
    .OrderByDescending(j => j.Edad)
    .ToList();

delantGoles.ForEach(WriteLine);

// Obtener porteros con porcentaje de paradas mayor al 75%
// SQL: SELECT * FROM Portero WHERE PorcentajeParadas > 75
WriteLine("\n*** Porteros con más de 75% de paradas ***");
var porterosPorcentaje = personas
    .OfType<Portero>()
    .Where(p => p.PorcentajeParadas > 75)
    .ToList();

porterosPorcentaje.ForEach(WriteLine);

// ============================================================
// EXPLICACIÓN: OFTYPE VS CAST
// ============================================================

/*
OfType<T> - Filtra solo los elementos que SON de tipo T
  .OfType<Portero>() → solo porteros, ignora los demás tipos

Cast<T> - Intenta convertir todos los elementos a T
  .Cast<Portero>() → lanza excepción si no es portero

OfType es más seguro porque no lanza excepciones.
*/

// Ejemplo de diferencia entre OfType y Cast
WriteLine("\n*** Ejemplo: OfType vs Cast ***");
var porterosOfType = personas.OfType<Portero>().ToList();
WriteLine($"  OfType<Portero>: {porterosOfType.Count} porteros");

// ============================================================
// EXPLICACIÓN: CONSULTAS CON HERENCIA
// ============================================================

/*
Herencia en LINQ:
- OfType<ClaseDerivada> filtra por tipo derivado
- OfType<Interfaz> filtra por quienes implementan la interfaz
- Se puede usar Where con 'is' para pattern matching
- Select puede proyectar a tipos anónimos o interfaces
*/

WriteLine("\n*** FIN ***");
