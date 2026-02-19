using System.Linq;
using static System.Console;
using Vehiculos.Models;

var vehiculos = new List<Vehiculo>
{
    new("Toyota", "Corolla", 2018, "Rojo", 6.5, 85000),
    new("Ford", "Fiesta", 2020, "Azul", 5.8, 40000),
    new("Honda", "Civic", 2017, "Negro", 7.0, 120000),
    new("Chevrolet", "Onix", 2021, "Blanco", 5.3, 25000),
    new("Volkswagen", "Golf", 2019, "Gris", 6.8, 60000),
    new("Nissan", "Versa", 2016, "Plateado", 6.2, 130000),
    new("Hyundai", "Tucson", 2022, "Rojo", 7.5, 15000),
    new("Mazda", "3", 2015, "Azul", 6.0, 140000),
    new("BMW", "3 Series", 2020, "Blanco", 6.5, 100000),
    new("Mercedes-Benz", "E-Class", 2021, "Negro", 6.5, 80000),
    new("Toyota", "Celica", 2018, "Rojo", 6.5, 85000)
};

// ============================================================
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

// Obtener vehículos con consumo menor a 6 litros
// SQL: SELECT * FROM Vehiculos WHERE Consumo < 6.0
WriteLine("*** Vehículos con consumo menor a 6 litros ***");
var vehiculosConsumoMenor = vehiculos.Where(v => v.Consumo < 6.0).ToList();

vehiculosConsumoMenor.ForEach(WriteLine);

// Obtener vehículos con más de 100,000 km
// SQL: SELECT * FROM Vehiculos WHERE Kilometraje > 100000
WriteLine("\n*** Vehículos con kilometraje mayor a 100,000 km ***");
var vehiculosKilometrajeMayor = vehiculos.Where(v => v.Kilometraje > 100000).ToList();

vehiculosKilometrajeMayor.ForEach(WriteLine);

// Obtener vehículos de color blanco
// SQL: SELECT * FROM Vehiculos WHERE Color = 'Blanco'
WriteLine("\n*** Vehículos de color blanco ***");
var vehiculosColorBlanco = vehiculos.Where(v => v.Color == "Blanco").ToList();

vehiculosColorBlanco.ForEach(WriteLine);

// Obtener vehículos blancos y posteriores a 2018 ordenados por año
// SQL: SELECT * FROM Vehiculos WHERE Color = 'Blanco' AND AñoFabricacion > 2018 ORDER BY AñoFabricacion ASC
WriteLine("\n*** Vehículos blancos y posteriores a 2018 ***");
var vehiculosBlancoYAnio = vehiculos
    .Where(v => v.Color == "Blanco" && v.AñoFabricacion > 2018)
    .OrderBy(v => v.AñoFabricacion)
    .ToList();

vehiculosBlancoYAnio.ForEach(WriteLine);

// Obtener vehículos de color rojo
// SQL: SELECT * FROM Vehiculos WHERE Color = 'Rojo'
WriteLine("\n*** Vehículos de color rojo ***");
var vehiculosRojo = vehiculos.Where(v => v.Color == "Rojo").ToList();

vehiculosRojo.ForEach(WriteLine);

// Buscar vehículo por marca y modelo
// SQL: SELECT * FROM Vehiculos WHERE Marca = 'Toyota' AND Modelo = 'Celica'
WriteLine("\n*** Buscar vehículo por marca y modelo ***");
var vehiculoBuscado = vehiculos.FirstOrDefault(v => v.Marca == "Toyota" && v.Modelo == "Celica");

WriteLine(vehiculoBuscado?.ToString() ?? "No encontrado");

// Obtener lista de marcas únicas
// SQL: SELECT DISTINCT Marca FROM Vehiculos
WriteLine("\n*** Marcas únicas ***");
var marcas = vehiculos.Select(v => v.Marca).Distinct().ToList();

marcas.ForEach(WriteLine);

// Obtener marcas con más de 5 letras
// SQL: SELECT DISTINCT Marca FROM Vehiculos WHERE LEN(Marca) > 5
WriteLine("\n*** Marcas con más de 5 letras ***");
var marcasMasDeCinco = vehiculos
    .Select(v => v.Marca)
    .Distinct()
    .Where(m => m.Length > 5)
    .ToList();

marcasMasDeCinco.ForEach(WriteLine);

// Formatear vehículos como "Marca Modelo - Año"
// SQL: SELECT CONCAT(Marca, ' ', Modelo, ' - ', AñoFabricacion) FROM Vehiculos
WriteLine("\n*** Formato: Marca Modelo - Año ***");
var vehiculosConFormato = vehiculos
    .Select(v => $"{v.Marca} {v.Modelo} - {v.AñoFabricacion}")
    .ToList();

