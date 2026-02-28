using System.Linq;
using static System.Console;
using Relaciones.Models;

var grupos = new List<Grupo>
{
    new(1, "Bon Jovi"),
    new(2, "Keith Urban"),
    new(3, "Bryan Adams"),
    new(4, "Black Sabbath"),
    new(5, "Europe"),
    new(6, "Brad Paisley"),
    new(7, "Amadeus")
};

var canciones = new List<Cancion>
{
    // Bon Jovi
    new(1, "Livin' on Prayer", 1, 250),
    new(2, "It's my Life", 1, 245),
    new(3, "You Give Love a Bad Name", 1, 255),
    new(4, "Wanted Dead or Alive", 1, 330),
    new(5, "Always", 1, 320),
    new(6, "Bed of Roses", 1, 350),
    // Keith Urban
    new(7, "Long Hot Summer", 2, 245),
    new(8, "Someone Like You", 2, 284),
    new(9, "Blue Ain't Your Color", 2, 216),
    // Bryan Adams
    new(10, "Run To You", 3, 300),
    new(11, "Summer of 69", 3, 240),
    new(12, "Heaven", 3, 240),
    new(13, "Everything I Do", 3, 427),
    // Black Sabbath
    new(14, "Paranoid", 4, 180),
    new(15, "Iron Man", 4, 352),
    new(16, "War Pigs", 4, 467),
    // Europe
    new(17, "Cherokee", 5, 300),
    new(18, "The Final Countdown", 5, 301),
    new(19, "Carrie", 5, 269),
    // Brad Paisley
    new(20, "River Bank", 6, 220),
    new(21, "She's Everything", 6, 258),
    new(22, "Whiskey Lullaby", 6, 420),
    // Amadeus
    new(23, "Dolor Fantasma", 7, 210),
    new(24, "Nunca más", 7, 245),
    new(25, "El barco de Papel", 7, 198),
    new(26, "Juliete", 7, 275),
    new(27, "El Cabello de Ángel", 7, 320)
};

var categorias = new List<Categoria>
{
    new(1, "Electrónica"),
    new(2, "Ropa"),
    new(3, "Alimentación"),
    new(4, "Deportes"),
    new(5, "Libros")
};

var productos = new List<Producto>
{
    new(1, "Portátil", 1, 999.99, 15),
    new(2, "Móvil", 1, 599.00, 25),
    new(3, "Auriculares", 1, 79.90, 50),
    new(4, "Camiseta", 2, 19.99, 100),
    new(5, "Pantalón", 2, 39.99, 75),
    new(6, "Chaqueta", 2, 89.99, 30),
    new(7, "Pan", 3, 1.50, 200),
    new(8, "Leche", 3, 1.20, 150),
    new(9, "Queso", 3, 8.50, 40),
    new(10, "Balón", 4, 25.00, 60),
    new(11, "Raqueta", 4, 89.99, 20),
    new(12, "Zapatillas", 4, 79.99, 45),
    new(13, "Novela", 5, 19.90, 80),
    new(14, "Diccionario", 5, 35.00, 15),
    new(15, "Cómic", 5, 12.90, 120)
};

// ============================================================
// CONSULTAS DE UNIÓN (JOIN)
// ============================================================

// Obtener todas las canciones con su nombre de grupo
// SQL: SELECT c.Titulo, g.Nombre FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id
WriteLine("*** Todas las canciones con su grupo ***");
var cancionesConGrupo = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { c.Titulo, c.Duracion, Grupo = g.Nombre })
    .ToList();

cancionesConGrupo.ForEach(x => WriteLine($"{x.Titulo} - {x.Grupo} ({x.Duracion}s)"));

// Obtener las canciones del grupo Rock
// SQL: SELECT c.Titulo FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id WHERE g.Nombre = 'Rock'
WriteLine("\n*** Canciones del grupo Rock ***");
var cancionesRock = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { c.Titulo, c.Duracion, Grupo = g.Nombre })
    .Where(x => x.Grupo == "Rock")
    .ToList();

cancionesRock.ForEach(x => WriteLine($"{x.Titulo} ({x.Duracion}s)"));

// Obtener la canción más larga de cada grupo
// SQL: SELECT g.Nombre, c.Titulo FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id
//      WHERE c.Duracion = (SELECT MAX(Duracion) FROM Canciones WHERE GrupoId = c.GrupoId)
WriteLine("\n*** Canción más larga de cada grupo ***");
var masLargaPorGrupo = grupos
    .Join(canciones, g => g.Id, c => c.GrupoId, (g, c) => new { g.Nombre, c.Titulo, c.Duracion })
    .GroupBy(x => x.Nombre)
    .Select(g => g.MaxBy(x => x.Duracion))
    .ToList();

