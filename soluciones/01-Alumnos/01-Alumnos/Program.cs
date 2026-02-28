using System.Linq;
using static System.Console;
using Alumnos.Models;

var listaAlumnos = new List<Alumno>
{
    new(1, "1717213183", "Javier", "Molina Cano", "Java 8", 7, 28),
    new(2, "1717456218", "Ana", "Gómez Álvarez", "Java 8", 10, 33),
    new(3, "1717328901", "Pedro", "Marín López", "Java 8", 8.6, 15),
    new(4, "1717567128", "Emilio", "Duque Gutiérrez", "Java 8", 10, 13),
    new(5, "1717902145", "Alberto", "Sáenz Hurtado", "Java 8", 9.5, 15),
    new(6, "1717678456", "Germán", "López Fernández", "Java 8", 8, 34),
    new(7, "1102156732", "Oscar", "Murillo González", "Java 8", 10, 32),
    new(8, "1103421907", "Antonio Jesús", "Palacio Martínez", "PHP", 9.5, 17),
    new(9, "1717297015", "César", "González Martínez", "Java 8", 8, 26),
    new(10, "1717912056", "Gloria", "González Castaño", "PHP", 10, 28),
    new(11, "1717912058", "Jorge", "Ruiz Ruiz", "Python", 8, 22),
    new(12, "1717912985", "Ignacio", "Duque García", "Java Script", 9.4, 32),
    new(13, "1717913851", "Julio", "González Castaño", "C Sharp", 10, 22),
    new(14, "1717986531", "Gloria", "Rodas Carretero", "Ruby", 7, 18),
    new(15, "1717975232", "Jaime", "Jiménez Gómez", "Java Script", 10, 18)
};

// ============================================================
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

// Obtener todos los alumnos de la lista
// SQL: SELECT * FROM Alumnos
WriteLine("*** Lista de Alumnos ***");
var todosAlumnos = listaAlumnos
    .AsEnumerable();

foreach (var a in todosAlumnos) 
    WriteLine(a);

// Obtener los alumnos cuyo apellido empieza por L o G
// SQL: SELECT * FROM Alumnos WHERE Apellidos LIKE 'L%' OR Apellidos LIKE 'G%'
WriteLine("\n*** Alumnos cuyo apellido empiezan con L o G ***");
var alumnosApellidoL_O_G = listaAlumnos
    .Where(a => a.Apellidos.StartsWith("L") || a.Apellidos.StartsWith("G"));

foreach (var a in alumnosApellidoL_O_G) 
    WriteLine(a);

// Contar el número total de alumnos
// SQL: SELECT COUNT(*) FROM Alumnos
WriteLine("\n*** Número de Alumnos ***");
var numeroAlumnos = listaAlumnos
    .Count();

WriteLine(numeroAlumnos);

// Obtener los alumnos con nota mayor a 9 y que sean del curso PHP
// SQL: SELECT * FROM Alumnos WHERE Nota > 9 AND NombreCurso = 'PHP'
WriteLine("\n*** Alumnos con nota mayor a 9 y que sean del curso PHP ***");
var alumnosNotaMayor9PHP = listaAlumnos
    .Where(a => a.Nota > 9)
    .Where(a => a.NombreCurso == "PHP");

foreach (var a in alumnosNotaMayor9PHP) 
    WriteLine(a);

// ============================================================
// CONSULTAS DE ELEMENTOS (TAKE, FIRST, SINGLE)
// ============================================================

// Obtener los 2 primeros alumnos de la lista
// SQL: SELECT TOP 2 * FROM Alumnos
WriteLine("\n*** Imprimir los 2 primeros Alumnos de la lista ***");
var dosPrimerosAlumnos = listaAlumnos
    .Take(2);

foreach (var a in dosPrimerosAlumnos) 
    WriteLine(a);

// Obtener el alumno con menor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad ASC
WriteLine("\n*** Imprimir el alumno con menor edad ***");
var alumnoMenorEdad = listaAlumnos
    .MinBy(a => a.Edad);

WriteLine(alumnoMenorEdad);

// Obtener el alumno con mayor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad DESC
WriteLine("\n*** Imprimir el alumno con mayor edad ***");
var alumnoMayorEdad = listaAlumnos
    .MaxBy(a => a.Edad);