vehiculosConFormato.ForEach(WriteLine);

// Obtener la marca más larga
// SQL: SELECT TOP 1 Marca FROM Vehiculos ORDER BY LEN(Marca) DESC
WriteLine("\n*** Marca más larga ***");
var marcaMasLarga = vehiculos
    .OrderByDescending(v => v.Marca.Length)
    .First()
    .Marca;

WriteLine(marcaMasLarga);

// Calcular media de consumo de Toyota
// SQL: SELECT AVG(Consumo) FROM Vehiculos WHERE Marca = 'Toyota'
WriteLine("\n*** Media de consumo de Toyota ***");
var mediaConsumoToyota = vehiculos
    .Where(v => v.Marca == "Toyota")
    .Average(v => v.Consumo);

WriteLine(mediaConsumoToyota);

// Verificar si hay vehículos con más de 200,000 km
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Vehiculos WHERE Kilometraje > 200000) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Hay vehículos con más de 200,000 km? ***");
var hayMas200000 = vehiculos.Any(v => v.Kilometraje > 200000);

WriteLine(hayMas200000);

// Ordenar vehículos por año (más nuevo a más antiguo)
// SQL: SELECT * FROM Vehiculos ORDER BY AñoFabricacion ASC
WriteLine("\n*** Ordenados por año (más nuevo a más antiguo) ***");
var vehiculosOrdenadosAnio = vehiculos.OrderBy(v => v.AñoFabricacion).ToList();

vehiculosOrdenadosAnio.ForEach(WriteLine);

// Ordenar vehículos por consumo descendente
// SQL: SELECT * FROM Vehiculos ORDER BY Consumo DESC
WriteLine("\n*** Ordenados por consumo (mayor a menor) ***");
var vehiculosOrdenadosConsumo = vehiculos.OrderByDescending(v => v.Consumo).ToList();

vehiculosOrdenadosConsumo.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar vehículos por color
// SQL: SELECT Color, COUNT(*) FROM Vehiculos GROUP BY Color
WriteLine("\n*** Agrupados por color ***");
var vehiculosAgrupadosColor = vehiculos.GroupBy(v => v.Color).ToList();

vehiculosAgrupadosColor.ForEach(g => WriteLine($"{g.Key}: {g.Count()}"));

// Agrupar por marca y contar
// SQL: SELECT Marca, COUNT(*) FROM Vehiculos GROUP BY Marca
WriteLine("\n*** Agrupados por marca con conteo ***");
var vehiculosAgrupadosMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(g => g.Key, g => g.Count());

vehiculosAgrupadosMarca.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value}"));

// Agrupar por año de fabricación
// SQL: SELECT AñoFabricacion, COUNT(*) FROM Vehiculos GROUP BY AñoFabricacion
WriteLine("\n*** Agrupados por año de fabricación ***");
var vehiculosAgrupadosAnio = vehiculos
    .GroupBy(v => v.AñoFabricacion)
    .ToDictionary(g => g.Key, g => g.Count());

vehiculosAgrupadosAnio.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value}"));

// Agrupar por año y ordenar por cantidad
// SQL: SELECT AñoFabricacion, COUNT(*) FROM Vehiculos GROUP BY AñoFabricacion ORDER BY COUNT(*)
WriteLine("\n*** Agrupados por año y ordenados por cantidad ***");
var vehiculosAgrupadosAnioOrdenado = vehiculos
    .GroupBy(v => v.AñoFabricacion)
    .ToDictionary(g => g.Key, g => g.Count())
    .OrderBy(kv => kv.Value)
    .ToList();

vehiculosAgrupadosAnioOrdenado.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value}"));

// Calcular promedio de consumo
// SQL: SELECT AVG(Consumo) FROM Vehiculos
WriteLine("\n*** Promedio de consumo ***");
var promedioConsumo = vehiculos.Average(v => v.Consumo);

WriteLine(promedioConsumo);

// Obtener vehículo con mayor kilometraje
// SQL: SELECT TOP 1 * FROM Vehiculos ORDER BY Kilometraje DESC
WriteLine("\n*** Vehículo con mayor kilometraje ***");
var vehiculoMayorKilometraje = vehiculos.MaxBy(v => v.Kilometraje);

WriteLine(vehiculoMayorKilometraje);

// Contar cantidad por año de fabricación
// SQL: SELECT AñoFabricacion, COUNT(*) FROM Vehiculos GROUP BY AñoFabricacion
WriteLine("\n*** Cantidad por año de fabricación ***");
var cantidadPorAnio = vehiculos
    .GroupBy(v => v.AñoFabricacion)
    .ToDictionary(g => g.Key, g => g.Count());

