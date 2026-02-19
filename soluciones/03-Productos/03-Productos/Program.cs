using System.Linq;
using static System.Console;
using Productos.Models;

var products = new List<Product>
{
    new(1, "Chai", 1, 1, 18.00, 39),
    new(2, "Chang", 1, 1, 19.00, 17),
    new(3, "Aniseed Syrup", 1, 2, 10.00, 13),
    new(4, "Chef Anton's Cajun Seasoning", 2, 2, 22.00, 53),
    new(5, "Grandma's Boysenberry Spread", 3, 2, 25.00, 120),
    new(6, "Ikura", 4, 3, 31.00, 31),
    new(7, "Queso Cabrales", 5, 3, 21.00, 22),
    new(8, "Queso Manchego La Pastora", 5, 3, 38.00, 86),
    new(9, "Tofu", 6, 3, 23.25, 35),
    new(10, "Pavlova", 7, 3, 17.45, 29),
    new(11, "Alice Mutton", 7, 4, 39.00, 0),
    new(12, "Carnarvon Tigers", 7, 4, 62.50, 42),
    new(13, "Teatime Chocolate Biscuits", 8, 5, 9.20, 25),
    new(14, "Sir Rodney's Marmalade", 8, 5, 81.00, 40),
    new(15, "Sir Rodney's Scones", 8, 5, 10.00, 4),
    new(16, "Gustaf's Knäckebröd", 9, 5, 21.00, 104),
    new(17, "Tunnbröd", 9, 5, 9.00, 61),
    new(18, "Guaraná Fantástica", 10, 1, 4.50, 20),
    new(19, "NuNuCa Nuß-Nougat-Creme", 11, 3, 14.00, 76),
    new(20, "Gumbär Gummibärchen", 11, 3, 31.23, 15),
    new(21, "Schoggi Schokolade", 11, 3, 43.90, 49),
    new(22, "Rössle Sauerkraut", 12, 4, 45.60, 26),
    new(23, "Thüringer Rostbratwurst", 12, 4, 123.79, 0),
    new(24, "Nord-Ost Matjeshering", 13, 4, 25.89, 10),
    new(25, "Gorgonzola Telino", 14, 4, 12.50, 0),
    new(26, "Mascarpone Fabioli", 14, 4, 32.00, 9),
    new(27, "Geitost", 15, 4, 2.50, 112),
    new(28, "Sasquatch Ale", 16, 1, 14.00, 111),
    new(29, "Steeleye Stout", 16, 1, 18.00, 20),
    new(30, "Inlagd Sill", 17, 4, 19.00, 112)
};

// ============================================================
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

// Obtener todos los productos
// SQL: SELECT * FROM Products
WriteLine("*** Todos los productos ***");
products.ForEach(WriteLine);

// Obtener solo los nombres de los productos
// SQL: SELECT Name FROM Products
WriteLine("\n*** Nombre de los productos ***");
var nombres = products.Select(p => p.Name).ToList();

nombres.ForEach(WriteLine);

// Obtener productos con menos de 10 unidades en stock
// SQL: SELECT Name FROM Products WHERE UnitsInStock < 10
WriteLine("\n*** Productos con menos de 10 unidades en stock ***");
var productosStockMenor10 = products
    .Where(p => p.UnitsInStock < 10)
    .Select(p => p.Name)
    .ToList();

productosStockMenor10.ForEach(WriteLine);

// Obtener productos ordenados por stock ascendente
// SQL: SELECT Name FROM Products WHERE UnitsInStock < 10 ORDER BY UnitsInStock ASC
WriteLine("\n*** Productos ordenados por stock ascendente ***");
var productosOrdenadosAsc = products
    .Where(p => p.UnitsInStock < 10)
    .OrderBy(p => p.UnitsInStock)
    .Select(p => p.Name)
    .ToList();

productosOrdenadosAsc.ForEach(WriteLine);

// Obtener productos ordenados por stock descendente
// SQL: SELECT Name FROM Products WHERE UnitsInStock < 10 ORDER BY UnitsInStock DESC
WriteLine("\n*** Productos ordenados por stock descendente ***");
var productosOrdenadosDesc = products
    .Where(p => p.UnitsInStock < 10)
    .OrderByDescending(p => p.UnitsInStock)
    .Select(p => p.Name)
    .ToList();

productosOrdenadosDesc.ForEach(WriteLine);