WriteLine(alumnoMayorEdad);

// Obtener el primer alumno de la lista
// SQL: SELECT TOP 1 * FROM Alumnos
WriteLine("\n*** Encontrar el primer Alumno ***");
var primerAlumno = listaAlumnos
    .First();

WriteLine(primerAlumno);

// Obtener los alumnos cuyo nombre de curso contiene la letra A
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Alumnos que tienen un curso cuyo nombre contiene la A ***");
var alumnosCursoConA = listaAlumnos
    .Where(a => a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase));

foreach (var a in alumnosCursoConA) 
    WriteLine(a);

// Obtener los alumnos cuyo nombre tiene más de 10 caracteres
// SQL: SELECT * FROM Alumnos WHERE LEN(Nombre) > 10
WriteLine("\n*** Alumnos cuyo nombre tiene más de 10 caracteres ***");
var alumnosNombreLargo = listaAlumnos
    .Where(a => a.Nombre.Length > 10);

foreach (var a in alumnosNombreLargo) 
    WriteLine(a);

// Obtener los alumnos cuyo curso empieza por P y tiene longitud menor o igual a 6
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE 'P%' AND LEN(NombreCurso) <= 6
WriteLine("\n*** Combinación de predicados: curso que empieza por P y longitud <= 6 ***");
var alumnosCombinados = listaAlumnos
    .Where(a => a.NombreCurso.ToUpper().StartsWith("P"))
    .Where(a => a.NombreCurso.Length <= 6);

foreach (var a in alumnosCombinados) 
    WriteLine(a);

// Copiar a una nueva lista los alumnos cuyo curso contiene la letra A
// SQL: SELECT * INTO NuevaLista FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Copia de datos filtrados a otra lista ***");
// Aquí usamos .ToList() porque queremos una COPIA real de los datos en este instante.
var nuevaLista = listaAlumnos
    .Where(a => a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase))
    .ToList();

foreach (var a in nuevaLista) 
    WriteLine(a);

// ============================================================
// CONSULTAS DE ESTADÍSTICAS Y AGREGACIÓN (COUNT, SUM, AVG, MIN, MAX)
// ============================================================

// Obtener estadísticas de las notas: count, average, max, min
// SQL: SELECT COUNT(Nota), AVG(Nota), MAX(Nota), MIN(Nota) FROM Alumnos
WriteLine("\n*** Estadísticas de notas ***");
// Materializamos a lista para recorrerla 4 veces (agregados) sin re-ejecutar la proyección.
var notas = listaAlumnos
    .Select(a => a.Nota)
    .ToList();

WriteLine($"Count: {notas.Count}");
WriteLine($"Average: {notas.Average():F2}");
WriteLine($"Max: {notas.Max()}");
WriteLine($"Min: {notas.Min()}");

// Obtener los alumnos que son del curso Java 8
// SQL: SELECT * FROM Alumnos WHERE NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos del curso Java 8 ***");
var alumnosJava8 = listaAlumnos
    .Where(a => a.NombreCurso == "Java 8");

foreach (var a in alumnosJava8) 
    WriteLine(a);

// Obtener el mejor alumno (mayor nota)
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Nota DESC
WriteLine("\n*** El mejor alumno (mayor nota) ***");
var mejorAlumno = listaAlumnos
    .MaxBy(a => a.Nota);

WriteLine(mejorAlumno);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY)
// ============================================================

// Agrupar alumnos por curso y mostrar el listado
// SQL: SELECT * FROM Alumnos
WriteLine("\n*** Alumnos agrupados por curso ***");
var alumnosPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso);

foreach (var grupo in alumnosPorCurso)
{
    WriteLine($"\nCurso: {grupo.Key}");
    foreach (var a in grupo) 
        WriteLine(a);
}

// Calcular la nota media por curso
// SQL: SELECT NombreCurso, AVG(Nota) FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Nota media por curso ***");
var notaMediaPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(
        g => g.Key, 
        g => g.Average(a => a.Nota)
    );

foreach (var item in notaMediaPorCurso) 
    WriteLine($"{item.Key}: {item.Value:F2}");

