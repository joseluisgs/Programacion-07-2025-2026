using System.Linq;
using static System.Console;
using Canciones.Models;

var canciones = new List<Cancion>
{
    new("Livin' on Prayer", "Bon Jovi", 250),
    new("Long Hot Summer", "Keith Urban", 245),
    new("It's my Life", "Bon Jovi", 245),
    new("Dolor Fantasma", "Amadeus", 210),
    new("Run To You", "Bryan Adams", 300),
    new("Summer of 69", "Bryan Adams", 240),
    new("Paranoid", "Black Sabbath", 180),
    new("Cherokee", "Europe", 300),
    new("River Bank", "Brad Paisley", 220)
};

// ============================================================
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

// Obtener todas las canciones
// SQL: SELECT * FROM Canciones
WriteLine("*** Lista de Canciones ***");
canciones.ForEach(WriteLine);

// Filtrar canciones por cantante de forma tradicional
// SQL: SELECT * FROM Canciones WHERE Cantante = 'Bon Jovi'
WriteLine("\n*** Filtrar canciones por cantante (forma tradicional) ***");
var listaFiltrada = new List<Cancion>();
canciones.Where(c => c.Cantante == "Bon Jovi")
    .ToList()
    .ForEach(c => listaFiltrada.Add(c));

listaFiltrada.ForEach(c => WriteLine($"Tradicional: {c}"));

// Filtrar canciones por cantante usando LINQ
// SQL: SELECT * FROM Canciones WHERE Cantante = 'Bon Jovi'
WriteLine("\n*** Filtrar canciones por cantante (con LINQ) ***");
var listadoCanciones = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .ToList();

listadoCanciones.ForEach(WriteLine);

// Transformar el cantante a mayúsculas
// SQL: SELECT UPPER(Cantante), Titulo FROM Canciones WHERE Cantante = 'Bon Jovi'
WriteLine("\n*** Transformar elementos: cantante en mayúsculas ***");
var listadoCancionesMayuscula = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .Select(c => new Cancion(c.Titulo, c.Cantante.ToUpper(), c.Duracion))
    .ToList();

listadoCancionesMayuscula.ForEach(WriteLine);

// Obtener solo los títulos de las canciones de un cantante
// SQL: SELECT Titulo FROM Canciones WHERE Cantante = 'Bon Jovi'
WriteLine("\n*** Obtener solo títulos de canciones por cantante ***");
var listadoTitulos = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .Select(c => c.Titulo)
    .ToList();

listadoTitulos.ForEach(WriteLine);

// Eliminar canciones duplicadas
// SQL: SELECT DISTINCT * FROM Canciones
WriteLine("\n*** Eliminar duplicados ***");
var sinDuplicados = canciones.Distinct().ToList();

sinDuplicados.ForEach(WriteLine);

// Contar las canciones de un cantante
// SQL: SELECT COUNT(*) FROM Canciones WHERE Cantante = 'Bon Jovi'
WriteLine("\n*** Contar canciones de un cantante ***");
var count = canciones
    .Count(c => c.Cantante == "Bon Jovi");

WriteLine($"Bon Jovi aparece: {count} veces");

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar canciones por cantante y contar
// SQL: SELECT Cantante, COUNT(*) as Cantidad FROM Canciones GROUP BY Cantante
WriteLine("\n*** Agrupar canciones por cantante ***");
var agrupadas = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(g => g.Key, g => g.Count());

agrupadas.ToList().ForEach(g => WriteLine($"Cantante: {g.Key}, Cantidad: {g.Value}"));

// Obtener las canciones de un cantante específico
// SQL: SELECT * FROM Canciones WHERE Cantante = 'Bryan Adams'
WriteLine("\n*** Canciones de Bryan Adams ***");
var cancionesBryanAdams = canciones
    .Where(c => c.Cantante == "Bryan Adams")
    .ToList();

cancionesBryanAdams.ForEach(WriteLine);

// Obtener el cantante con más canciones
// SQL: SELECT TOP 1 Cantante, COUNT(*) as Cantidad FROM Canciones GROUP BY Cantante ORDER BY Cantidad DESC
WriteLine("\n*** Cantante con más canciones ***");
var cantanteMasCanciones = canciones
    .GroupBy(c => c.Cantante)
    .OrderByDescending(g => g.Count())
    .First();

WriteLine($"{cantanteMasCanciones.Key}: {cantanteMasCanciones.Count()} canciones");