// Ordenar usando Comparable (IComparable)
// SQL: SELECT Name FROM Products WHERE UnitsInStock < 10 ORDER BY UnitsInStock ASC
WriteLine("\n*** Ordenación con Comparable (uso de IComparable) ***");
var productosComparableAsc = products
    .Where(p => p.UnitsInStock < 10)
    .OrderBy(p => p)
    .Select(p => p.Name)
    .ToList();

productosComparableAsc.ForEach(WriteLine);

// Ordenar por stock descendente y nombre ascendente
// SQL: SELECT Name FROM Products WHERE UnitsInStock < 10 ORDER BY UnitsInStock DESC, Name ASC
WriteLine("\n*** Ordenación múltiple: por stock DESC y nombre ASC ***");
var productosOrdenMultiple1 = products
    .Where(p => p.UnitsInStock < 10)
    .OrderByDescending(p => p.UnitsInStock)
    .ThenBy(p => p.Name)
    .Select(p => p.Name)
    .ToList();

productosOrdenMultiple1.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar por proveedor y contar productos
// SQL: SELECT Supplier, COUNT(*) as Cantidad FROM Products GROUP BY Supplier
WriteLine("\n*** Agrupar por proveedor y contar productos ***");
var agrupadosProveedor = products
    .GroupBy(p => p.Supplier)
    .ToDictionary(g => g.Key, g => g.Count());

agrupadosProveedor.ToList().ForEach(kv => WriteLine($"proveedor: {kv.Key}: productos: {kv.Value}"));

// Agrupar productos con poco stock
// SQL: SELECT UnitsInStock, * FROM Products WHERE UnitsInStock < 20 GROUP BY UnitsInStock
WriteLine("\n*** Productos con menos de 20 unidades agrupados por stock ***");
var agrupadosStock = products
    .Where(p => p.UnitsInStock < 20)
    .GroupBy(p => p.UnitsInStock)
    .ToDictionary(g => g.Key, g => g.ToList());

agrupadosStock.ToList().ForEach(kv => 
    WriteLine($"existencias: {kv.Key} Productos: {string.Join(", ", kv.Value.Select(p => p.Name))}"));

// Sumar precios por stock
// SQL: SELECT UnitsInStock, SUM(UnitPrice) FROM Products GROUP BY UnitsInStock
WriteLine("\n*** Suma de precios por stock ***");
var sumaPorStock = products
    .GroupBy(p => p.UnitsInStock)
    .ToDictionary(g => g.Key, g => g.Sum(p => p.UnitPrice));

sumaPorStock.ToList().ForEach(kv => WriteLine($"en stock: {kv.Key}: suma: {kv.Value:F2}"));

// Obtener grupos con suma mayor a 100 (HAVING)
// SQL: SELECT UnitsInStock, SUM(UnitPrice) FROM Products GROUP BY UnitsInStock HAVING SUM(UnitPrice) > 100
WriteLine("\n*** Having: suma de precios > 100 ***");
var sumaMayor100 = products
    .GroupBy(p => p.UnitsInStock)
    .ToDictionary(g => g.Key, g => g.Sum(p => p.UnitPrice))
    .Where(kv => kv.Value > 100)
    .ToList();

sumaMayor100.ForEach(kv => WriteLine($"en stock: {kv.Key}, suma: {kv.Value:F2}"));

// Calcular el promedio de existencias
// SQL: SELECT AVG(UnitsInStock) FROM Products
WriteLine("\n*** Promedio de existencias en almacén ***");
var promedio = products.Average(p => p.UnitsInStock);

WriteLine($"Promedio: {promedio:F2}");

// Obtener el producto con mayor precio
// SQL: SELECT TOP 1 * FROM Products ORDER BY UnitPrice DESC
WriteLine("\n*** Producto con mayor precio ***");
var productoMaxPrecio = products.MaxBy(p => p.UnitPrice);

WriteLine(productoMaxPrecio);

// Obtener estadísticas del precio
// SQL: SELECT COUNT(UnitPrice), SUM(UnitPrice), MIN(UnitPrice), MAX(UnitPrice), AVG(UnitPrice) FROM Products
WriteLine("\n*** Estadísticas del precio ***");
var precios = products.Select(p => p.UnitPrice).ToList();

WriteLine($"Count: {precios.Count}");
WriteLine($"Sum: {precios.Sum():F2}");
WriteLine($"Min: {precios.Min():F2}");
WriteLine($"Max: {precios.Max():F2}");
WriteLine($"Average: {precios.Average():F2}");