// Agrupar por curso y obtener el mejor alumno de cada uno
// SQL: SELECT * FROM Alumnos WHERE Nota = (SELECT MAX(Nota) FROM Alumnos a2 WHERE a2.NombreCurso = Alumnos.NombreCurso)
WriteLine("\n*** Mejor alumno de cada curso ***");
var mejorPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .Select(g => g.MaxBy(a => a.Nota));

foreach (var a in mejorPorCurso) 
    WriteLine(a);

// Agrupar por curso: mejor y peor alumno
// SQL: SELECT NombreCurso, MAX(Nota) as Mejor, MIN(Nota) as Peor FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Mejor y peor nota por curso ***");
var mejorPeorPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Mejor = g.Max(a => a.Nota),
            Minimo = g.Min(a => a.Nota),
            MejorAlumno = g.MaxBy(a => a.Nota)?.Nombre,
            MinimoAlumno = g.MinBy(a => a.Nota)?.Nombre
        }
    );

foreach (var item in mejorPeorPorCurso)
    WriteLine($"{item.Key}: Mejor={item.Value.Mejor} ({item.Value.MejorAlumno}), Peor={item.Value.Minimo} ({item.Value.MinimoAlumno})");

// Agrupar por curso: estadísticas completas
// SQL: SELECT NombreCurso, MAX(Nota), MIN(Nota), AVG(Nota), COUNT(*) FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Estadísticas completas por curso ***");
var estadisticasPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            Maxima = g.Max(a => a.Nota),
            Minima = g.Min(a => a.Nota),
            Media = g.Average(a => a.Nota),
            Cantidad = g.Count()
        }
    );

foreach (var item in estadisticasPorCurso)
    WriteLine($"{item.Key}: Max={item.Value.Maxima:F2}, Min={item.Value.Minima:F2}, Media={item.Value.Media:F2}, Cantidad={item.Value.Cantidad}");

// Obtener cursos con más de 3 alumnos (HAVING)
// SQL: SELECT NombreCurso, COUNT(*) as Cantidad FROM Alumnos GROUP BY NombreCurso HAVING COUNT(*) > 3
WriteLine("\n*** Cursos con más de 3 alumnos (HAVING) ***");
var cursosConMasDe3 = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .Where(g => g.Count() > 3)
    .ToDictionary(g => g.Key, g => g.Count());

foreach (var item in cursosConMasDe3) 
    WriteLine($"{item.Key}: {item.Value} alumnos");

// Obtener cursos con nota media mayor a 8 (HAVING)
// SQL: SELECT NombreCurso, AVG(Nota) as Media FROM Alumnos GROUP BY NombreCurso HAVING AVG(Nota) > 8
WriteLine("\n*** Cursos con nota media mayor a 8 (HAVING) ***");
var cursosNotaAlta = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .Where(g => g.Average(a => a.Nota) > 8)
    .ToDictionary(g => g.Key, g => g.Average(a => a.Nota));

foreach (var item in cursosNotaAlta) 
    WriteLine($"{item.Key}: Media = {item.Value:F2}");

// Obtener los 3 primeros alumnos ordenados por nota
// SQL: SELECT TOP 3 * FROM Alumnos ORDER BY Nota DESC
WriteLine("\n*** Los 3 primeros alumnos por nota ***");
var tresPrimerosPorNota = listaAlumnos
    .OrderByDescending(a => a.Nota)
    .Take(3);

foreach (var a in tresPrimerosPorNota) 
    WriteLine(a);

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar página 1 (5 elementos por página)
// SQL: SELECT TOP 5 * FROM Alumnos OFFSET 0 ROWS
WriteLine("\n*** Página 1 (5 elementos) ***");
var pagina1 = listaAlumnos
    .Take(5);

foreach (var a in pagina1) 
    WriteLine(a);

// Paginación: mostrar página 2 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 2 (siguientes 5 elementos) ***");
var pagina2 = listaAlumnos
    .Skip(5)
    .Take(5);

foreach (var a in pagina2) 
    WriteLine(a);

// Paginación: mostrar página 3 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 10 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 3 (últimos 5 elementos) ***");
var pagina3 = listaAlumnos
    .Skip(10)
    .Take(5);