cantidadPorAnio.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value}"));

// Sumar todos los kilómetros
// SQL: SELECT SUM(Kilometraje) FROM Vehiculos
WriteLine("\n*** Total de kilómetros ***");
var totalKilometros = vehiculos.Sum(v => v.Kilometraje);

WriteLine(totalKilometros);

// Contar vehículos que superan el consumo promedio
// SQL: SELECT COUNT(*) FROM Vehiculos WHERE Consumo > (SELECT AVG(Consumo) FROM Vehiculos)
WriteLine("\n*** Vehículos que superan el consumo promedio ***");
var promedioConsumoTotal = vehiculos.Average(v => v.Consumo);
var cantidadSuperanConsumo = vehiculos.Count(v => v.Consumo > promedioConsumoTotal);

WriteLine(cantidadSuperanConsumo);

// Contar vehículos que superan el kilometraje promedio
// SQL: SELECT COUNT(*) FROM Vehiculos WHERE Kilometraje > (SELECT AVG(Kilometraje) FROM Vehiculos)
WriteLine("\n*** Vehículos que superan el kilometraje promedio ***");
var promedioKilometraje = vehiculos.Average(v => v.Kilometraje);
var cantidadSuperanKilometraje = vehiculos.Count(v => v.Kilometraje > promedioKilometraje);

WriteLine(cantidadSuperanKilometraje);

// Agrupar por año con promedio de consumo
// SQL: SELECT AñoFabricacion, AVG(Consumo) FROM Vehiculos GROUP BY AñoFabricacion
WriteLine("\n*** Agrupados por año con promedio de consumo ***");
var agrupadosAnioConsumo = vehiculos
    .GroupBy(v => v.AñoFabricacion)
    .ToDictionary(g => g.Key, g => g.Average(v => v.Consumo));

agrupadosAnioConsumo.ToList().ForEach(kv => WriteLine($"Año {kv.Key}: {kv.Value:F2}"));

// Obtener vehículos con consumo < 6.5 y kilometraje < 100,000
// SQL: SELECT * FROM Vehiculos WHERE Consumo < 6.5 AND Kilometraje < 100000
WriteLine("\n*** Consumo < 6.5 y kilometraje < 100,000 ***");
var vehiculosFiltro = vehiculos
    .Where(v => v.Consumo < 6.5 && v.Kilometraje < 100000)
    .ToList();

vehiculosFiltro.ForEach(WriteLine);

// Obtener vehículos fabricados entre 2015 y 2020, no negros ni blancos
// SQL: SELECT * FROM Vehiculos WHERE AñoFabricacion BETWEEN 2015 AND 2020 AND Color NOT IN ('negro', 'blanco')
WriteLine("\n*** Fabricados entre 2015 y 2020, no negros ni blancos ***");
var vehiculosEntre2015Y2020 = vehiculos
    .Where(v => v.AñoFabricacion >= 2015 
                && v.AñoFabricacion <= 2020 
                && v.Color.ToLower() != "negro" 
                && v.Color.ToLower() != "blanco")
    .ToList();

vehiculosEntre2015Y2020.ForEach(WriteLine);

// Obtener vehículos de marcas que empiezan por T o H con más de 50,000 km
// SQL: SELECT * FROM Vehiculos WHERE (Marca LIKE 'T%' OR Marca LIKE 'H%') AND Kilometraje > 50000
WriteLine("\n*** Marcas que empiezan por T o H con más de 50,000 km ***");
var vehiculosMarcaT = vehiculos
    .Where(v => (v.Marca.StartsWith("T") || v.Marca.StartsWith("H")) && v.Kilometraje > 50000)
    .ToList();

vehiculosMarcaT.ForEach(WriteLine);

// Crear mapa de marcas a modelos
// SQL: SELECT Marca, Modelo FROM Vehiculos
WriteLine("\n*** Mapa de marcas a modelos ***");
var marcasConModelos = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(g => g.Key, g => g.Select(v => v.Modelo).ToList());

marcasConModelos.ToList().ForEach(kv => WriteLine($"{kv.Key}: {string.Join(", ", kv.Value)}"));

// Convertir a un solo string
// SQL: SELECT CONCAT(Marca, ' ', Modelo, ' (', AñoFabricacion, ') - ', Consumo, ' L/100km') FROM Vehiculos
WriteLine("\n*** Un solo string con todos los vehículos ***");
var vehiculosString = string.Join(", ", vehiculos.Select(v => $"{v.Marca} {v.Modelo} ({v.AñoFabricacion}) - {v.Consumo} L/100km"));

WriteLine(vehiculosString);