// Limitar resultados a 50
// SQL: SELECT TOP 50 * FROM Products
WriteLine("\n*** Limitar resultados (TOP) ***");
var limit50 = products.Take(50).ToList();

WriteLine($"Productos limitados a 50: {limit50.Count}");

// Saltar los primeros 5 elementos
// SQL: SELECT * FROM Products OFFSET 5
WriteLine("\n*** Saltar elementos (OFFSET) ***");
var skip5 = products.Skip(5).ToList();

skip5.ForEach(WriteLine);

// Obtener los productos de una categoría específica
// SQL: SELECT * FROM Products WHERE Category = 3
WriteLine("\n*** Productos de la categoría 3 ***");
var productosCategoria3 = products
    .Where(p => p.Category == 3)
    .ToList();

productosCategoria3.ForEach(WriteLine);

// Obtener el producto más caro
// SQL: SELECT TOP 1 * FROM Products ORDER BY UnitPrice DESC
WriteLine("\n*** Producto más caro ***");
var productoMasCaro = products
    .OrderByDescending(p => p.UnitPrice)
    .First();

WriteLine(productoMasCaro);

// Obtener el producto con más stock
// SQL: SELECT TOP 1 * FROM Products ORDER BY UnitsInStock DESC
WriteLine("\n*** Producto con más stock ***");
var productoMasStock = products
    .OrderByDescending(p => p.UnitsInStock)
    .First();

WriteLine(productoMasStock);

// Agrupar productos por categoría y mostrar el listado
// SQL: SELECT * FROM Products
WriteLine("\n*** Productos agrupados por categoría ***");
var productosPorCategoria = products
    .GroupBy(p => p.Category)
    .ToList();

productosPorCategoria.ToList().ForEach(g =>
{
    WriteLine($"\nCategoría {g.Key}:");
    g.ToList().ForEach(p => WriteLine($"  - {p.Name}"));
});

// Calcular el precio medio por categoría
// SQL: SELECT Category, AVG(UnitPrice) FROM Products GROUP BY Category
WriteLine("\n*** Precio medio por categoría ***");
var precioMedioPorCategoria = products
    .GroupBy(p => p.Category)
    .ToDictionary(g => g.Key, g => g.Average(p => p.UnitPrice));

precioMedioPorCategoria.ToList().ForEach(kv => WriteLine($"Categoría {kv.Key}: {kv.Value:F2}"));

// Agrupar por categoría y obtener el producto más caro de cada una
// SQL: SELECT * FROM Products p1 WHERE UnitPrice = (SELECT MAX(UnitPrice) FROM Products p2 WHERE p1.Category = p2.Category)
WriteLine("\n*** Producto más caro de cada categoría ***");
var masCaroPorCategoria = products
    .GroupBy(p => p.Category)
    .Select(g => g.MaxBy(p => p.UnitPrice))
    .ToList();

masCaroPorCategoria.ForEach(WriteLine);

// Agrupar por categoría: producto más caro y más barato
// SQL: SELECT Category, MAX(UnitPrice), MIN(UnitPrice) FROM Products GROUP BY Category
WriteLine("\n*** Producto más caro y más barato por categoría ***");
var caroBaratoPorCategoria = products
    .GroupBy(p => p.Category)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MasCaro = g.MaxBy(p => p.UnitPrice).Name,
            PrecioCaro = g.Max(p => p.UnitPrice),
            MasBarato = g.MinBy(p => p.UnitPrice).Name,
            PrecioBarato = g.Min(p => p.UnitPrice)
        }
    );

caroBaratoPorCategoria.ToList().ForEach(kv =>
    WriteLine($"Categoría {kv.Key}: Más caro={kv.Value.MasCaro} ({kv.Value.PrecioCaro:F2}), Más barato={kv.Value.MasBarato} ({kv.Value.PrecioBarato:F2})"));

// Agrupar por categoría: estadísticas completas
// SQL: SELECT Category, MAX(UnitPrice), MIN(UnitPrice), AVG(UnitPrice), COUNT(*), SUM(UnitsInStock) FROM Products GROUP BY Category
WriteLine("\n*** Estadísticas completas por categoría ***");
var estadisticasPorCategoria = products
    .GroupBy(p => p.Category)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MaxPrecio = g.Max(p => p.UnitPrice),
            MinPrecio = g.Min(p => p.UnitPrice),
            MediaPrecio = g.Average(p => p.UnitPrice),
            Cantidad = g.Count(),
            TotalStock = g.Sum(p => p.UnitsInStock)
        }
    );