foreach (var a in pagina3) 
    WriteLine(a);

// ============================================================
// CONSULTAS DE VERIFICACIÓN (ANY, ALL)
// ============================================================

// Verificar si existe algún alumno con nota 10
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Alumnos WHERE Nota = 10) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún alumno con nota 10? ***");
var hayNota10 = listaAlumnos
    .Any(a => a.Nota == 10);

WriteLine(hayNota10 ? "Sí, hay alumnos con nota 10" : "No hay alumnos con nota 10");

// Verificar si todos los alumnos son mayores de edad
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Alumnos WHERE Edad >= 18) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los alumnos son mayores de edad? ***");
var todosMayores = listaAlumnos
    .All(a => a.Edad >= 18);

WriteLine(todosMayores ? "Sí, todos son mayores de edad" : "No todos son mayores de edad");

// Obtener un alumno específico por su ID
// SQL: SELECT TOP 1 * FROM Alumnos WHERE Id = 5
WriteLine("\n*** Obtener alumno con ID = 5 ***");
var alumnoId5 = listaAlumnos
    .SingleOrDefault(a => a.Id == 5);

WriteLine(alumnoId5?.ToString() ?? "No encontrado");

// Verificar si hay exactamente un alumnollamada "Ana"
// SQL: SELECT COUNT(*) FROM Alumnos WHERE Nombre = 'Ana'
WriteLine("\n*** ¿Hay exactamente una alumna llamada Ana? ***");
var unaAna = listaAlumnos
    .Count(a => a.Nombre == "Ana");

WriteLine(unaAna == 1 ? "Sí, hay exactamente una Ana" : $"Hay {unaAna} Anas");

// Obtener cursos únicos
// SQL: SELECT DISTINCT NombreCurso FROM Alumnos
WriteLine("\n*** Cursos únicos ***");
var cursosUnicos = listaAlumnos
    .Select(a => a.NombreCurso)
    .Distinct();

foreach (var c in cursosUnicos) 
    WriteLine(c);

// Obtener la nota más alta
// SQL: SELECT MAX(Nota) FROM Alumnos
WriteLine("\n*** Nota más alta ***");
var notaMaxima = listaAlumnos
    .Max(a => a.Nota);

WriteLine($"La nota más alta es: {notaMaxima}");

// Obtener la nota más baja
// SQL: SELECT MIN(Nota) FROM Alumnos
WriteLine("\n*** Nota más baja ***");
var notaMinima = listaAlumnos
    .Min(a => a.Nota);

WriteLine($"La nota más baja es: {notaMinima}");

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Alumnos con nota >= 7 Y curso = Java 8
// SQL: SELECT * FROM Alumnos WHERE Nota >= 7 AND NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos con nota >= 7 y curso Java 8 ***");
var alumnosNota7Java8 = listaAlumnos
    .Where(a => a.Nota >= 7)
    .Where(a => a.NombreCurso == "Java 8");

foreach (var a in alumnosNota7Java8) 
    WriteLine(a);

// Alumnos menores de 20 años O con nota >= 9
// SQL: SELECT * FROM Alumnos WHERE Edad < 20 OR Nota >= 9
WriteLine("\n*** Alumnos menores de 20 años o con nota >= 9 ***");
var jovenesOExcelentes = listaAlumnos
    .Where(a => a.Edad < 20 || a.Nota >= 9);

foreach (var a in jovenesOExcelentes) 
    WriteLine(a);

// Alumnos con nombre que contiene 'o' Y apellido que contiene 'z'
// SQL: SELECT * FROM Alumnos WHERE Nombre LIKE '%o%' AND Apellidos LIKE '%z%'
WriteLine("\n*** Alumnos con 'o' en nombre y 'z' en apellido ***");
var condicionDoble = listaAlumnos
    .Where(a => a.Nombre.Contains("o", StringComparison.OrdinalIgnoreCase))
    .Where(a => a.Apellidos.Contains("z", StringComparison.OrdinalIgnoreCase));

foreach (var a in condicionDoble) 
    WriteLine(a);