// Ordenar por consumo y desempate por km descendente
// SQL: SELECT * FROM Vehiculos ORDER BY Consumo ASC, Kilometraje DESC
WriteLine("\n*** Ordenados por consumo, desempate por km descendente ***");
var vehiculosOrdenConsumoKm = vehiculos
    .OrderBy(v => v.Consumo)
    .ThenByDescending(v => v.Kilometraje)
    .ToList();

vehiculosOrdenConsumoKm.ForEach(WriteLine);

// Calcular consumo promedio de vehículos posteriores a 2018
// SQL: SELECT AVG(Consumo) FROM Vehiculos WHERE AñoFabricacion > 2018
WriteLine("\n*** Consumo promedio de vehículos posteriores a 2018 ***");
var promedioPost2018 = vehiculos
    .Where(v => v.AñoFabricacion > 2018)
    .Average(v => v.Consumo);

WriteLine(promedioPost2018);

// Obtener vehículo con mejor rendimiento (menor consumo)
// SQL: SELECT TOP 1 * FROM Vehiculos ORDER BY Consumo ASC
WriteLine("\n*** Mejor rendimiento (menor consumo) ***");
var vehiculoMejorRendimiento = vehiculos.MinBy(v => v.Consumo);

WriteLine(vehiculoMejorRendimiento);

// Contar vehículos con más de 100,000 km
// SQL: SELECT COUNT(*) FROM Vehiculos WHERE Kilometraje > 100000
WriteLine("\n*** Cantidad con más de 100,000 km ***");
var cantidadMas100000 = vehiculos.Count(v => v.Kilometraje > 100000);

WriteLine(cantidadMas100000);

// Verificar si todos tienen consumo menor a 8 litros
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Vehiculos WHERE Consumo < 8) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos tienen consumo menor a 8 litros? ***");
var todosConsumoMenor8 = vehiculos.All(v => v.Consumo < 8);

WriteLine(todosConsumoMenor8);

// Verificar si hay algún rojo con menos de 50,000 km
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Vehiculos WHERE Color = 'rojo' AND Kilometraje < 50000) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Hay algún rojo con menos de 50,000 km? ***");
var hayRojoMenos50000 = vehiculos.Any(v => v.Color.ToLower() == "rojo" && v.Kilometraje < 50000);

WriteLine(hayRojoMenos50000);

// Obtener el color más frecuente
// SQL: SELECT Color FROM Vehiculos GROUP BY Color ORDER BY COUNT(*) DESC LIMIT 1
WriteLine("\n*** Color más frecuente ***");
var colorMasFrecuente = vehiculos
    .GroupBy(v => v.Color)
    .OrderByDescending(g => g.Count())
    .First()
    .Key;

WriteLine(colorMasFrecuente);

// Obtener cantidad del color más frecuente
// SQL: SELECT COUNT(*) FROM Vehiculos GROUP BY Color ORDER BY COUNT(*) DESC LIMIT 1
WriteLine("\n*** Cantidad del color más frecuente ***");
var cantidadColorMasFrecuente = vehiculos
    .GroupBy(v => v.Color)
    .Max(g => g.Count());

WriteLine(cantidadColorMasFrecuente);

// Obtener marca con más vehículos
// SQL: SELECT Marca FROM Vehiculos GROUP BY Marca ORDER BY COUNT(*) DESC LIMIT 1
WriteLine("\n*** Marca con más vehículos ***");
var marcaConMas = vehiculos
    .GroupBy(v => v.Marca)
    .OrderByDescending(g => g.Count())
    .First();

WriteLine($"Marca: {marcaConMas.Key}, Cantidad: {marcaConMas.Count()}");

// Obtener años de fabricación únicos ordenados
// SQL: SELECT DISTINCT AñoFabricacion FROM Vehiculos ORDER BY AñoFabricacion ASC
WriteLine("\n*** Años de fabricación únicos ordenados ***");
var añosUnicos = vehiculos
    .Select(v => v.AñoFabricacion)
    .Distinct()
    .OrderBy(a => a)
    .ToList();

añosUnicos.ForEach(WriteLine);

// Obtener marcas con más de 2 vehículos
// SQL: SELECT Marca FROM Vehiculos GROUP BY Marca HAVING COUNT(*) > 2
WriteLine("\n*** Marcas con más de 2 vehículos ***");
var vehiculosPorMarca = vehiculos
    .GroupBy(v => v.Marca)
    .Where(g => g.Count() > 2)
    .ToList();

vehiculosPorMarca.ForEach(g => WriteLine($"{g.Key}: {g.Count()} vehículos"));