// Agrupar por cantante y mostrar todas sus canciones
// SQL: SELECT * FROM Canciones
WriteLine("\n*** Canciones agrupadas por cantante ***");
var cancionesPorCantante = canciones
    .GroupBy(c => c.Cantante)
    .ToList();

cancionesPorCantante.ForEach(g =>
{
    WriteLine($"\n{g.Key}:");
    g.ToList().ForEach(c => WriteLine($"  - {c.Titulo}"));
});

// Agrupar por cantante y obtener la primera canción alfabéticamente
// SQL: SELECT Cantante, MIN(Titulo) FROM Canciones GROUP BY Cantante
WriteLine("\n*** Primera canción alfabéticamente por cantante ***");
var primeraPorCantante = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(g => g.Key, g => g.MinBy(c => c.Titulo).Titulo);

primeraPorCantante.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value}"));

// Agrupar por cantante: estadísticas (total, primera, última)
// SQL: SELECT Cantante, COUNT(*), MIN(Titulo), MAX(Titulo) FROM Canciones GROUP BY Cantante
WriteLine("\n*** Estadísticas por cantante ***");
var estadisticasCantante = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Cantidad = g.Count(),
            Primera = g.MinBy(c => c.Titulo).Titulo,
            Ultima = g.MaxBy(c => c.Titulo).Titulo
        }
    );

estadisticasCantante.ToList().ForEach(kv => 
    WriteLine($"{kv.Key}: {kv.Value.Cantidad} canciones, Primera={kv.Value.Primera}, Ultima={kv.Value.Ultima}"));

// Obtener la canción que dura más
// SQL: SELECT TOP 1 * FROM Canciones ORDER BY Duracion DESC
WriteLine("\n*** La canción que dura más ***");
var cancionMasLarga = canciones
    .OrderByDescending(c => c.Duracion)
    .First();

WriteLine(cancionMasLarga);

// Obtener la duración media de las canciones
// SQL: SELECT AVG(Duracion) FROM Canciones
WriteLine("\n*** Duración media de las canciones ***");
var duracionMedia = canciones.Average(c => c.Duracion);

WriteLine($"Duración media: {duracionMedia / 60.0:F2} minutos ({(int)duracionMedia / 60}:{duracionMedia % 60:D2} segundos)");

// Obtener la canción más larga de cada grupo
// SQL: SELECT * FROM Canciones c1 WHERE Duracion = (SELECT MAX(Duracion) FROM Canciones c2 WHERE c1.Cantante = c2.Cantante)
WriteLine("\n*** Canción más larga de cada grupo ***");
var cancionMasLargaPorGrupo = canciones
    .GroupBy(c => c.Cantante)
    .Select(g => g.MaxBy(c => c.Duracion))
    .ToList();

cancionMasLargaPorGrupo.ForEach(WriteLine);

// Obtener el número de canciones mayores de 2 minutos (120 segundos)
// SQL: SELECT COUNT(*) FROM Canciones WHERE Duracion > 120
WriteLine("\n*** Número de canciones mayores de 2 minutos ***");
var cancionesMasDe2Min = canciones
    .Count(c => c.Duracion > 120);

WriteLine($"Canciones mayores de 2 minutos: {cancionesMasDe2Min}");

// Agrupar por cantante: estadísticas completas con duración
// SQL: SELECT Cantante, MAX(Duracion), MIN(Duracion), AVG(Duracion), COUNT(*), 
//      SUM(CASE WHEN Duracion > 120 THEN 1 ELSE 0 END) FROM Canciones GROUP BY Cantante
WriteLine("\n*** Estadísticas completas por cantante (con duración) ***");
var estadisticasCompletas = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Cantidad = g.Count(),
            DuracionMax = g.Max(c => c.Duracion),
            DuracionMin = g.Min(c => c.Duracion),
            DuracionMedia = g.Average(c => c.Duracion),
            CancionesMas2Min = g.Count(c => c.Duracion > 120),
            CancionMasLarga = g.MaxBy(c => c.Duracion).Titulo
        }
    );

estadisticasCompletas.ToList().ForEach(kv => 
    WriteLine($"{kv.Key}: Cantidad={kv.Value.Cantidad}, Más larga={kv.Value.CancionMasLarga} ({kv.Value.DuracionMax}s), " +
              $"Más corta={kv.Value.DuracionMin}s, Media={kv.Value.DuracionMedia:F1}s, Mayors 2min={kv.Value.CancionesMas2Min}"));