masLargaPorGrupo.ForEach(x => WriteLine($"{x.Nombre}: {x.Titulo} ({x.Duracion}s)"));

// Contar canciones por grupo
// SQL: SELECT g.Nombre, COUNT(*) FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id GROUP BY g.Nombre
WriteLine("\n*** Cantidad de canciones por grupo ***");
var cantidadPorGrupo = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Count());

cantidadPorGrupo.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} canciones"));

// Duración total por grupo
// SQL: SELECT g.Nombre, SUM(c.Duracion) FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id GROUP BY g.Nombre
WriteLine("\n*** Duración total por grupo ***");
var duracionTotalGrupo = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre, c.Duracion })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Sum(x => x.Duracion));

duracionTotalGrupo.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value / 60.0:F1} minutos"));

// Duración media por grupo
// SQL: SELECT g.Nombre, AVG(c.Duracion) FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id GROUP BY g.Nombre
WriteLine("\n*** Duración media por grupo ***");
var duracionMediaGrupo = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre, c.Duracion })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Average(x => x.Duracion));

duracionMediaGrupo.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value:F1} segundos"));

// Obtener todos los productos con su categoría
// SQL: SELECT p.Nombre, c.Nombre FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id
WriteLine("\n*** Todos los productos con su categoría ***");
var productosConCategoria = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
    .ToList();

productosConCategoria.ForEach(x => WriteLine($"{x.Nombre} - {x.Categoria} ({x.Precio:C2})"));

// Obtener los productos de Electrónica
// SQL: SELECT p.Nombre FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id WHERE c.Nombre = 'Electrónica'
WriteLine("\n*** Productos de Electrónica ***");
var productosElectronica = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
    .Where(x => x.Categoria == "Electrónica")
    .ToList();

productosElectronica.ForEach(x => WriteLine($"{x.Nombre} ({x.Precio:C2})"));

// Obtener el producto más caro de cada categoría
// SQL: SELECT c.Nombre, p.Nombre FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id
//      WHERE p.Precio = (SELECT MAX(Precio) FROM Productos WHERE CategoriaId = p.CategoriaId)
WriteLine("\n*** Producto más caro de cada categoría ***");
var masCaroPorCategoria = categorias
    .Join(productos, c => c.Id, p => p.CategoriaId, (c, p) => new { Categoria = c.Nombre, Producto = p.Nombre, p.Precio })
    .GroupBy(x => x.Categoria)
    .Select(g => g.MaxBy(x => x.Precio))
    .ToList();

masCaroPorCategoria.ForEach(x => WriteLine($"{x.Categoria}: {x.Producto} ({x.Precio:C2})"));

// Contar productos por categoría
// SQL: SELECT c.Nombre, COUNT(*) FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id GROUP BY c.Nombre
WriteLine("\n*** Cantidad de productos por categoría ***");
var cantidadPorCategoria = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { c.Nombre })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Count());

cantidadPorCategoria.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} productos"));

// Precio medio por categoría
// SQL: SELECT c.Nombre, AVG(p.Precio) FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id GROUP BY c.Nombre
WriteLine("\n*** Precio medio por categoría ***");
var precioMedioCategoria = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { c.Nombre, p.Precio })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Average(x => x.Precio));

precioMedioCategoria.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value:C2}"));

// Stock total por categoría
// SQL: SELECT c.Nombre, SUM(p.Stock) FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id GROUP BY c.Nombre
WriteLine("\n*** Stock total por categoría ***");
var stockPorCategoria = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { c.Nombre, p.Stock })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Sum(x => x.Stock));

stockPorCategoria.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} unidades"));

// Estadísticas completas por grupo
// SQL: SELECT g.Nombre, COUNT(*), SUM(c.Duracion), AVG(c.Duracion), MAX(c.Duracion), MIN(c.Duracion)
//      FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id GROUP BY g.Nombre
WriteLine("\n*** Estadísticas completas por grupo ***");
var estadisticasGrupos = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre, c.Duracion })
    .GroupBy(x => x.Nombre)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Cantidad = g.Count(),
            Total = g.Sum(x => x.Duracion),
            Media = g.Average(x => x.Duracion),
            Max = g.Max(x => x.Duracion),
            Min = g.Min(x => x.Duracion)
        }
    );