// Obtener los vehículos que son de color Rojo
// SQL: SELECT * FROM Vehiculos WHERE Color = 'Rojo'
WriteLine("\n*** Vehículos de color Rojo ***");
var vehiculosRojoTodos = vehiculos
    .Where(v => v.Color == "Rojo")
    .ToList();

vehiculosRojoTodos.ForEach(WriteLine);

// Obtener el vehículo con más kilometraje
// SQL: SELECT TOP 1 * FROM Vehiculos ORDER BY Kilometraje DESC
WriteLine("\n*** Vehículo con más kilometraje ***");
var vehiculoMasKm = vehiculos
    .OrderByDescending(v => v.Kilometraje)
    .First();

WriteLine(vehiculoMasKm);

// Agrupar vehículos por color y mostrar el listado
// SQL: SELECT * FROM Vehiculos
WriteLine("\n*** Vehículos agrupados por color ***");
var vehiculosPorColor = vehiculos
    .GroupBy(v => v.Color)
    .ToList();

vehiculosPorColor.ToList().ForEach(g =>
{
    WriteLine($"\nColor {g.Key}:");
    g.ToList().ForEach(v => WriteLine($"  - {v.Marca} {v.Modelo}"));
});

// Calcular el consumo medio por marca
// SQL: SELECT Marca, AVG(Consumo) FROM Vehiculos GROUP BY Marca
WriteLine("\n*** Consumo medio por marca ***");
var consumoMedioPorMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(g => g.Key, g => g.Average(v => v.Consumo));

consumoMedioPorMarca.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value:F2}"));

// Agrupar por marca y obtener el vehículo con menos consumo de cada una
// SQL: SELECT * FROM Vehiculos v1 WHERE Consumo = (SELECT MIN(Consumo) FROM Vehiculos v2 WHERE v1.Marca = v2.Marca)
WriteLine("\n*** Vehículo con menos consumo de cada marca ***");
var menosConsumoPorMarca = vehiculos
    .GroupBy(v => v.Marca)
    .Select(g => g.MinBy(v => v.Consumo))
    .ToList();

menosConsumoPorMarca.ForEach(WriteLine);

// Agrupar por marca: vehículo con más y menos consumo
// SQL: SELECT Marca, MIN(Consumo), MAX(Consumo) FROM Vehiculos GROUP BY Marca
WriteLine("\n*** Consumo máximo y mínimo por marca ***");
var consumoPorMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MenorConsumo = g.Min(v => v.Consumo),
            MayorConsumo = g.Max(v => v.Consumo),
            ModeloMenor = g.MinBy(v => v.Consumo)?.Modelo,
            ModeloMayor = g.MaxBy(v => v.Consumo)?.Modelo
        }
    );

consumoPorMarca.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Menor={kv.Value.MenorConsumo} ({kv.Value.ModeloMenor}), Mayor={kv.Value.MayorConsumo} ({kv.Value.ModeloMayor})"));

// Agrupar por marca: estadísticas completas
// SQL: SELECT Marca, MAX(Consumo), MIN(Consumo), AVG(Consumo), COUNT(*), SUM(Kilometraje) FROM Vehiculos GROUP BY Marca
WriteLine("\n*** Estadísticas completas por marca ***");
var estadisticasPorMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MaxConsumo = g.Max(v => v.Consumo),
            MinConsumo = g.Min(v => v.Consumo),
            MediaConsumo = g.Average(v => v.Consumo),
            Cantidad = g.Count(),
            TotalKm = g.Sum(v => v.Kilometraje)
        }
    );

estadisticasPorMarca.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Max={kv.Value.MaxConsumo:F2}, Min={kv.Value.MinConsumo:F2}, Media={kv.Value.MediaConsumo:F2}, Cantidad={kv.Value.Cantidad}, TotalKm={kv.Value.TotalKm}"));

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar los primeros 3 vehículos
// SQL: SELECT TOP 3 * FROM Vehiculos
WriteLine("\n*** Primeros 3 vehículos ***");
var primeros3 = vehiculos.Take(3).ToList();

primeros3.ForEach(WriteLine);

// Paginación: mostrar los siguientes 3 vehículos
// SQL: SELECT * FROM Vehiculos OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Siguientes 3 vehículos ***");
var siguientes3 = vehiculos.Skip(3).Take(3).ToList();

siguientes3.ForEach(WriteLine);

// Paginación: últimos 3 vehículos
// SQL: SELECT * FROM Vehiculos OFFSET 8 ROWS
WriteLine("\n*** Últimos 3 vehículos ***");
var ultimos3 = vehiculos.Skip(8).Take(3).ToList();

ultimos3.ForEach(WriteLine);

// Verificar si existe algún vehículo de la marca BMW
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Vehiculos WHERE Marca = 'BMW') THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún vehículo BMW? ***");
var hayBmw = vehiculos.Any(v => v.Marca == "BMW");

