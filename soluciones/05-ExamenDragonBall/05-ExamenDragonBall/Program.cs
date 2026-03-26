using System.Linq;
using static System.Console;
using ExamenDragonBall.Models;

var luchadores = new List<Personaje>
{
    new(1, "Son Goku", "saiyan", 9000000000),
    new(2, "Vegeta", "saiyan", 8500000000),
    new(3, "Piccolo", "namekiano", 4000000),
    new(4, "Krillin", "terrícola", 75000),
    new(5, "Android 18", "androide", 320000000),
    new(6, "Frieza", "freeza", 12000000000),
    new(7, "Trunks", "saiyan", 8000000),
    new(8, "Gohan", "saiyan", 10000000),
    new(9, "Dende", "namekiano", 3000),
    new(10, "Yamcha", "terrícola", 12000)
};

// ============================================================
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

// Obtener todos los personajes
// SQL: SELECT * FROM Personajes
WriteLine("*** Lista de Personajes ***");
luchadores.ForEach(WriteLine);

// Obtener los personajes que son saiyan
// SQL: SELECT * FROM Personajes WHERE Raza = 'saiyan'
WriteLine("\n*** Personajes que son saiyan ***");
var luchadoresSaiyan = luchadores
    .Where(l => l.Raza == "saiyan")
    .ToList();

luchadoresSaiyan.ForEach(WriteLine);

// Obtener el personaje más fuerte
// SQL: SELECT TOP 1 * FROM Personajes ORDER BY Poder DESC
WriteLine("\n*** El personaje más fuerte ***");
var luchadorMasFuerte = luchadores
    .OrderByDescending(l => l.Poder)
    .First();

WriteLine(luchadorMasFuerte);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar por raza y mostrar el listado de personajes
// SQL: SELECT * FROM Personajes
WriteLine("\n*** Personajes agrupados por raza ***");
var luchadoresPorRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToList();

luchadoresPorRaza.ForEach(g =>
{
    WriteLine($"\nRaza: {g.Key}");
    g.ToList().ForEach(l => WriteLine($"  - {l.Nombre} (Poder: {l.Poder})"));
});

// Calcular la media del poder del universo 7
// SQL: SELECT AVG(Poder) FROM Personajes
WriteLine("\n*** Media del poder del universo 7 ***");
var mediaPoder = luchadores.Average(l => l.Poder);

WriteLine($"Media de poder: {mediaPoder:N0}");

// Agrupar por raza y obtener el personaje más fuerte de cada una
// SQL: SELECT * FROM Personajes p1 WHERE Poder = (SELECT MAX(Poder) FROM Personajes p2 WHERE p1.Raza = p2.Raza)
WriteLine("\n*** Personaje más fuerte de cada raza ***");
var masFuertePorRaza = luchadores
    .GroupBy(l => l.Raza)
    .Select(g => g.MaxBy(l => l.Poder))
    .ToList();

masFuertePorRaza.ForEach(WriteLine);

// Agrupar por raza: personaje más fuerte y más débil
// SQL: SELECT Raza, MAX(Poder), MIN(Poder) FROM Personajes GROUP BY Raza
WriteLine("\n*** Personaje más fuerte y más débil por raza ***");
var fuerteDebilPorRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MasFuerte = g.MaxBy(l => l.Poder).Nombre,
            PoderFuerte = g.Max(l => l.Poder),
            MasDebil = g.MinBy(l => l.Poder).Nombre,
            PoderDebil = g.Min(l => l.Poder)
        }
    );

fuerteDebilPorRaza.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Más fuerte={kv.Value.MasFuerte} ({kv.Value.PoderFuerte:N0}), Más débil={kv.Value.MasDebil} ({kv.Value.PoderDebil:N0})"));

// Agrupar por raza: estadísticas completas
// SQL: SELECT Raza, MAX(Poder), MIN(Poder), AVG(Poder), COUNT(*) FROM Personajes GROUP BY Raza
WriteLine("\n*** Estadísticas completas por raza ***");
var estadisticasPorRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MaxPoder = g.Max(l => l.Poder),
            MinPoder = g.Min(l => l.Poder),
            MediaPoder = g.Average(l => l.Poder),
            Cantidad = g.Count()
        }
    );