estadisticasGrupos.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Cant={kv.Value.Cantidad}, Total={kv.Value.Total}s, Media={kv.Value.Media:F1}s, Max={kv.Value.Max}s, Min={kv.Value.Min}s"));

// Estadísticas completas por categoría
// SQL: SELECT c.Nombre, COUNT(*), SUM(p.Stock), AVG(p.Precio), MAX(p.Precio), MIN(p.Precio)
//      FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id GROUP BY c.Nombre
WriteLine("\n*** Estadísticas completas por categoría ***");
var estadisticasCategorias = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { c.Nombre, p.Precio, p.Stock })
    .GroupBy(x => x.Nombre)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Cantidad = g.Count(),
            StockTotal = g.Sum(x => x.Stock),
            PrecioMedio = g.Average(x => x.Precio),
            PrecioMax = g.Max(x => x.Precio),
            PrecioMin = g.Min(x => x.Precio)
        }
    );

estadisticasCategorias.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Cant={kv.Value.Cantidad}, Stock={kv.Value.StockTotal}, Media={kv.Value.PrecioMedio:C2}, Max={kv.Value.PrecioMax:C2}, Min={kv.Value.PrecioMin:C2}"));

// Grupos que tienen más de 2 canciones
// SQL: SELECT g.Nombre FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id GROUP BY g.Nombre HAVING COUNT(*) > 2
WriteLine("\n*** Grupos con más de 2 canciones ***");
var gruposConMasDe2 = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre })
    .GroupBy(x => x.Nombre)
    .ToDictionary(g => g.Key, g => g.Count())
    .Where(kv => kv.Value > 2)
    .ToList();

gruposConMasDe2.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} canciones"));

// LEFT JOIN: Todos los grupos aunque no tengan canciones
// SQL: SELECT g.Nombre, COUNT(c.Id) FROM Grupos g LEFT JOIN Canciones c ON g.Id = c.GrupoId GROUP BY g.Nombre
WriteLine("\n*** Todos los grupos (incluyendo los sin canciones) ***");
var todosLosGrupos = grupos
    .GroupJoin(canciones, g => g.Id, c => c.GrupoId, (g, cs) => new { Grupo = g.Nombre, Cantidad = cs.Count() })
    .ToList();

todosLosGrupos.ForEach(x => WriteLine($"{x.Grupo}: {x.Cantidad} canciones"));

// LEFT JOIN: Todas las categorías aunque no tengan productos
WriteLine("\n*** Todas las categorías (incluyendo las sin productos) ***");
var todasLasCategorias = categorias
    .GroupJoin(productos, c => c.Id, p => p.CategoriaId, (c, ps) => new { Categoria = c.Nombre, Cantidad = ps.Count() })
    .ToList();

todasLasCategorias.ForEach(x => WriteLine($"{x.Categoria}: {x.Cantidad} productos"));

// ============================================
// CONSULTAS CON SUBCONSULTAS
// ============================================

// Obtener canciones cuya duración es mayor que la duración media de todas las canciones (subconsulta)
// SQL: SELECT * FROM Canciones WHERE Duracion > (SELECT AVG(Duracion) FROM Canciones)
WriteLine("\n*** Canciones más largas que la media (subconsulta) ***");
var duracionMediaTotal = canciones.Average(c => c.Duracion);
var cancionesMayorMedia = canciones
    .Where(c => c.Duracion > duracionMediaTotal)
    .ToList();

cancionesMayorMedia.ForEach(x => WriteLine($"{x.Titulo} ({x.Duracion}s)"));

// Obtener grupos cuya suma de duración es mayor a 600 (subconsulta en HAVING)
// SQL: SELECT g.Nombre FROM Grupos g 
//      INNER JOIN Canciones c ON g.Id = c.GrupoId 
//      GROUP BY g.Nombre 
//      HAVING SUM(c.Duracion) > (SELECT AVG(Duracion) FROM Canciones)
WriteLine("\n*** Grupos con duración total mayor a la media (subconsulta) ***");
var duracionMediaCanciones = canciones.Average(c => c.Duracion);
var gruposDuracionMayor = grupos
    .Select(g => new
    {
        g.Nombre,
        TotalDuracion = canciones.Where(c => c.GrupoId == g.Id).Sum(c => c.Duracion)
    })
    .Where(x => x.TotalDuracion > duracionMediaCanciones * 3)
    .ToList();