WriteLine(hayBmw ? "Sí, hay vehículos BMW" : "No hay vehículos BMW");

// Verificar si todos los vehículos tienen menos de 200,000 km
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Vehiculos WHERE Kilometraje < 200000) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los vehículos tienen menos de 200,000 km? ***");
var todosMenos200mil = vehiculos.All(v => v.Kilometraje < 200000);

WriteLine(todosMenos200mil ? "Sí, todos tienen menos de 200,000 km" : "Algunos tienen más de 200,000 km");

// Obtener el vehículo con menos consumo
// SQL: SELECT TOP 1 * FROM Vehiculos ORDER BY Consumo ASC
WriteLine("\n*** El vehículo con menos consumo ***");
var menosConsumo = vehiculos.MinBy(v => v.Consumo);

WriteLine(menosConsumo);

// Obtener el año más reciente de fabricación
// SQL: SELECT MAX(AñoFabricacion) FROM Vehiculos
WriteLine("\n*** Año más reciente de fabricación ***");
var añoMasReciente = vehiculos.Max(v => v.AñoFabricacion);

WriteLine($"El año más reciente es: {añoMasReciente}");

// Obtener vehículos con menos de 50,000 km
// SQL: SELECT * FROM Vehiculos WHERE Kilometraje < 50000
WriteLine("\n*** Vehículos con menos de 50,000 km ***");
var pocosKm = vehiculos.Where(v => v.Kilometraje < 50000).ToList();

pocosKm.ForEach(WriteLine);

// Obtener colores únicos
// SQL: SELECT DISTINCT Color FROM Vehiculos
WriteLine("\n*** Colores únicos ***");
var coloresUnicos = vehiculos.Select(v => v.Color).Distinct().ToList();

coloresUnicos.ForEach(WriteLine);

// Obtener el total de kilómetros de todos los vehículos
// SQL: SELECT SUM(Kilometraje) FROM Vehiculos
WriteLine("\n*** Kilómetros totales ***");
var kmTotales = vehiculos.Sum(v => v.Kilometraje);

WriteLine($"Kilómetros totales: {kmTotales:N0} km");

// Vehículos ordenados por año (página 1 de 3 en 3)
// SQL: SELECT * FROM Vehiculos ORDER BY AñoFabricacion OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY
WriteLine("\n*** Vehículos ordenados por año (página 1) ***");
var porAñoPag1 = vehiculos.OrderBy(v => v.AñoFabricacion).Take(3).ToList();

porAñoPag1.ForEach(WriteLine);

WriteLine("\n*** Vehículos ordenados por año (página 2) ***");
var porAñoPag2 = vehiculos.OrderBy(v => v.AñoFabricacion).Skip(3).Take(3).ToList();

porAñoPag2.ForEach(WriteLine);

WriteLine("\n*** Vehículos ordenados por año (página 3) ***");
var porAñoPag3 = vehiculos.OrderBy(v => v.AñoFabricacion).Skip(6).Take(3).ToList();

porAñoPag3.ForEach(WriteLine);

// Obtener los 2 vehículos más antiguos
// SQL: SELECT TOP 2 * FROM Vehiculos ORDER BY AñoFabricacion ASC
WriteLine("\n*** Los 2 vehículos más antiguos ***");
var masAntiguos = vehiculos.OrderBy(v => v.AñoFabricacion).Take(2).ToList();

masAntiguos.ForEach(WriteLine);

// Obtener los 2 vehículos más nuevos
// SQL: SELECT TOP 2 * FROM Vehiculos ORDER BY AñoFabricacion DESC
WriteLine("\n*** Los 2 vehículos más nuevos ***");
var masNuevos = vehiculos.OrderByDescending(v => v.AñoFabricacion).Take(2).ToList();

masNuevos.ForEach(WriteLine);

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Vehículos Toyota con consumo menor a 6.5
// SQL: SELECT * FROM Vehiculos WHERE Marca = 'Toyota' AND Consumo < 6.5
WriteLine("\n*** Toyota con consumo < 6.5 ***");
var toyotaConsumo = vehiculos
    .Where(v => v.Marca == "Toyota" && v.Consumo < 6.5)
    .ToList();

toyotaConsumo.ForEach(WriteLine);

// Vehículos de color Rojo O Azul
// SQL: SELECT * FROM Vehiculos WHERE Color IN ('Rojo', 'Azul')
WriteLine("\n*** Vehículos de color Rojo o Azul ***");
var colores = new[] { "Rojo", "Azul" };
var vehiculosColor = vehiculos
    .Where(v => colores.Contains(v.Color))
    .ToList();