// Obtener cantantes con más de 1 canción (HAVING)
// SQL: SELECT Cantante, COUNT(*) as Cantidad FROM Canciones GROUP BY Cantante HAVING COUNT(*) > 1
WriteLine("\n*** Cantantes con más de 1 canción (HAVING) ***");
var cantantesConMasDe1 = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(g => g.Key, g => g.Count())
    .Where(kv => kv.Value > 1)
    .ToList();

cantantesConMasDe1.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} canciones"));

// Obtener cantantes con duración media mayor a 240 segundos (HAVING)
// SQL: SELECT Cantante, AVG(Duracion) as Media FROM Canciones GROUP BY Cantante HAVING AVG(Duracion) > 240
WriteLine("\n*** Cantantes con duración media mayor a 240 segundos (HAVING) ***");
var cantantesDuracionLarga = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(g => g.Key, g => g.Average(c => c.Duracion))
    .Where(kv => kv.Value > 240)
    .ToList();

cantantesDuracionLarga.ForEach(kv => WriteLine($"{kv.Key}: Media = {kv.Value:F1} segundos"));

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar las primeras 3 canciones
// SQL: SELECT TOP 3 * FROM Canciones
WriteLine("\n*** Primeras 3 canciones ***");
var primeras3 = canciones.Take(3).ToList();

primeras3.ForEach(WriteLine);

// Paginación: mostrar las siguientes 3 canciones
// SQL: SELECT * FROM Canciones OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Siguientes 3 canciones ***");
var siguientes3 = canciones.Skip(3).Take(3).ToList();

siguientes3.ForEach(WriteLine);

// Paginación: últimas 3 canciones
// SQL: SELECT * FROM Canciones OFFSET 6 ROWS
WriteLine("\n*** Últimas 3 canciones ***");
var ultimas3 = canciones.Skip(6).Take(3).ToList();

ultimas3.ForEach(WriteLine);

// Verificar si existe alguna canción de un cantante específico
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Canciones WHERE Cantante = 'Queen') THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe alguna canción de Queen? ***");
var hayQueen = canciones.Any(c => c.Cantante == "Queen");

WriteLine(hayQueen ? "Sí, hay canciones de Queen" : "No hay canciones de Queen");

// Verificar si todas las canciones duran más de 1 minuto
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Canciones WHERE Duracion > 60) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todas las canciones duran más de 1 minuto? ***");
var todasMas1Min = canciones.All(c => c.Duracion > 60);

WriteLine(todasMas1Min ? "Sí, todas duran más de 1 minuto" : "No todas duran más de 1 minuto");

// Obtener la canción más corta
// SQL: SELECT TOP 1 * FROM Canciones ORDER BY Duracion ASC
WriteLine("\n*** La canción más corta ***");
var cancionMasCorta = canciones.MinBy(c => c.Duracion);

WriteLine(cancionMasCorta);

// Obtener la duración total de todas las canciones
// SQL: SELECT SUM(Duracion) FROM Canciones
WriteLine("\n*** Duración total de todas las canciones ***");
var duracionTotal = canciones.Sum(c => c.Duracion);

WriteLine($"Duración total: {duracionTotal / 60.0:F2} minutos");

// Obtener los cantantes únicos
// SQL: SELECT DISTINCT Cantante FROM Canciones
WriteLine("\n*** Cantantes únicos ***");
var cantantesUnicos = canciones.Select(c => c.Cantante).Distinct().ToList();

cantantesUnicos.ForEach(WriteLine);

// Obtener canciones ordenadas por duración (página 1 de 3 en 3)
// SQL: SELECT * FROM Canciones ORDER BY Duracion OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Canciones ordenadas por duración (página 1) ***");
var porDuracionPag1 = canciones.OrderBy(c => c.Duracion).Take(3).ToList();

porDuracionPag1.ForEach(WriteLine);

WriteLine("\n*** Canciones ordenadas por duración (página 2) ***");
var porDuracionPag2 = canciones.OrderBy(c => c.Duracion).Skip(3).Take(3).ToList();

porDuracionPag2.ForEach(WriteLine);

WriteLine("\n*** Canciones ordenadas por duración (página 3) ***");
var porDuracionPag3 = canciones.OrderBy(c => c.Duracion).Skip(6).Take(3).ToList();

porDuracionPag3.ForEach(WriteLine);

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Canciones de Bon Jovi con duración mayor a 240 segundos
// SQL: SELECT * FROM Canciones WHERE Cantante = 'Bon Jovi' AND Duracion > 240
WriteLine("\n*** Canciones de Bon Jovi con duración > 240s ***");
var bonJoviLargas = canciones
    .Where(c => c.Cantante == "Bon Jovi" && c.Duracion > 240)
    .ToList();