gruposDuracionMayor.ForEach(x => WriteLine($"{x.Nombre}: {x.TotalDuracion}s"));

// Obtener productos con precio mayor al precio medio de su categoría (subconsulta)
// SQL: SELECT p.Nombre, p.Precio FROM Productos p 
//      WHERE p.Precio > (SELECT AVG(Precio) FROM Productos WHERE CategoriaId = p.CategoriaId)
WriteLine("\n*** Productos con precio mayor a la media de su categoría (subconsulta) ***");
var productosSobreMediaCategoria = productos
    .Select(p => new
    {
        p.Nombre,
        p.Precio,
        CategoriaId = p.CategoriaId,
        MediaCategoria = productos.Where(p2 => p2.CategoriaId == p.CategoriaId).Average(p2 => p2.Precio)
    })
    .Where(x => x.Precio > x.MediaCategoria)
    .ToList();

productosSobreMediaCategoria.ForEach(x => WriteLine($"{x.Nombre} ({x.Precio:C2}) - Media categoría: {x.MediaCategoria:C2}"));

// Obtener categorías con más productos que el promedio (subconsulta)
// SQL: SELECT c.Nombre FROM Categorias c
//      WHERE (SELECT COUNT(*) FROM Productos WHERE CategoriaId = c.Id) > 
//            (SELECT COUNT(*) FROM Productos) / (SELECT COUNT(*) FROM Categorias)
WriteLine("\n*** Categorías con más productos que el promedio (subconsulta) ***");
var promedioProductos = productos.Count / (double)categorias.Count;
var categoriasSobrePromedio = categorias
    .Select(c => new
    {
        c.Nombre,
        Cantidad = productos.Count(p => p.CategoriaId == c.Id)
    })
    .Where(x => x.Cantidad > promedioProductos)
    .ToList();

categoriasSobrePromedio.ForEach(x => WriteLine($"{x.Nombre}: {x.Cantidad} productos"));

// Obtener la canción más larga de cada grupo (subconsulta con MAX)
// SQL: SELECT c.Titulo, c.Duracion FROM Canciones c
//      WHERE c.Duracion = (SELECT MAX(Duracion) FROM Canciones WHERE GrupoId = c.GrupoId)
WriteLine("\n*** Canción más larga de cada grupo (subconsulta) ***");
var cancionMasLargaCadaGrupo = grupos
    .Select(g => new
    {
        Grupo = g.Nombre,
        MaxDuracion = canciones.Where(c => c.GrupoId == g.Id).Max(c => c.Duracion)
    })
    .ToList();

cancionMasLargaCadaGrupo.ForEach(x =>
{
    var cancion = canciones.First(c => c.GrupoId == grupos.First(g => g.Nombre == x.Grupo).Id && c.Duracion == x.MaxDuracion);
    WriteLine($"{x.Grupo}: {cancion.Titulo} ({x.MaxDuracion}s)");
});

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Canciones de Bon Jovi con duración mayor a 250 segundos
// SQL: SELECT c.Titulo, c.Duracion FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id WHERE g.Nombre = 'Bon Jovi' AND c.Duracion > 250
WriteLine("\n*** Canciones de Bon Jovi con duración > 250s ***");
var bonJoviLargas = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { c.Titulo, c.Duracion, Grupo = g.Nombre })
    .Where(x => x.Grupo == "Bon Jovi" && x.Duracion > 250)
    .ToList();

bonJoviLargas.ForEach(x => WriteLine($"{x.Titulo} ({x.Duracion}s)"));

// Productos de Electrónica con precio mayor a 200
// SQL: SELECT p.Nombre, p.Precio FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id WHERE c.Nombre = 'Electrónica' AND p.Precio > 200
WriteLine("\n*** Electrónica con precio > 200 ***");
var electronicaCara = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
    .Where(x => x.Categoria == "Electrónica" && x.Precio > 200)
    .ToList();

electronicaCara.ForEach(x => WriteLine($"{x.Nombre} ({x.Precio:C2})"));

// Canciones de grupos con más de 3 canciones
// SQL: SELECT g.Nombre, c.Titulo FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id WHERE g.Nombre IN (SELECT g2.Nombre FROM Canciones c2 INNER JOIN Grupos g2 ON c2.GrupoId = g2.Id GROUP BY g2.Nombre HAVING COUNT(*) > 3)
WriteLine("\n*** Canciones de grupos con más de 3 canciones ***");
var gruposConMasDe3 = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { g.Nombre })
    .GroupBy(x => x.Nombre)
    .Where(g => g.Count() > 3)
    .Select(g => g.Key)
    .ToList();