// Alumnos del curso Python O Ruby (múltiples valores en WHERE)
// SQL: SELECT * FROM Alumnos WHERE NombreCurso IN ('Python', 'Ruby')
WriteLine("\n*** Alumnos de cursos Python o Ruby ***");
var cursosIncluidos = new[] { "Python", "Ruby" };
var alumnosPythonRuby = listaAlumnos
    .Where(a => cursosIncluidos.Contains(a.NombreCurso));

foreach (var a in alumnosPythonRuby) 
    WriteLine(a);

// Alumnos cuyo curso NO es Java 8 NI PHP
// SQL: SELECT * FROM Alumnos WHERE NombreCurso NOT IN ('Java 8', 'PHP')
WriteLine("\n*** Alumnos que NO son de Java 8 ni PHP ***");
var cursosExcluidos = new[] { "Java 8", "PHP" };
var alumnosNoJava8PHP = listaAlumnos
    .Where(a => !cursosExcluidos.Contains(a.NombreCurso));

foreach (var a in alumnosNoJava8PHP) 
    WriteLine(a);

// Alumnos con edad entre 15 y 25 años (BETWEEN)
// SQL: SELECT * FROM Alumnos WHERE Edad BETWEEN 15 AND 25
WriteLine("\n*** Alumnos con edad entre 15 y 25 años ***");
var alumnosEdadRango = listaAlumnos
    .Where(a => a.Edad >= 15)
    .Where(a => a.Edad <= 25);

foreach (var a in alumnosEdadRango) 
    WriteLine(a);

// Alumnos con nota entre 7 y 9 (excluyendo los extremos)
// SQL: SELECT * FROM Alumnos WHERE Nota > 7 AND Nota < 9
WriteLine("\n*** Alumnos con nota entre 7 y 9 ***");
var notaEntre7y9 = listaAlumnos
    .Where(a => a.Nota > 7)
    .Where(a => a.Nota < 9);

foreach (var a in notaEntre7y9) 
    WriteLine(a);

// Múltiples Where encadenados: filtrar Y luego ordenar
// SQL: SELECT * FROM Alumnos WHERE Nota >= 8 ORDER BY Nota DESC
WriteLine("\n*** Encadenar múltiples Where (nota >= 8 y luego mayores de 20) ***");
var multiplesWhere = listaAlumnos
    .Where(a => a.Nota >= 8)
    .Where(a => a.Edad > 20)
    .OrderByDescending(a => a.Nota);

foreach (var a in multiplesWhere) 
    WriteLine(a);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: obtener nombre completo y nota como tipo anónimo
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as NombreCompleto, Nota FROM Alumnos
WriteLine("\n*** Proyección: nombre completo y nota ***");
var proyeccionesNombreNota = listaAlumnos
    .Select(a => new { NombreCompleto = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota });

foreach (var item in proyeccionesNombreNota) 
    WriteLine($"{item.NombreCompleto}: {item.Nota}");

// Proyección: crear objeto con información resumida del alumno
// SQL: SELECT Id, CONCAT(Nombre, ' ', Apellidos) as DisplayName, LEFT(NombreCurso, 3) as CursoCorto FROM Alumnos
WriteLine("\n*** Proyección: información resumida ***");
var infoResumida = listaAlumnos
    .Select(a => new
    {
        Id = a.Id,
        DisplayName = $"{a.Nombre} {a.Apellidos}",
        CursoCorto = a.NombreCurso.Length >= 3 ? a.NombreCurso.Substring(0, 3) : a.NombreCurso
    });

foreach (var item in infoResumida) 
    WriteLine($"ID: {item.Id}, Nombre: {item.DisplayName}, Curso: {item.CursoCorto}");

// Proyección: calcular si el alumno aprueba o suspende
// SQL: SELECT Nombre, Nota, CASE WHEN Nota >= 5 THEN 'Aprobado' ELSE 'Suspendido' END as Estado FROM Alumnos
WriteLine("\n*** Proyección: estado académico ***");
var estadoAcademico = listaAlumnos
    .Select(a => new
    {
        Nombre = a.Nombre,
        Nota = a.Nota,
        Estado = a.Nota >= 5 ? "Aprobado" : "Suspendido"
    });

foreach (var item in estadoAcademico) 
    WriteLine($"{item.Nombre}: Nota={item.Nota}, Estado={item.Estado}");