bonJoviLargas.ForEach(WriteLine);

// Canciones de Bryan Adams O Europe
// SQL: SELECT * FROM Canciones WHERE Cantante IN ('Bryan Adams', 'Europe')
WriteLine("\n*** Canciones de Bryan Adams o Europe ***");
var cantantesFavoritos = new[] { "Bryan Adams", "Europe" };
var cancionesFavoritas = canciones
    .Where(c => cantantesFavoritos.Contains(c.Cantante))
    .ToList();

cancionesFavoritas.ForEach(WriteLine);

// Canciones con duración entre 200 y 300 segundos
// SQL: SELECT * FROM Canciones WHERE Duracion BETWEEN 200 AND 300
WriteLine("\n*** Canciones con duración entre 200 y 300 segundos ***");
var duracionEntre = canciones
    .Where(c => c.Duracion >= 200 && c.Duracion <= 300)
    .ToList();

duracionEntre.ForEach(WriteLine);

// Canciones que NO son de Black Sabbath NI de Brad Paisley
// SQL: SELECT * FROM Canciones WHERE Cantante NOT IN ('Black Sabbath', 'Brad Paisley')
WriteLine("\n*** Canciones que NO son de Black Sabbath ni Brad Paisley ***");
var cantantesExcluidos = new[] { "Black Sabbath", "Brad Paisley" };
var cancionesNoExcluidas = canciones
    .Where(c => !cantantesExcluidos.Contains(c.Cantante))
    .ToList();

cancionesNoExcluidas.ForEach(WriteLine);

// Canciones cuyo título contiene 'a' Y duración menor a 250
// SQL: SELECT * FROM Canciones WHERE Titulo LIKE '%a%' AND Duracion < 250
WriteLine("\n*** Canciones con 'a' en título y duración < 250 ***");
var tituloConA = canciones
    .Where(c => c.Titulo.Contains("a", StringComparison.OrdinalIgnoreCase) && c.Duracion < 250)
    .ToList();

tituloConA.ForEach(WriteLine);

// Canciones con duración mayor a 200 O de cantantes que empiezan por B
// SQL: SELECT * FROM Canciones WHERE Duracion > 200 OR Cantante LIKE 'B%'
WriteLine("\n*** Duración > 200s o cantante empieza por B ***");
var duracionOStartsB = canciones
    .Where(c => c.Duracion > 200 || c.Cantante.StartsWith("B"))
    .ToList();

duracionOStartsB.ForEach(WriteLine);

// Múltiples Where encadenados
// SQL: SELECT * FROM Canciones WHERE Cantante = 'Bon Jovi' ORDER BY Duracion DESC
WriteLine("\n*** Múltiples Where: Bon Jovi ordenadas por duración ***");
var multiplesWhere = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .Where(c => c.Duracion > 200)
    .OrderByDescending(c => c.Duracion)
    .ToList();

multiplesWhere.ForEach(WriteLine);

// Canciones con título de más de 10 caracteres
// SQL: SELECT * FROM Canciones WHERE LEN(Titulo) > 10
WriteLine("\n*** Títulos con más de 10 caracteres ***");
var titulosLargos = canciones
    .Where(c => c.Titulo.Length > 10)
    .ToList();

titulosLargos.ForEach(WriteLine);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: título y duración formateada como tipo anónimo
// SQL: SELECT Titulo, Duracion FROM Canciones
WriteLine("\n*** Proyección: título y duración formateada ***");
var proyeccionesFormateadas = canciones
    .Select(c => new { c.Titulo, DuracionMin = c.Duracion / 60.0 })
    .ToList();

proyeccionesFormateadas.ForEach(p => WriteLine($"{p.Titulo}: {p.DuracionMin:F2} min"));

// Proyección: clasificar canciones por duración
// SQL: SELECT Titulo, Duracion, CASE WHEN Duracion > 250 THEN 'Larga' ELSE 'Corta' END as Tipo FROM Canciones
WriteLine("\n*** Proyección: clasificación por duración ***");
var clasificacionDuracion = canciones
    .Select(c => new 
    { 
        c.Titulo, 
        c.Duracion,
        Tipo = c.Duracion > 250 ? "Larga" : "Corta"
    })
    .ToList();

clasificacionDuracion.ForEach(c => WriteLine($"{c.Titulo}: {c.Duracion}s - {c.Tipo}"));