var cancionesGruposPopulares = gruposConMasDe3
    .SelectMany(g => canciones.Where(c => c.GrupoId == grupos.First(gr => gr.Nombre == g).Id))
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { c.Titulo, Grupo = g.Nombre })
    .ToList();

cancionesGruposPopulares.ForEach(x => WriteLine($"{x.Titulo} - {x.Grupo}"));

// Productos con stock entre 20 y 100 unidades
// SQL: SELECT p.Nombre, p.Stock FROM Productos p WHERE p.Stock BETWEEN 20 AND 100
WriteLine("\n*** Stock entre 20 y 100 unidades ***");
var stockMedio = productos
    .Where(p => p.Stock >= 20 && p.Stock <= 100)
    .ToList();

stockMedio.ForEach(x => WriteLine($"{x.Nombre}: {x.Stock} unidades"));

// LEFT JOIN con filtrado: grupos sin canciones O con más de 3
// SQL: SELECT g.Nombre, COUNT(c.Id) as Cantidad FROM Grupos g LEFT JOIN Canciones c ON g.Id = c.GrupoId GROUP BY g.Nombre HAVING COUNT(c.Id) = 0 OR COUNT(c.Id) > 3
WriteLine("\n*** Grupos sin canciones o con más de 3 ***");
var gruposEspeciales = grupos
    .GroupJoin(canciones, g => g.Id, c => c.GrupoId, (g, cs) => new { Grupo = g.Nombre, Cantidad = cs.Count() })
    .Where(x => x.Cantidad == 0 || x.Cantidad > 3)
    .ToList();

gruposEspeciales.ForEach(x => WriteLine($"{x.Grupo}: {x.Cantidad} canciones"));

// Múltiples Where encadenados en JOIN
// SQL: SELECT p.Nombre, p.Precio, p.Stock FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id WHERE c.Nombre = 'Electrónica' ORDER BY p.Precio DESC
WriteLine("\n*** Electrónica ordenada por precio (múltiples where) ***");
var multiplesWhere = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, p.Stock, Categoria = c.Nombre })
    .Where(x => x.Categoria == "Electrónica")
    .Where(x => x.Precio > 100)
    .OrderByDescending(x => x.Precio)
    .ToList();

multiplesWhere.ForEach(x => WriteLine($"{x.Nombre}: {x.Precio:C2}"));

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: canciones con información completa
// SQL: SELECT c.Titulo, c.Duracion, g.Nombre as Grupo FROM Canciones c INNER JOIN Grupos g ON c.GrupoId = g.Id
WriteLine("\n*** Proyección: canciones con grupo ***");
var proyeccionCanciones = canciones
    .Join(grupos, c => c.GrupoId, g => g.Id, (c, g) => new { c.Titulo, c.Duracion, Grupo = g.Nombre })
    .ToList();

proyeccionCanciones.ForEach(x => WriteLine($"{x.Titulo} - {x.Grupo} ({x.Duracion}s)"));

// Proyección: clasificar canciones por duración
// SQL: SELECT c.Titulo, c.Duracion, CASE WHEN c.Duracion > 300 THEN 'Larga' WHEN c.Duracion > 240 THEN 'Media' ELSE 'Corta' END as Tipo FROM Canciones
WriteLine("\n*** Proyección: clasificación por duración ***");
var clasificacionCanciones = canciones
    .Select(c => new 
    { 
        c.Titulo, 
        c.Duracion,
        Tipo = c.Duracion > 300 ? "Larga" : (c.Duracion > 240 ? "Media" : "Corta")
    })
    .ToList();

clasificacionCanciones.ForEach(x => WriteLine($"{x.Titulo}: {x.Duracion}s - {x.Tipo}"));

// Proyección: productos con valor de inventario
// SQL: SELECT p.Nombre, p.Precio, p.Stock, (p.Precio * p.Stock) as ValorTotal FROM Productos
WriteLine("\n*** Proyección: valor total del inventario por producto ***");
var valorInventario = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new 
    { 
        p.Nombre, 
        p.Precio, 
        p.Stock, 
        Categoria = c.Nombre,
        ValorTotal = p.Precio * p.Stock
    })
    .ToList();

valorInventario.ForEach(x => WriteLine($"{x.Nombre} ({x.Categoria}): {x.Precio:C2} x {x.Stock} = {x.ValorTotal:C2}"));