// Proyección múltiple: filtrar Y proyectar en un solo paso
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as Nombre, Nota FROM Alumnos WHERE Nota >= 9
WriteLine("\n*** Filtrar y proyectar en un solo paso ***");
var filtroYProyeccion = listaAlumnos
    .Where(a => a.Nota >= 9)
    .Select(a => new { Nombre = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota });

foreach (var item in filtroYProyeccion) 
    WriteLine($"{item.Nombre}: {item.Nota}");

// Proyección con cálculo: nota sobre 10 convertida a porcentaje
// SQL: SELECT Nombre, (Nota * 10) as Porcentaje FROM Alumnos
WriteLine("\n*** Proyección con cálculo: nota en porcentaje ***");
var notaPorcentaje = listaAlumnos
    .Select(a => new { Nombre = a.Nombre, Porcentaje = a.Nota * 10 });

foreach (var item in notaPorcentaje) 
    WriteLine($"{item.Nombre}: {item.Porcentaje}%");

// Proyección con múltiples propiedades calculadas
// SQL: SELECT Nombre, Nota, Nota * 10 as Sobre100, CASE WHEN Nota >= 5 THEN 1 ELSE 0 END as Aprobado FROM Alumnos
WriteLine("\n*** Proyección con múltiples cálculos ***");
var proyeccionesCalculadas = listaAlumnos
    .Select(a => new
    {
        Nombre = a.Nombre,
        Nota = a.Nota,
        Sobre100 = a.Nota * 10,
        Aprobado = a.Nota >= 5 ? "Sí" : "No"
    });

foreach (var item in proyeccionesCalculadas) 
    WriteLine($"{item.Nombre}: Nota={item.Nota}, Sobre100={item.Sobre100}, Aprobado={item.Aprobado}");

// Proyección en grupo: obtener estudiantes destacados por curso
// SQL: SELECT NombreCurso, MAX(Nota) as MejorNota FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Proyección en grupo: mejor nota por curso ***");
var mejorPorCursoProyeccion = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(
        g => g.Key,
        g => new
        {
            MejorNota = g.Max(a => a.Nota),
            MejorAlumno = g.MaxBy(a => a.Nota)?.Nombre
        }
    );

foreach (var item in mejorPorCursoProyeccion)
    WriteLine($"{item.Key}: Mejor={item.Value.MejorAlumno} ({item.Value.MejorNota})");

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
EL PELIGRO DE LA EVALUACIÓN DIFERIDA (Lazy Evaluation):
    LINQ no ejecuta la consulta cuando la defines, sino cuando la recorres (foreach, Count, etc.).
    Esto es muy eficiente, pero puede dar resultados inesperados si la lista original cambia.

¿CUÁNDO USAR .ToList()?
1. Cuando quieres "congelar" los resultados en ese momento.
2. Para evitar múltiples ejecuciones de la misma consulta pesada (rendimiento).
3. Cuando necesitas acceso por índice [i] o métodos de List<T> (Add, Remove).

REGLA DE ORO PROFESIONAL:
Mantén el flujo IEnumerable lo más lejos posible. Solo materializa (.ToList) cuando sea estrictamente necesario.
*/

WriteLine("\n*** Ejemplo: Deferred Execution sin .ToList() ***");
var consultaDiferida = listaAlumnos
    .Where(a => a.Nota > 8);

WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Elementos antes de agregar: {consultaDiferida.Count()}");

listaAlumnos.Add(new Alumno(99, "9999999999", "Nuevo", "Alumno", "Python", 10, 20));
WriteLine("Nuevo alumno agregado");
WriteLine($"Elementos después de agregar: {consultaDiferida.Count()} (¡Incluye el nuevo!)");

WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = listaAlumnos
    .Where(a => a.Nota > 8)
    .ToList();

WriteLine("Consulta ejecutada con .ToList()");

listaAlumnos.Add(new Alumno(100, "9999999998", "Otro", "Nuevo", "Python", 10, 21));
WriteLine("Nuevo alumno agregado");
WriteLine($"Elementos de la lista materializada: {consultaInmediata.Count} (¡NO incluye el nuevo!)");

WriteLine("\n=== FIN ===");