estadisticasPorCategoria.ToList().ForEach(kv =>
    WriteLine($"Categoría {kv.Key}: Max={kv.Value.MaxPrecio:F2}, Min={kv.Value.MinPrecio:F2}, Media={kv.Value.MediaPrecio:F2}, Cantidad={kv.Value.Cantidad}, Stock={kv.Value.TotalStock}"));

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar los primeros 5 productos
// SQL: SELECT TOP 5 * FROM Products
WriteLine("\n*** Primeros 5 productos ***");
var primeros5 = products.Take(5).ToList();

primeros5.ForEach(WriteLine);

// Paginación: mostrar los siguientes 5 productos
// SQL: SELECT * FROM Products OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Siguientes 5 productos ***");
var siguientes5 = products.Skip(5).Take(5).ToList();

siguientes5.ForEach(WriteLine);

// Paginación: últimos 5 productos
// SQL: SELECT * FROM Products OFFSET 25 ROWS
WriteLine("\n*** Últimos 5 productos ***");
var ultimos5 = products.Skip(25).Take(5).ToList();

ultimos5.ForEach(WriteLine);

// Verificar si existe algún producto con precio mayor a 100
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Products WHERE UnitPrice > 100) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún producto con precio mayor a 100? ***");
var hayCaros = products.Any(p => p.UnitPrice > 100);

WriteLine(hayCaros ? "Sí, hay productos caros" : "No hay productos caros");

// Verificar si todos los productos tienen stock
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Products WHERE UnitsInStock > 0) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los productos tienen stock? ***");
var todosConStock = products.All(p => p.UnitsInStock > 0);

WriteLine(todosConStock ? "Sí, todos tienen stock" : "Algunos no tienen stock");

// Obtener el producto más barato
// SQL: SELECT TOP 1 * FROM Products ORDER BY UnitPrice ASC
WriteLine("\n*** El producto más barato ***");
var productoMasBarato = products.MinBy(p => p.UnitPrice);

WriteLine(productoMasBarato);

// Obtener el valor total del inventario
// SQL: SELECT SUM(UnitPrice * UnitsInStock) FROM Products
WriteLine("\n*** Valor total del inventario ***");
var valorTotal = products.Sum(p => p.UnitPrice * p.UnitsInStock);

WriteLine($"Valor total: {valorTotal:C2}");

// Obtener productos sin stock
// SQL: SELECT * FROM Products WHERE UnitsInStock = 0
WriteLine("\n*** Productos sin stock ***");
var sinStock = products.Where(p => p.UnitsInStock == 0).ToList();

sinStock.ForEach(WriteLine);

// Obtener categorías únicas
// SQL: SELECT DISTINCT Category FROM Products
WriteLine("\n*** Categorías únicas ***");
var categoriasUnicas = products.Select(p => p.Category).Distinct().ToList();

categoriasUnicas.ForEach(c => WriteLine($"Categoría {c}"));

// Obtener el stock total
// SQL: SELECT SUM(UnitsInStock) FROM Products
WriteLine("\n*** Stock total ***");
var stockTotal = products.Sum(p => p.UnitsInStock);

WriteLine($"Stock total: {stockTotal} unidades");

// Productos ordenados por precio (página 1 de 5 en 5)
// SQL: SELECT * FROM Products ORDER BY UnitPrice OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Productos ordenados por precio ( página 1) ***");
var porPrecioPag1 = products.OrderBy(p => p.UnitPrice).Take(5).ToList();

porPrecioPag1.ForEach(WriteLine);

WriteLine("\n*** Productos ordenados por precio ( página 2) ***");
var porPrecioPag2 = products.OrderBy(p => p.UnitPrice).Skip(5).Take(5).ToList();

porPrecioPag2.ForEach(WriteLine);

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Productos con precio mayor a 20 Y stock menor a 30
// SQL: SELECT * FROM Products WHERE UnitPrice > 20 AND UnitsInStock < 30
WriteLine("\n*** Precio > 20 y stock < 30 ***");
var precioAltoStockBajo = products
    .Where(p => p.UnitPrice > 20 && p.UnitsInStock < 30)
    .ToList();

precioAltoStockBajo.ForEach(WriteLine);

// Productos de categoría 1 O 2
// SQL: SELECT * FROM Products WHERE Category IN (1, 2)
WriteLine("\n*** Productos de categoría 1 o 2 ***");
var categorias = new[] { 1, 2 };
var productosCat12 = products
    .Where(p => categorias.Contains(p.Category))
    .ToList();