estadisticasPorRaza.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Max={kv.Value.MaxPoder:N0}, Min={kv.Value.MinPoder:N0}, Media={kv.Value.MediaPoder:N0}, Cantidad={kv.Value.Cantidad}"));

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar los primeros 3 personajes
// SQL: SELECT TOP 3 * FROM Personajes
WriteLine("\n*** Primeros 3 personajes ***");
var primeros3 = luchadores.Take(3).ToList();

primeros3.ForEach(WriteLine);

// Paginación: mostrar los siguientes 3 personajes
// SQL: SELECT * FROM Personajes OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Siguientes 3 personajes ***");
var siguientes3 = luchadores.Skip(3).Take(3).ToList();

siguientes3.ForEach(WriteLine);

// Paginación: últimos 3 personajes
// SQL: SELECT * FROM Personajes OFFSET 6 ROWS
WriteLine("\n*** Últimos 3 personajes ***");
var ultimos3 = luchadores.Skip(7).Take(3).ToList();

ultimos3.ForEach(WriteLine);

// Verificar si existe algún personaje de raza namekiano
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Personajes WHERE Raza = 'namekiano') THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún namekiano? ***");
var hayNamekiano = luchadores.Any(l => l.Raza == "namekiano");

WriteLine(hayNamekiano ? "Sí, hay namekianos" : "No hay namekianos");

// Verificar si todos los personajes tienen poder mayor a 1000
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Personajes WHERE Poder > 1000) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los personajes tienen poder mayor a 1000? ***");
var todosMillonarios = luchadores.All(l => l.Poder > 1000);

WriteLine(todosMillonarios ? "Sí, todos tienen poder > 1000" : "Algunos tienen poder <= 1000");

// Obtener el personaje más débil
// SQL: SELECT TOP 1 * FROM Personajes ORDER BY Poder ASC
WriteLine("\n*** El personaje más débil ***");
var masDebil = luchadores.MinBy(l => l.Poder);

WriteLine(masDebil);

// Obtener la suma del poder de todos los personajes
// SQL: SELECT SUM(Poder) FROM Personajes
WriteLine("\n*** Poder total de todos los personajes ***");
var poderTotal = luchadores.Sum(l => l.Poder);

WriteLine($"Poder total: {poderTotal:N0}");

// Obtener personajes sin poder (poder = 0)
// SQL: SELECT * FROM Personajes WHERE Poder = 0
WriteLine("\n*** Personajes sin poder ***");
var sinPoder = luchadores.Where(l => l.Poder == 0).ToList();

sinPoder.ForEach(WriteLine);

// Obtener razas únicas
// SQL: SELECT DISTINCT Raza FROM Personajes
WriteLine("\n*** Razas únicas ***");
var razasUnicas = luchadores.Select(l => l.Raza).Distinct().ToList();

razasUnicas.ForEach(WriteLine);

// Personajes ordenados por poder (página 1 de 3 en 3)
// SQL: SELECT * FROM Personajes ORDER BY Poder OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Personajes ordenados por poder (página 1) ***");
var porPoderPag1 = luchadores.OrderBy(l => l.Poder).Take(3).ToList();

porPoderPag1.ForEach(WriteLine);

WriteLine("\n*** Personajes ordenados por poder (página 2) ***");
var porPoderPag2 = luchadores.OrderBy(l => l.Poder).Skip(3).Take(3).ToList();

porPoderPag2.ForEach(WriteLine);

WriteLine("\n*** Personajes ordenados por poder (página 3) ***");
var porPoderPag3 = luchadores.OrderBy(l => l.Poder).Skip(6).Take(3).ToList();

porPoderPag3.ForEach(WriteLine);

// Obtener el personaje con ID = 1
// SQL: SELECT TOP 1 * FROM Personajes WHERE Id = 1
WriteLine("\n*** Personaje con ID = 1 ***");
var personajeId1 = luchadores.SingleOrDefault(l => l.Id == 1);

WriteLine(personajeId1?.ToString() ?? "No encontrado");

// Contar personajes por raza (más de 1 personaje)
// SQL: SELECT Raza, COUNT(*) FROM Personajes GROUP BY Raza HAVING COUNT(*) > 1
WriteLine("\n*** Razas con más de 1 personaje ***");
var razaConMas = luchadores
    .GroupBy(l => l.Raza)
    .Where(g => g.Count() > 1)
    .ToList();

razaConMas.ForEach(g => WriteLine($"{g.Key}: {g.Count()} personajes"));

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Personajes saiyan con poder mayor a 5,000,000,000
// SQL: SELECT * FROM Personajes WHERE Raza = 'saiyan' AND Poder > 5000000000
WriteLine("\n*** Saiyans con poder > 5,000,000,000 ***");
var saiyanPoderoso = luchadores
    .Where(l => l.Raza == "saiyan" && l.Poder > 5000000000)
    .ToList();

