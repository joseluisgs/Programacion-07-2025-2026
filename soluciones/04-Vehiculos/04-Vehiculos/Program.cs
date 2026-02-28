using System.Linq;
using static System.Console;
using Vehiculos.Models;

var vehiculos = new List<Vehiculo>
{
    new("Toyota", "Corolla", 2020, "Blanco", 5.5, 35000),
    new("Seat", "Ibiza", 2018, "Rojo", 6.2, 62000),
    new("Ford", "Focus", 2019, "Azul", 5.8, 48000),
    new("Renault", "Clio", 2021, "Gris", 5.2, 12000),
    new("Volkswagen", "Golf", 2017, "Negro", 6.5, 85000),
    new("Peugeot", "208", 2022, "Amarillo", 4.9, 5000),
    new("Kia", "Sportage", 2020, "Blanco", 7.1, 28000),
    new("Hyundai", "Tucson", 2021, "Rojo", 6.8, 15000),
    new("Mazda", "CX-5", 2019, "Azul", 7.5, 42000),
    new("Toyota", "Yaris", 2022, "Blanco", 4.2, 2000)
};

// ============================================================
// CONSULTAS BÁSICAS
// ============================================================

WriteLine("\n*** Vehículos con consumo menor a 6.0 ***");
var bajoConsumo = vehiculos
    .Where(v => v.Consumo < 6.0);

foreach (var v in bajoConsumo)
    WriteLine(v);

WriteLine("\n*** Vehículos de color Rojo o Blanco ***");
var colores = vehiculos
    .Where(v => v.Color == "Rojo" || v.Color == "Blanco");

foreach (var v in colores)
    WriteLine(v);

WriteLine("\n*** Vehículos ordenados por kilómetros (desc) ***");
var ordenKm = vehiculos
    .OrderByDescending(v => v.Kilometraje);

foreach (var v in ordenKm)
    WriteLine($"{v.Marca} {v.Modelo}: {v.Kilometraje}km");

WriteLine("\n*** Obtener solo marcas únicas ***");
var marcas = vehiculos
    .Select(v => v.Marca)
    .Distinct();

foreach (var m in marcas)
    WriteLine(m);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** Cantidad de vehículos por marca ***");
var marcasCount = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(
        g => g.Key, 
        g => g.Count()
    );

foreach (var item in marcasCount)
    WriteLine($"{item.Key}: {item.Value}");

WriteLine("\n*** Vehículos agrupados por color ***");
var porColor = vehiculos
    .GroupBy(v => v.Color);

foreach (var grupo in porColor)
{
    WriteLine($"\nColor {grupo.Key}:");
    foreach (var v in grupo)
        WriteLine($"  - {v.Marca} {v.Modelo}");
}

WriteLine("\n*** Kilometraje medio por marca ***");
var mediaKmMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(
        g => g.Key, 
        g => g.Average(v => v.Kilometraje)
    );

foreach (var item in mediaKmMarca)
    WriteLine($"{item.Key}: {item.Value:F0} km de media");

WriteLine("\n*** Vehículo con menor consumo ***");
var mechero = vehiculos
    .MinBy(v => v.Consumo);

WriteLine(mechero);

WriteLine("\n*** Estadísticas de kilometraje ***");
// Materializamos solo porque recorremos la colección varias veces para agregados.
var kilometrajes = vehiculos
    .Select(v => v.Kilometraje)
    .ToList();

WriteLine($"Total vehículos: {kilometrajes.Count}");
WriteLine($"Kilómetros totales: {kilometrajes.Sum()}");
WriteLine($"Media km: {kilometrajes.Average():F2}");
WriteLine($"Mínimo km: {kilometrajes.Min()}");
WriteLine($"Máximo km: {kilometrajes.Max()}");

WriteLine("\n*** Vehículos fabricados después de 2020 ***");
var modernos = vehiculos
    .Where(v => v.AñoFabricacion > 2020);

foreach (var v in modernos)
    WriteLine(v);

WriteLine("\n=== FIN ===");