productosCat12.ForEach(WriteLine);

// Productos con stock entre 10 y 50 unidades
// SQL: SELECT * FROM Products WHERE UnitsInStock BETWEEN 10 AND 50
WriteLine("\n*** Stock entre 10 y 50 unidades ***");
var stockEntre = products
    .Where(p => p.UnitsInStock >= 10 && p.UnitsInStock <= 50)
    .ToList();

stockEntre.ForEach(WriteLine);

// Productos cuyo nombre contiene 'Syrup' O 'Chai'
// SQL: SELECT * FROM Products WHERE Name LIKE '%Syrup%' OR Name LIKE '%Chai%'
WriteLine("\n*** Nombre contiene 'Syrup' o 'Chai' ***");
var nombresIncluidos = new[] { "Syrup", "Chai" };
var productosConNombre = products
    .Where(p => nombresIncluidos.Any(n => p.Name.Contains(n, StringComparison.OrdinalIgnoreCase)))
    .ToList();

productosConNombre.ForEach(WriteLine);

// Productos con precio menor a 10 O stock igual a 0
// SQL: SELECT * FROM Products WHERE UnitPrice < 10 OR UnitsInStock = 0
WriteLine("\n*** Precio < 10 o sin stock ***");
var precioBajoOSinStock = products
    .Where(p => p.UnitPrice < 10 || p.UnitsInStock == 0)
    .ToList();

precioBajoOSinStock.ForEach(WriteLine);

// Productos de proveedor 1, 5 o 8
// SQL: SELECT * FROM Products WHERE Supplier IN (1, 5, 8)
WriteLine("\n*** Proveedor 1, 5 o 8 ***");
var proveedores = new[] { 1, 5, 8 };
var productosProveedor = products
    .Where(p => proveedores.Contains(p.Supplier))
    .ToList();

productosProveedor.ForEach(WriteLine);

// Productos con precio entre 15 y 30 Y stock mayor a 20
// SQL: SELECT * FROM Products WHERE UnitPrice BETWEEN 15 AND 30 AND UnitsInStock > 20
WriteLine("\n*** Precio 15-30 y stock > 20 ***");
var precioRangoStockAlto = products
    .Where(p => p.UnitPrice >= 15 && p.UnitPrice <= 30 && p.UnitsInStock > 20)
    .ToList();

precioRangoStockAlto.ForEach(WriteLine);

// Múltiples Where encadenados
// SQL: SELECT * FROM Products WHERE Category = 3 ORDER BY UnitPrice DESC
WriteLine("\n*** Múltiples Where: categoría 3 y precio > 25 ***");
var multiplesWhere = products
    .Where(p => p.Category == 3)
    .Where(p => p.UnitPrice > 25)
    .OrderByDescending(p => p.UnitPrice)
    .ToList();

multiplesWhere.ForEach(WriteLine);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: nombre y precio con formato
// SQL: SELECT Name, UnitPrice FROM Products
WriteLine("\n*** Proyección: nombre y precio con formato ***");
var proyeccionesNombrePrecio = products
    .Select(p => new { p.Name, Precio = $"{p.UnitPrice:C2}" })
    .ToList();

proyeccionesNombrePrecio.ForEach(p => WriteLine($"{p.Name}: {p.Precio}"));

// Proyección: clasificar productos por precio
// SQL: SELECT Name, UnitPrice, CASE WHEN UnitPrice > 30 THEN 'Caro' WHEN UnitPrice > 15 THEN 'Medio' ELSE 'Barato' END as Categoria FROM Products
WriteLine("\n*** Proyección: clasificación por precio ***");
var clasificacionPrecio = products
    .Select(p => new 
    { 
        p.Name, 
        p.UnitPrice,
        Categoria = p.UnitPrice > 30 ? "Caro" : (p.UnitPrice > 15 ? "Medio" : "Barato")
    })
    .ToList();

clasificacionPrecio.ForEach(c => WriteLine($"{c.Name}: {c.UnitPrice:C2} - {c.Categoria}"));

// Proyección: información de inventario
// SQL: SELECT Name, UnitPrice, UnitsInStock, (UnitPrice * UnitsInStock) as ValorTotal FROM Products
WriteLine("\n*** Proyección: valor total del inventario por producto ***");
var valorInventario = products
    .Select(p => new 
    { 
        p.Name, 
        p.UnitPrice, 
        p.UnitsInStock,
        ValorTotal = p.UnitPrice * p.UnitsInStock
    })
    .ToList();