// Proyección: estadísticas de grupos
// SQL: SELECT g.Nombre, COUNT(c.Id) as Cantidad, SUM(c.Duracion) as Total, AVG(c.Duracion) as Media FROM Grupos g LEFT JOIN Canciones c ON g.Id = c.GrupoId GROUP BY g.Nombre
WriteLine("\n*** Proyección: estadísticas de grupos ***");
var estadisticasGruposProyeccion = grupos
    .GroupJoin(canciones, g => g.Id, c => c.GrupoId, (g, cs) => new 
    { 
        Grupo = g.Nombre, 
        Cantidad = cs.Count(),
        DuracionTotal = cs.Sum(c => c.Duracion),
        DuracionMedia = cs.Average(c => c.Duracion)
    })
    .ToList();

estadisticasGruposProyeccion.ForEach(x => 
    WriteLine($"{x.Grupo}: {x.Cantidad} canciones, Total={x.DuracionTotal}s, Media={x.DuracionMedia:F1}s"));

// Proyección: filtrar Y proyectar en JOIN
// SQL: SELECT p.Nombre, p.Precio, c.Nombre as Categoria FROM Productos p INNER JOIN Categorias c ON p.CategoriaId = c.Id WHERE p.Precio > 20
WriteLine("\n*** Filtrar y proyectar: productos caros ***");
var filtroProyeccion = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
    .Where(x => x.Precio > 20)
    .ToList();

filtroProyeccion.ForEach(x => WriteLine($"{x.Nombre} ({x.Categoria}): {x.Precio:C2}"));

// Proyección: clasificar productos por precio
// SQL: SELECT p.Nombre, p.Precio, CASE WHEN p.Precio > 50 THEN 'Caro' WHEN p.Precio > 20 THEN 'Medio' ELSE 'Barato' END as Categoria FROM Productos
WriteLine("\n*** Proyección: clasificación de productos por precio ***");
var clasificacionProductos = productos
    .Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new 
    { 
        p.Nombre, 
        p.Precio,
        Categoria = c.Nombre,
        NivelPrecio = p.Precio > 50 ? "Caro" : (p.Precio > 20 ? "Medio" : "Barato")
    })
    .ToList();

clasificacionProductos.ForEach(x => WriteLine($"{x.Nombre} ({x.Categoria}): {x.Precio:C2} - {x.NivelPrecio}"));

// Proyección: resumen de categorías
// SQL: SELECT c.Nombre, COUNT(p.Id) as Productos, SUM(p.Stock) as StockTotal, AVG(p.Precio) as PrecioMedio FROM Categorias c LEFT JOIN Productos p ON c.Id = p.CategoriaId GROUP BY c.Nombre
WriteLine("\n*** Proyección: resumen de categorías ***");
var resumenCategorias = categorias
    .GroupJoin(productos, c => c.Id, p => p.CategoriaId, (c, ps) => new 
    { 
        Categoria = c.Nombre,
        Productos = ps.Count(),
        StockTotal = ps.Sum(p => p.Stock),
        PrecioMedio = ps.Average(p => p.Precio)
    })
    .ToList();

resumenCategorias.ForEach(x => WriteLine($"{x.Categoria}: {x.Productos} productos, Stock={x.StockTotal}, Media={x.PrecioMedio:C2}"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy, Join) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = productos.Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
                           .Where(x => x.Precio > 50);
    productos.Add(new Producto(16, "Nueva", 1, 150.00, 10)); // ¡No ejecutada!
    consulta.ForEach(...); // AHORA se ejecuta

CON .ToList():
    var consulta = productos.Join(...).Where(...).ToList();
    productos.Add(new Producto(16, "Nueva", 1, 150.00, 10));
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
var consultaDiferida = productos.Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
                                .Where(x => x.Precio > 30);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Productos encontrados: {consultaDiferida.Count()}");

productos.Add(new Producto(16, "Nuevo Producto", 1, 99.99, 50));
WriteLine("Nuevo producto agregado");

WriteLine($"Productos encontrados: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces

// Ejemplo con .ToList()
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = productos.Join(categorias, p => p.CategoriaId, c => c.Id, (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre })
                                 .Where(x => x.Precio > 30).ToList();
WriteLine("Consulta ejecutada con .ToList()");

productos.Add(new Producto(17, "Otro Nuevo", 1, 150.00, 30));
WriteLine("Nuevo producto agregado");

WriteLine($"Productos en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
