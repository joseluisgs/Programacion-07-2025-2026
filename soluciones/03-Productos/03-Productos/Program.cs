using System.Linq;
using static System.Console;
using Productos.Models;

var products = new List<Product>
{
    new(1, "Chai", 1, 1, 18.00, 39),
    new(2, "Chang", 1, 1, 19.00, 17),
    new(3, "Aniseed Syrup", 1, 2, 10.00, 13),
    new(4, "Chef Anton's Cajun Seasoning", 2, 2, 22.00, 53),
    new(5, "Chef Anton's Gumbo Mix", 2, 2, 21.35, 0),
    new(6, "Grandma's Boysenberry Spread", 3, 2, 25.00, 120),
    new(7, "Uncle Bob's Organic Dried Pears", 3, 7, 30.00, 15),
    new(8, "Northwoods Cranberry Sauce", 3, 2, 40.00, 6),
    new(9, "Mishi Kobe Niku", 4, 6, 97.00, 29),
    new(10, "Ikura", 4, 8, 31.00, 31)
};

// ============================================================
// CONSULTAS BÁSICAS
// ============================================================

WriteLine("\n*** Nombre de los productos ***");
var nombres = products
    .Select(p => p.Name);

foreach (var n in nombres)
    WriteLine(n);

WriteLine("\n*** Productos con menos de 10 unidades en stock ***");
var pocoStock = products
    .Where(p => p.UnitsInStock < 10)
    .Select(p => p.Name);

foreach (var n in pocoStock)
    WriteLine(n);

WriteLine("\n*** Productos ordenados por stock ascendente ***");
var ordenStock = products
    .OrderBy(p => p.UnitsInStock);

foreach (var p in ordenStock)
    WriteLine($"{p.Name}: {p.UnitsInStock}");

WriteLine("\n*** Ordenación múltiple: por stock DESC y nombre ASC ***");
var ordenMultiple = products
    .OrderByDescending(p => p.UnitsInStock)
    .ThenBy(p => p.Name);

foreach (var p in ordenMultiple)
    WriteLine($"{p.UnitsInStock} - {p.Name}");

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** Agrupar por proveedor y contar productos ***");
var porProveedor = products
    .GroupBy(p => p.Supplier)
    .ToDictionary(
        g => g.Key, 
        g => g.Count()
    );

foreach (var item in porProveedor)
    WriteLine($"Proveedor {item.Key}: {item.Value} productos");

WriteLine("\n*** Productos agrupados por stock (menos de 20 unidades) ***");
var gruposStock = products
    .Where(p => p.UnitsInStock < 20)
    .GroupBy(p => p.UnitsInStock);

foreach (var grupo in gruposStock)
    WriteLine($"Existencias: {grupo.Key} -> {string.Join(", ", grupo.Select(p => p.Name))}");

WriteLine("\n*** Suma de precios por stock ***");
var sumaPrecios = products
    .GroupBy(p => p.UnitsInStock)
    .ToDictionary(
        g => g.Key, 
        g => g.Sum(p => p.UnitPrice)
    );

foreach (var item in sumaPrecios)
    WriteLine($"Stock {item.Key}: {item.Value:F2}€");

WriteLine("\n*** Promedio de existencias en almacén ***");
var avgStock = products
    .Average(p => p.UnitsInStock);

WriteLine($"Promedio: {avgStock:F2}");

WriteLine("\n*** Producto con mayor precio ***");
var caro = products
    .MaxBy(p => p.UnitPrice);

WriteLine(caro);

WriteLine("\n*** Estadísticas del precio ***");
// Materializamos solo porque recorremos 5 veces la misma proyección de precios.
var precios = products
    .Select(p => p.UnitPrice)
    .ToList();

WriteLine($"Count: {precios.Count}");
WriteLine($"Sum: {precios.Sum():F2}");
WriteLine($"Min: {precios.Min():F2}");
WriteLine($"Max: {precios.Max():F2}");
WriteLine($"Average: {precios.Average():F2}");

WriteLine("\n*** Saltar 5 elementos y mostrar el resto ***");
var resto = products
    .Skip(5);

foreach (var p in resto)
    WriteLine(p);

WriteLine("\n*** Productos de la categoría 3 ***");
var cat3 = products
    .Where(p => p.Category == 3);

foreach (var p in cat3)
    WriteLine(p);

WriteLine("\n=== FIN ===");