valorInventario.ForEach(v => WriteLine($"{v.Name}: {v.UnitPrice:C2} x {v.UnitsInStock} = {v.ValorTotal:C2}"));

// Proyección: estadísticas por proveedor
// SQL: SELECT Supplier, COUNT(*) as Cantidad, AVG(UnitPrice) as Media, SUM(UnitsInStock) as StockTotal FROM Products GROUP BY Supplier
WriteLine("\n*** Proyección: estadísticas por proveedor ***");
var estadisticasProveedor = products
    .GroupBy(p => p.Supplier)
    .ToDictionary(
        g => g.Key,
        g => new 
        { 
            Cantidad = g.Count(),
            PrecioMedio = g.Average(p => p.UnitPrice),
            StockTotal = g.Sum(p => p.UnitsInStock),
            ValorTotal = g.Sum(p => p.UnitPrice * p.UnitsInStock)
        }
    );

estadisticasProveedor.ToList().ForEach(kv => WriteLine($"Proveedor {kv.Key}: {kv.Value.Cantidad} productos, Media={kv.Value.PrecioMedio:C2}, Stock={kv.Value.StockTotal}, Valor={kv.Value.ValorTotal:C2}"));

// Proyección: filtrar Y proyectar
// SQL: SELECT Name, UnitPrice, UnitsInStock FROM Products WHERE UnitPrice > 20
WriteLine("\n*** Filtrar y proyectar: productos caros ***");
var filtroProyeccion = products
    .Where(p => p.UnitPrice > 20)
    .Select(p => new { p.Name, p.UnitPrice, p.UnitsInStock })
    .ToList();

filtroProyeccion.ForEach(p => WriteLine($"{p.Name}: {p.UnitPrice:C2}, Stock: {p.UnitsInStock}"));

// Proyección: productos con descuento potencial
// SQL: SELECT Name, UnitPrice, UnitsInStock, CASE WHEN UnitsInStock < 20 THEN 'Pedir' ELSE 'OK' END as Estado FROM Products
WriteLine("\n*** Proyección: estado de reorder ***");
var estadoReorder = products
    .Select(p => new 
    { 
        p.Name, 
        p.UnitPrice, 
        p.UnitsInStock,
        Estado = p.UnitsInStock < 20 ? "Pedir" : "OK"
    })
    .ToList();

estadoReorder.ForEach(e => WriteLine($"{e.Name}: Stock={e.UnitsInStock}, {e.Estado}"));

// Proyección: resumen por categoría
// SQL: SELECT Category, MAX(UnitPrice) as Maximo, MIN(UnitPrice) as Minimo, AVG(UnitPrice) as Media FROM Products GROUP BY Category
WriteLine("\n*** Proyección: precio máximo, mínimo y medio por categoría ***");
var resumenCategoria = products
    .GroupBy(p => p.Category)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Maximo = g.Max(p => p.UnitPrice),
            Minimo = g.Min(p => p.UnitPrice),
            Media = g.Average(p => p.UnitPrice),
            Productos = g.Count()
        }
    );

resumenCategoria.ToList().ForEach(kv => WriteLine($"Categoría {kv.Key}: Max={kv.Value.Maximo:C2}, Min={kv.Value.Minimo:C2}, Media={kv.Value.Media:C2}, Productos={kv.Value.Productos}"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = products.Where(p => p.UnitPrice > 20);
    products.Add(new Product(31, "Nuevo", 1, 1, 25.00, 50)); // ¡No ejecutada!
    consulta.ForEach(...); // AHORA se ejecuta

CON .ToList():
    var consulta = products.Where(p => p.UnitPrice > 20).ToList();
    products.Add(new Product(31, "Nuevo", 1, 1, 25.00, 50));
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
var consultaDiferida = products.Where(p => p.UnitPrice > 20);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Productos encontrados: {consultaDiferida.Count()}");

products.Add(new Product(31, "Nuevo Producto", 1, 1, 30.00, 100));
WriteLine("Nuevo producto agregado");

WriteLine($"Productos encontrados: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces

// Ejemplo con .ToList()
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = products.Where(p => p.UnitPrice > 20).ToList();
WriteLine("Consulta ejecutada con .ToList()");

products.Add(new Product(32, "Otro Nuevo", 1, 1, 35.00, 80));
WriteLine("Nuevo producto agregado");

WriteLine($"Productos en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