vehiculosColor.ForEach(WriteLine);

// Vehículos con año entre 2017 y 2020
// SQL: SELECT * FROM Vehiculos WHERE AñoFabricacion BETWEEN 2017 AND 2020
WriteLine("\n*** Vehículos entre 2017 y 2020 ***");
var vehiculosAnio = vehiculos
    .Where(v => v.AñoFabricacion >= 2017 && v.AñoFabricacion <= 2020)
    .ToList();

vehiculosAnio.ForEach(WriteLine);

// Vehículos con kilometraje entre 50,000 y 100,000
// SQL: SELECT * FROM Vehiculos WHERE Kilometraje BETWEEN 50000 AND 100000
WriteLine("\n*** Kilometraje entre 50,000 y 100,000 ***");
var vehiculosKm = vehiculos
    .Where(v => v.Kilometraje >= 50000 && v.Kilometraje <= 100000)
    .ToList();

vehiculosKm.ForEach(WriteLine);

// Vehículos que NO son de marca Toyota NI Ford
// SQL: SELECT * FROM Vehiculos WHERE Marca NOT IN ('Toyota', 'Ford')
WriteLine("\n*** NO son Toyota ni Ford ***");
var marcasExcluidas = new[] { "Toyota", "Ford" };
var vehiculosNo = vehiculos
    .Where(v => !marcasExcluidas.Contains(v.Marca))
    .ToList();

vehiculosNo.ForEach(WriteLine);

// Vehículos con consumo mayor a 6 O kilometraje menor a 30,000
// SQL: SELECT * FROM Vehiculos WHERE Consumo > 6 OR Kilometraje < 30000
WriteLine("\n*** Consumo > 6 o km < 30,000 ***");
var consumoOKm = vehiculos
    .Where(v => v.Consumo > 6 || v.Kilometraje < 30000)
    .ToList();

consumoOKm.ForEach(WriteLine);

// Vehículos posteriores a 2018 Y con consumo menor a 7
// SQL: SELECT * FROM Vehiculos WHERE AñoFabricacion > 2018 AND Consumo < 7
WriteLine("\n*** Posteriores a 2018 y consumo < 7 ***");
var vehiculosPost2018Consumo7 = vehiculos
    .Where(v => v.AñoFabricacion > 2018 && v.Consumo < 7)
    .ToList();

vehiculosPost2018Consumo7.ForEach(WriteLine);

// Múltiples Where encadenados
// SQL: SELECT * FROM Vehiculos WHERE Color = 'Rojo' ORDER BY Consumo ASC
WriteLine("\n*** Múltiples Where: rojos y consumo < 7 ***");
var multiplesWhere = vehiculos
    .Where(v => v.Color == "Rojo")
    .Where(v => v.Consumo < 7)
    .OrderBy(v => v.Consumo)
    .ToList();

multiplesWhere.ForEach(WriteLine);

// Vehículos con modelo de más de 3 caracteres
// SQL: SELECT * FROM Vehiculos WHERE LEN(Modelo) > 3
WriteLine("\n*** Modelos con más de 3 caracteres ***");
var modelosLargos = vehiculos
    .Where(v => v.Modelo.Length > 3)
    .ToList();

modelosLargos.ForEach(WriteLine);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: marca y año formateados
// SQL: SELECT Marca, AñoFabricacion FROM Vehiculos
WriteLine("\n*** Proyección: marca y año formateados ***");
var proyeccionesMarcaAño = vehiculos
    .Select(v => new { v.Marca, v.AñoFabricacion, Display = $"{v.Marca} ({v.AñoFabricacion})" })
    .ToList();

proyeccionesMarcaAño.ForEach(p => WriteLine(p.Display));

// Proyección: clasificar vehículos por eficiencia
// SQL: SELECT Marca, Consumo, CASE WHEN Consumo < 6 THEN 'Eficiente' WHEN Consumo < 7 THEN 'Normal' ELSE 'Alto' END as Categoria FROM Vehiculos
WriteLine("\n*** Proyección: clasificación por eficiencia ***");
var clasificacionConsumo = vehiculos
    .Select(v => new 
    { 
        v.Marca, 
        v.Modelo,
        v.Consumo,
        Categoria = v.Consumo < 6 ? "Eficiente" : (v.Consumo < 7 ? "Normal" : "Alto")
    })
    .ToList();

clasificacionConsumo.ForEach(c => WriteLine($"{c.Marca} {c.Modelo}: {c.Consumo}L - {c.Categoria}"));

