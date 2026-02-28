using System.Linq;
using static System.Console;
using Canciones.Models;

var canciones = new List<Cancion>
{
    new("It's My Life", "Bon Jovi", 224),
    new("Always", "Bon Jovi", 353),
    new("Livin' on a Prayer", "Bon Jovi", 249),
    new("Bed of Roses", "Bon Jovi", 394),
    new("You Give Love a Bad Name", "Bon Jovi", 222),
    new("Summer of '69", "Bryan Adams", 215),
    new("Everything I Do", "Bryan Adams", 393),
    new("Heaven", "Bryan Adams", 243),
    new("Run to You", "Bryan Adams", 234),
    new("Please Forgive Me", "Bryan Adams", 356),
    new("Thunderstruck", "AC/DC", 292),
    new("Back in Black", "AC/DC", 255),
    new("Highway to Hell", "AC/DC", 208),
    new("You Shook Me All Night Long", "AC/DC", 210),
    new("Hells Bells", "AC/DC", 312),
    new("Bohemian Rhapsody", "Queen", 354),
    new("Don't Stop Me Now", "Queen", 209),
    new("We Will Rock You", "Queen", 121),
    new("We Are the Champions", "Queen", 179),
    new("Under Pressure", "Queen", 242)
};

// ============================================================
// CONSULTAS BÁSICAS
// ============================================================

WriteLine("\n*** Filtrar canciones por cantante ***");
var cancionesBonJovi = canciones
    .Where(c => c.Cantante == "Bon Jovi");

foreach (var c in cancionesBonJovi)
    WriteLine(c);

WriteLine("\n*** Transformar elementos: cantante en mayúsculas ***");
var cancionesMayus = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .Select(c => new Cancion(c.Titulo, c.Cantante.ToUpper(), c.Duracion));

foreach (var c in cancionesMayus)
    WriteLine(c);

WriteLine("\n*** Obtener solo títulos de canciones por cantante ***");
var titulos = canciones
    .Where(c => c.Cantante == "Bon Jovi")
    .Select(c => c.Titulo);

foreach (var t in titulos)
    WriteLine(t);

WriteLine("\n*** Eliminar duplicados ***");
var sinDuplicados = canciones
    .Distinct();

foreach (var c in sinDuplicados)
    WriteLine(c);

WriteLine("\n*** Contar canciones de un cantante ***");
var totalBonJovi = canciones
    .Count(c => c.Cantante == "Bon Jovi");

WriteLine($"Bon Jovi aparece: {totalBonJovi} veces");

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** Agrupar canciones por cantante ***");
var agrupadas = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key, 
        g => g.Count()
    );

foreach (var item in agrupadas)
    WriteLine($"Cantante: {item.Key}, Cantidad: {item.Value}");

WriteLine("\n*** Cantante con más canciones ***");
var topCantante = canciones
    .GroupBy(c => c.Cantante)
    .OrderByDescending(g => g.Count())
    .First();

WriteLine($"{topCantante.Key}: {topCantante.Count()} canciones");

WriteLine("\n*** Canciones agrupadas por cantante ***");
var porCantante = canciones
    .GroupBy(c => c.Cantante);

foreach (var grupo in porCantante)
{
    WriteLine($"\n{grupo.Key}:");
    foreach (var c in grupo)
        WriteLine($"  - {c.Titulo}");
}

WriteLine("\n*** Estadísticas por cantante ***");
var statsCantante = canciones
    .GroupBy(c => c.Cantante)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Cantidad = g.Count(),
            Primera = g.MinBy(c => c.Titulo)?.Titulo,
            Ultima = g.MaxBy(c => c.Titulo)?.Titulo
        }
    );

foreach (var item in statsCantante)
    WriteLine($"{item.Key}: {item.Value.Cantidad} canciones, Primera={item.Value.Primera}, Ultima={item.Value.Ultima}");

WriteLine("\n*** La canción que dura más ***");
var cancionMasLarga = canciones
    .MaxBy(c => c.Duracion);

WriteLine(cancionMasLarga);

WriteLine("\n*** Duración media de las canciones ***");
var mediaSec = canciones
    .Average(c => c.Duracion);

WriteLine($"Duración media: {mediaSec / 60.0:F2} minutos ({(int)mediaSec / 60}:{mediaSec % 60:D2} segundos)");

WriteLine("\n*** Canción más larga de cada grupo ***");
var topPorGrupo = canciones
    .GroupBy(c => c.Cantante)
    .Select(g => g.MaxBy(c => c.Duracion));

foreach (var c in topPorGrupo)
    WriteLine(c);

WriteLine("\n=== FIN ===");