// Proyección: crear objeto con información completa del artista
// SQL: SELECT Cantante, COUNT(*) as Cantidad, AVG(Duracion) as Media FROM Canciones GROUP BY Cantante
WriteLine("\n*** Proyección: estadísticas por cantante ***");
var estadisticasProyeccion = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key,
        g => new 
        { 
            Cantidad = g.Count(),
            DuracionMedia = g.Average(c => c.Duracion),
            DuracionTotal = g.Sum(c => c.Duracion)
        }
    );

estadisticasProyeccion.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value.Cantidad} canciones, Media={kv.Value.DuracionMedia:F1}s, Total={kv.Value.DuracionTotal}s"));

// Proyección: filtrar Y proyectar en un solo paso
// SQL: SELECT Titulo, Cantante FROM Canciones WHERE Duracion > 220
WriteLine("\n*** Filtrar y proyectar: canciones largas ***");
var filtroProyeccion = canciones
    .Where(c => c.Duracion > 220)
    .Select(c => new { c.Titulo, c.Cantante, c.Duracion })
    .ToList();

filtroProyeccion.ForEach(p => WriteLine($"{p.Titulo} - {p.Cantante} ({p.Duracion}s)"));

// Proyección con cálculo: duración en minutos y segundos
// SQL: SELECT Titulo, Duracion / 60 as Minutos, Duracion % 60 as Segundos FROM Canciones
WriteLine("\n*** Proyección: duración en minutos y segundos ***");
var duracionMinSeg = canciones
    .Select(c => new 
    { 
        c.Titulo, 
        Minutos = c.Duracion / 60,
        Segundos = c.Duracion % 60
    })
    .ToList();

duracionMinSeg.ForEach(d => WriteLine($"{d.Titulo}: {d.Minutos}:{d.Segundos:D2}"));

// Proyección: agrupar y crear resumen por cantante
// SQL: SELECT Cantante, MIN(Duracion) as Corta, MAX(Duracion) as Larga FROM Canciones GROUP BY Cantante
WriteLine("\n*** Proyección: canción más corta y más larga por cantante ***");
var resumenCantante = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MasCorta = g.MinBy(c => c.Duracion).Titulo,
            DuracionCorta = g.Min(c => c.Duracion),
            MasLarga = g.MaxBy(c => c.Duracion).Titulo,
            DuracionLarga = g.Max(c => c.Duracion)
        }
    );

resumenCantante.ToList().ForEach(kv => WriteLine($"{kv.Key}: Corta={kv.Value.MasCorta} ({kv.Value.DuracionCorta}s), Larga={kv.Value.MasLarga} ({kv.Value.DuracionLarga}s)"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = canciones.Where(c => c.Duracion > 200);
    canciones.Add(new Cancion("Nueva", "Artista", 250)); // ¡Consulta no ejecutada!
    consulta.ForEach(...); // AHORA se ejecuta, incluyendo la nueva canción

CON .ToList():
    var consulta = canciones.Where(c => c.Duracion > 200).ToList();
    canciones.Add(new Cancion("Nueva", "Artista", 250)); // Consulta ya ejecutada
    // consulta ya tiene los resultados "congelados"

¿CUÁNDO USAR .ToList()?
1. Para "congelar" los resultados en un momento específico
2. Para evitar múltiples ejecuciones de la misma consulta (rendimiento)
3. Para trabajar con métodos de List<T> (ForEach, Add, Remove, etc.)
4. Para depurar y ver los resultados intermedios
5. Para ejecutar subconsultas (First, Single, etc.)

EQUIVALENTES SQL:
- .ToList() ≈ SELECT ... INTO #temptable
- Sin .ToList() ≈ CREATE VIEW (se ejecuta cada vez que se accede)

MÉTODOS QUE FUERZAN LA EJECUCIÓN:
- .ToList(), .ToArray(), .ToDictionary()
- .First(), .Single(), .Last()
- .Count(), .Sum(), .Average(), .Min(), .Max()
- .Any(), .All()
*/

// Ejemplo práctico de deferred execution
WriteLine("\n*** Ejemplo: Deferred Execution sin .ToList() ***");
var consultaDiferida = canciones.Where(c => c.Duracion > 220);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Canciones encontradas: {consultaDiferida.Count()}");

canciones.Add(new Cancion("Nueva Canción", "Artista", 300));
WriteLine("Nueva canción agregada");

WriteLine($"Canciones encontradas: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces

// Ejemplo con .ToList()
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = canciones.Where(c => c.Duracion > 220).ToList();
WriteLine("Consulta ejecutada con .ToList()");

canciones.Add(new Cancion("Otra Nueva", "Artista", 250));
WriteLine("Nueva canción agregada");

WriteLine($"Canciones en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