// Proyección: calcular coste por kilómetro
// SQL: SELECT Marca, Modelo, Kilometraje, (Kilometraje * 0.15) as Coste FROM Vehiculos
WriteLine("\n*** Proyección: coste estimado por kilómetro ***");
var costeKilometro = vehiculos
    .Select(v => new 
    { 
        v.Marca, 
        v.Modelo, 
        v.Kilometraje,
        CosteEstimado = v.Kilometraje * 0.15
    })
    .ToList();

costeKilometro.ForEach(c => WriteLine($"{c.Marca} {c.Modelo}: {c.Kilometraje:N0}km x 0.15 = {c.CosteEstimado:C2}"));

// Proyección: estadísticas por color
// SQL: SELECT Color, COUNT(*) as Cantidad, AVG(Consumo) as Media, SUM(Kilometraje) as TotalKm FROM Vehiculos GROUP BY Color
WriteLine("\n*** Proyección: estadísticas por color ***");
var estadisticasColor = vehiculos
    .GroupBy(v => v.Color)
    .ToDictionary(
        g => g.Key,
        g => new 
        { 
            Cantidad = g.Count(),
            ConsumoMedio = g.Average(v => v.Consumo),
            KmTotal = g.Sum(v => v.Kilometraje)
        }
    );

estadisticasColor.ToList().ForEach(kv => WriteLine($"{kv.Key}: {kv.Value.Cantidad} vehículos, Consumo={kv.Value.ConsumoMedio:F1}L, KmTotal={kv.Value.KmTotal:N0}"));

// Proyección: filtrar Y proyectar
// SQL: SELECT Marca, Modelo, Consumo FROM Vehiculos WHERE AñoFabricacion > 2018
WriteLine("\n*** Filtrar y proyectar: vehículos nuevos ***");
var filtroProyeccion = vehiculos
    .Where(v => v.AñoFabricacion > 2018)
    .Select(v => new { v.Marca, v.Modelo, v.Consumo })
    .ToList();

filtroProyeccion.ForEach(p => WriteLine($"{p.Marca} {p.Modelo}: {p.Consumo}L"));

// Proyección: información del vehículo formateada
// SQL: SELECT CONCAT(Marca, ' ', Modelo, ' - ', Color, ' (', AñoFabricacion, ')') as Info FROM Vehiculos
WriteLine("\n*** Proyección: información completa formateada ***");
var infoCompleta = vehiculos
    .Select(v => new 
    { 
        Info = $"{v.Marca} {v.Modelo} - {v.Color} ({v.AñoFabricacion})",
        v.Consumo,
        v.Kilometraje
    })
    .ToList();

infoCompleta.ForEach(i => WriteLine($"{i.Info} - {i.Consumo}L/100km - {i.Kilometraje:N0}km"));

// Proyección: resumen por marca
// SQL: SELECT Marca, MAX(Consumo) as Maximo, MIN(Consumo) as Minimo, AVG(Consumo) as Media FROM Vehiculos GROUP BY Marca
WriteLine("\n*** Proyección: consumo máximo, mínimo y medio por marca ***");
var resumenMarca = vehiculos
    .GroupBy(v => v.Marca)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Maximo = g.Max(v => v.Consumo),
            Minimo = g.Min(v => v.Consumo),
            Media = g.Average(v => v.Consumo),
            Vehiculos = g.Count()
        }
    );

resumenMarca.ToList().ForEach(kv => WriteLine($"{kv.Key}: Max={kv.Value.Maximo}L, Min={kv.Value.Minimo}L, Media={kv.Value.Media:F1}L ({kv.Value.Vehiculos} vehículos)"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = vehiculos.Where(v => v.Consumo < 6);
    vehiculos.Add(new Vehiculo("Tesla", "Model 3", 2024, "Negro", 0, 1000)); // ¡No ejecutada!
    consulta.ForEach(...); // AHORA se ejecuta

CON .ToList():
    var consulta = vehiculos.Where(v => v.Consumo < 6).ToList();
    vehiculos.Add(new Vehiculo("Tesla", "Model 3", 2024, "Negro", 0, 1000));
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
var consultaDiferida = vehiculos.Where(v => v.Consumo < 6.5);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Vehículos encontrados: {consultaDiferida.Count()}");

vehiculos.Add(new Vehiculo("Tesla", "Model 3", 2024, "Rojo", 0, 5000));
WriteLine("Nuevo vehículo agregado");

WriteLine($"Vehículos encontrados: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces

// Ejemplo con .ToList()
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = vehiculos.Where(v => v.Consumo < 6.5).ToList();
WriteLine("Consulta ejecutada con .ToList()");

vehiculos.Add(new Vehiculo("Rivian", "R1T", 2024, "Negro", 0, 3000));
WriteLine("Nuevo vehículo agregado");

WriteLine($"Vehículos en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