saiyanPoderoso.ForEach(WriteLine);

// Personajes de raza namekiano O terrícola
// SQL: SELECT * FROM Personajes WHERE Raza IN ('namekiano', 'terrícola')
WriteLine("\n*** Personajes namekianos o terrícolas ***");
var razas = new[] { "namekiano", "terrícola" };
var namekianoTerricola = luchadores
    .Where(l => razas.Contains(l.Raza))
    .ToList();

namekianoTerricola.ForEach(WriteLine);

// Personajes con poder entre 1,000,000 y 10,000,000
// SQL: SELECT * FROM Personajes WHERE Poder BETWEEN 1000000 AND 10000000
WriteLine("\n*** Poder entre 1M y 10M ***");
var poderMedio = luchadores
    .Where(l => l.Poder >= 1000000 && l.Poder <= 10000000)
    .ToList();

poderMedio.ForEach(WriteLine);

// Personajes cuyo nombre contiene 'G' (case insensitive)
// SQL: SELECT * FROM Personajes WHERE Nombre LIKE '%G%'
WriteLine("\n*** Nombre contiene 'G' ***");
var nombreConG = luchadores
    .Where(l => l.Nombre.Contains("G", StringComparison.OrdinalIgnoreCase))
    .ToList();

nombreConG.ForEach(WriteLine);

// Personajes con poder mayor a 1,000,000 O de raza androide
// SQL: SELECT * FROM Personajes WHERE Poder > 1000000 OR Raza = 'androide'
WriteLine("\n*** Poder > 1M o raza androide ***");
var poderosoOAndroide = luchadores
    .Where(l => l.Poder > 1000000 || l.Raza == "androide")
    .ToList();

poderosoOAndroide.ForEach(WriteLine);

// Personajes NO saiyan
// SQL: SELECT * FROM Personajes WHERE Raza != 'saiyan'
WriteLine("\n*** Personajes que NO son saiyan ***");
var noSaiyan = luchadores
    .Where(l => l.Raza != "saiyan")
    .ToList();

noSaiyan.ForEach(WriteLine);

// Personajes con poder mayor a 1,000 Y nombre que contiene 'o'
// SQL: SELECT * FROM Personajes WHERE Poder > 1000 AND Nombre LIKE '%o%'
WriteLine("\n*** Poder > 1000 y nombre con 'o' ***");
var poderYNombre = luchadores
    .Where(l => l.Poder > 1000 && l.Nombre.Contains("o", StringComparison.OrdinalIgnoreCase))
    .ToList();

poderYNombre.ForEach(WriteLine);

// Múltiples Where encadenados
// SQL: SELECT * FROM Personajes WHERE Raza = 'saiyan' ORDER BY Poder DESC
WriteLine("\n*** Múltiples Where: saiyan ordenados por poder ***");
var multiplesWhere = luchadores
    .Where(l => l.Raza == "saiyan")
    .Where(l => l.Poder > 1000000)
    .OrderByDescending(l => l.Poder)
    .ToList();

multiplesWhere.ForEach(WriteLine);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: nombre y poder formateado
// SQL: SELECT Nombre, Poder FROM Personajes
WriteLine("\n*** Proyección: nombre y poder formateado ***");
var proyeccionesNombrePoder = luchadores
    .Select(l => new { l.Nombre, PoderFormateado = $"{l.Poder:N0}" })
    .ToList();

proyeccionesNombrePoder.ForEach(p => WriteLine($"{p.Nombre}: {p.PoderFormateado}"));

// Proyección: clasificar personajes por nivel de poder
// SQL: SELECT Nombre, Poder, CASE WHEN Poder > 1000000000 THEN 'Dios' WHEN Poder > 1000000 THEN 'Guerrero' WHEN Poder > 10000 THEN 'Luchador' ELSE 'Débil' END as Nivel FROM Personajes
WriteLine("\n*** Proyección: clasificación por nivel de poder ***");
var clasificacionPoder = luchadores
    .Select(l => new 
    { 
        l.Nombre, 
        l.Poder,
        Nivel = l.Poder > 1000000000 ? "Dios" : 
                (l.Poder > 1000000 ? "Guerrero" : 
                (l.Poder > 10000 ? "Luchador" : "Débil"))
    })
    .ToList();

