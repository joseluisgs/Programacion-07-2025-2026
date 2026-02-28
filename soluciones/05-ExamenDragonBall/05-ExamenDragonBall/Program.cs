using System.Linq;
using static System.Console;
using ExamenDragonBall.Models;

var luchadores = new List<Personaje>
{
    new(1, "Goku", "Saiyan", 150000000),
    new(2, "Vegeta", "Saiyan", 140000000),
    new(3, "Gohan", "Saiyan", 100000000),
    new(4, "Piccolo", "Namekiano", 5000000),
    new(5, "Freezer", "Frieza Race", 120000000),
    new(6, "Cell", "Androide", 90000000),
    new(7, "Majin Buu", "Majin", 130000000),
    new(8, "Trunks", "Saiyan", 80000000),
    new(9, "Krillin", "Humano", 500000),
    new(10, "Tien", "Humano", 800000)
};

// ============================================================
// CONSULTAS BÁSICAS
// ============================================================

WriteLine("\n*** Luchadores de raza Saiyan ***");
var saiyans = luchadores.Where(l => l.Raza == "Saiyan");
foreach (var l in saiyans)
    WriteLine(l);

WriteLine("\n*** Luchadores con poder > 100.000.000 ***");
var poderosos = luchadores.Where(l => l.Poder > 100000000);
foreach (var l in poderosos)
    WriteLine(l);

WriteLine("\n*** Luchadores ordenados por poder (desc) ***");
var ordenPoder = luchadores.OrderByDescending(l => l.Poder);
foreach (var l in ordenPoder)
    WriteLine($"{l.Nombre}: {l.Poder:N0}");

WriteLine("\n*** Solo los nombres de los villanos (Majin o Androide o Frieza Race) ***");
var villanos = luchadores.Where(l => l.Raza != "Saiyan" && l.Raza != "Humano" && l.Raza != "Namekiano").Select(l => l.Nombre);
foreach (var n in villanos)
    WriteLine(n);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** Cantidad de luchadores por raza ***");
var porRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToDictionary(g => g.Key, g => g.Count());

foreach (var item in porRaza)
    WriteLine($"{item.Key}: {item.Value}");

WriteLine("\n*** Promedio de poder por raza ***");
var poderMedioRaza = luchadores
    .GroupBy(l => l.Raza)
    .ToDictionary(g => g.Key, g => g.Average(l => l.Poder));

foreach (var item in poderMedioRaza)
    WriteLine($"{item.Key}: {item.Value:N0} de poder medio");

WriteLine("\n*** El luchador más poderoso ***");
var topLuchador = luchadores.MaxBy(l => l.Poder);
WriteLine(topLuchador);

WriteLine("\n*** Estadísticas globales de poder ***");
// Materializamos solo porque recorremos 5 veces la misma colección de poderes.
var poderes = luchadores.Select(l => l.Poder).ToList();
WriteLine($"Total luchadores: {poderes.Count}");
WriteLine($"Poder total: {poderes.Sum():N0}");
WriteLine($"Poder medio: {poderes.Average():N0}");
WriteLine($"Poder mínimo: {poderes.Min():N0}");
WriteLine($"Poder máximo: {poderes.Max():N0}");

WriteLine("\n*** Paginación: Top 3 más poderosos ***");
var top3 = luchadores.OrderByDescending(l => l.Poder).Take(3);
foreach (var l in top3)
    WriteLine(l);

WriteLine("\n=== FIN ===");