clasificacionPoder.ForEach(c => WriteLine($"{c.Nombre}: {c.Poder:N0} - {c.Nivel}"));

// Proyección: información resumida
// SQL: SELECT Nombre, Raza, LEFT(Nombre, 1) as Inicial FROM Personajes
WriteLine("\n*** Proyección: información resumida ***");
var infoResumida = luchadores
    .Select(l => new 
    { 
        l.Nombre, 
        l.Raza,
        Inicial = l.Nombre.Substring(0, 1)
    })
    .ToList();

infoResumida.ForEach(i => WriteLine($"{i.Inicial}. {i.Nombre} ({i.Raza})"));

// Proyección: estadísticas por raza
// SQL: SELECT Raza, COUNT(*) as Cantidad, MAX(Poder) as Maximo, MIN(Poder) as Minimo, AVG(Poder) as Media FROM Personajes GROUP BY Raza
WriteLine("\n*** Proyección: estadísticas por raza ***");
var estadisticasRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToDictionary(
        g => g.Key,
        g => new 
        { 
            Cantidad = g.Count(),
            Maximo = g.Max(l => l.Poder),
            Minimo = g.Min(l => l.Poder),
            Media = g.Average(l => l.Poder)
        }
    );

estadisticasRaza.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value.Cantidad} personajes, Poder máx={kv.Value.Maximo:N0}, mín={kv.Value.Minimo:N0}, media={kv.Value.Media:N0}"));

// Proyección: filtrar Y proyectar
// SQL: SELECT Nombre, Poder FROM Personajes WHERE Raza = 'saiyan'
WriteLine("\n*** Filtrar y proyectar: saiyan ***");
var filtroProyeccion = luchadores
    .Where(l => l.Raza == "saiyan")
    .Select(l => new { l.Nombre, l.Poder })
    .ToList();

filtroProyeccion.ForEach(p => WriteLine($"{p.Nombre}: {p.Poder:N0}"));

// Proyección: clasificar por amenaza
// SQL: SELECT Nombre, Raza, CASE WHEN Raza = 'freeza' THEN 'Amenaza máxima' WHEN Raza = 'saiyan' THEN 'Guerrero' ELSE 'Otro' END as Tipo FROM Personajes
WriteLine("\n*** Proyección: clasificación por amenaza ***");
var clasificacionAmenaza = luchadores
    .Select(l => new 
    { 
        l.Nombre, 
        l.Raza,
        Tipo = l.Raza == "freeza" ? "Amenaza máxima" : 
               (l.Raza == "saiyan" ? "Guerrero" : "Otro")
    })
    .ToList();

clasificacionAmenaza.ForEach(c => WriteLine($"{c.Nombre} ({c.Raza}): {c.Tipo}"));

// Proyección: ranking de poder
// SQL: SELECT ROW_NUMBER() OVER (ORDER BY Poder DESC) as Ranking, Nombre, Poder FROM Personajes
WriteLine("\n*** Proyección: ranking de poder ***");
var rankingPoder = luchadores
    .OrderByDescending(l => l.Poder)
    .Select((l, index) => new 
    { 
        Ranking = index + 1,
        l.Nombre,
        l.Poder
    })
    .ToList();

rankingPoder.ForEach(r => WriteLine($"#{r.Ranking}: {r.Nombre} - {r.Poder:N0}"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = luchadores.Where(l => l.Poder > 1000000);
    luchadores.Add(new Personaje(11, "Broly", "saiyan", 15000000000)); // ¡No ejecutada!
    consulta.ForEach(...); // AHORA se ejecuta

CON .ToList():
    var consulta = luchadores.Where(l => l.Poder > 1000000).ToList();
    luchadores.Add(new Personaje(11, "Broly", "saiyan", 15000000000));
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
var consultaDiferida = luchadores.Where(l => l.Poder > 10000000);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Personajes encontrados: {consultaDiferida.Count()}");

luchadores.Add(new Personaje(11, "Broly", "saiyan", 15000000000L));
WriteLine("Nuevo personaje agregado");

WriteLine($"Personajes encontrados: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces

// Ejemplo con .ToList()
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = luchadores.Where(l => l.Poder > 10000000).ToList();
WriteLine("Consulta ejecutada con .ToList()");

luchadores.Add(new Personaje(12, "Gogeta", "saiyan", 20000000000L));
WriteLine("Nuevo personaje agregado");

WriteLine($"Personajes en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
