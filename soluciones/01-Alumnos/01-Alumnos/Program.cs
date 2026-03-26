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
listaAlumnos.ForEach(WriteLine);

// Obtener los alumnos cuyo apellido empieza por L o G
// SQL: SELECT * FROM Alumnos WHERE Apellidos LIKE 'L%' OR Apellidos LIKE 'G%'
WriteLine("\n*** Alumnos cuyo apellido empiezan con L o G ***");
var alumnosApellidoL_O_G = listaAlumnos
    .Where(a => a.Apellidos.StartsWith("L") || a.Apellidos.StartsWith("G"))
    .ToList();

alumnosApellidoL_O_G.ForEach(WriteLine);

// Contar el número total de alumnos
// SQL: SELECT COUNT(*) FROM Alumnos
WriteLine("\n*** Número de Alumnos ***");
var numeroAlumnos = listaAlumnos.Count();

WriteLine(numeroAlumnos);

// Obtener los alumnos con nota mayor a 9 y que sean del curso PHP
// SQL: SELECT * FROM Alumnos WHERE Nota > 9 AND NombreCurso = 'PHP'
WriteLine("\n*** Alumnos con nota mayor a 9 y que sean del curso PHP ***");
var alumnosNotaMayor9PHP = listaAlumnos
    .Where(a => a.Nota > 9 && a.NombreCurso == "PHP")
    .ToList();

alumnosNotaMayor9PHP.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE ELEMENTOS (TAKE, FIRST, SINGLE)
// ============================================================

// Obtener los 2 primeros alumnos de la lista
// SQL: SELECT TOP 2 * FROM Alumnos
WriteLine("\n*** Imprimir los 2 primeros Alumnos de la lista ***");
var dosPrimerosAlumnos = listaAlumnos.Take(2).ToList();

dosPrimerosAlumnos.ForEach(WriteLine);

// Obtener el alumno con menor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad ASC
WriteLine("\n*** Imprimir el alumno con menor edad ***");
var alumnoMenorEdad = listaAlumnos.MinBy(a => a.Edad);

WriteLine(alumnoMenorEdad);

// Obtener el alumno con mayor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad DESC
WriteLine("\n*** Imprimir el alumno con mayor edad ***");
var alumnoMayorEdad = listaAlumnos.MaxBy(a => a.Edad);

WriteLine(alumnoMayorEdad);

// Obtener el primer alumno de la lista
// SQL: SELECT TOP 1 * FROM Alumnos
WriteLine("\n*** Encontrar el primer Alumno ***");
var primerAlumno = listaAlumnos.First();

WriteLine(primerAlumno);

// Obtener los alumnos cuyo nombre de curso contiene la letra A
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Alumnos que tienen un curso cuyo nombre contiene la A ***");
var alumnosCursoConA = listaAlumnos
    .Where(a => a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase))
    .ToList();

alumnosCursoConA.ForEach(WriteLine);

// Obtener los alumnos cuyo nombre tiene más de 10 caracteres
// SQL: SELECT * FROM Alumnos WHERE LEN(Nombre) > 10
WriteLine("\n*** Alumnos cuyo nombre tiene más de 10 caracteres ***");
var alumnosNombreLargo = listaAlumnos
    .Where(a => a.Nombre.Length > 10)
    .ToList();

alumnosNombreLargo.ForEach(WriteLine);

// Obtener los alumnos cuyo curso empieza por P y tiene longitud menor o igual a 6
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE 'P%' AND LEN(NombreCurso) <= 6
WriteLine("\n*** Combinación de predicados: curso que empieza por P y longitud <= 6 ***");
var alumnosCombinados = listaAlumnos
    .Where(a => a.NombreCurso.ToUpper().StartsWith("P") && a.NombreCurso.Length <= 6)
    .ToList();

alumnosCombinados.ForEach(WriteLine);

// Copiar a una nueva lista los alumnos cuyo curso contiene la letra A
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Copia de datos filtrados a otra lista ***");
var nuevaLista = listaAlumnos
    .Where(a => a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase))
    .ToList();

nuevaLista.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE ESTADÍSTICAS Y AGREGACIÓN (COUNT, SUM, AVG, MIN, MAX)
// ============================================================

// Obtener estadísticas de las notas: count, average, max, min
// SQL: SELECT COUNT(Nota), AVG(Nota), MAX(Nota), MIN(Nota) FROM Alumnos
WriteLine("\n*** Estadísticas de notas ***");
var notas = listaAlumnos.Select(a => a.Nota).ToList();

WriteLine($"Count: {notas.Count}");
WriteLine($"Average: {notas.Average():F2}");
WriteLine($"Max: {notas.Max()}");
WriteLine($"Min: {notas.Min()}");

// Obtener los alumnos que son del curso Java 8
// SQL: SELECT * FROM Alumnos WHERE NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos del curso Java 8 ***");
var alumnosJava8 = listaAlumnos
    .Where(a => a.NombreCurso == "Java 8")
    .ToList();

alumnosJava8.ForEach(WriteLine);

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
    .GroupBy(a => a.NombreCurso)
    .ToList();

alumnosPorCurso.ForEach(g =>
{
    WriteLine($"\nCurso: {g.Key}");
    g.ToList().ForEach(WriteLine);
});

// Calcular la nota media por curso
// SQL: SELECT NombreCurso, AVG(Nota) FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Nota media por curso ***");
var notaMediaPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(g => g.Key, g => g.Average(a => a.Nota));

notaMediaPorCurso.ToList().ForEach(g => WriteLine($"{g.Key}: {g.Value:F2}"));

// Agrupar por curso y obtener el mejor alumno de cada uno
// SQL: SELECT * FROM Alumnos WHERE Nota = (SELECT MAX(Nota) FROM Alumnos a2 WHERE a2.NombreCurso = Alumnos.NombreCurso)
WriteLine("\n*** Mejor alumno de cada curso ***");
var mejorPorCurso = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .Select(g => g.MaxBy(a => a.Nota))
    .ToList();

mejorPorCurso.ForEach(WriteLine);

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

mejorPeorPorCurso.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Mejor={kv.Value.Mejor} ({kv.Value.MejorAlumno}), Peor={kv.Value.Minimo} ({kv.Value.MinimoAlumno})"));

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

estadisticasPorCurso.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Max={kv.Value.Maxima:F2}, Min={kv.Value.Minima:F2}, Media={kv.Value.Media:F2}, Cantidad={kv.Value.Cantidad}"));

// Obtener cursos con más de 3 alumnos (HAVING)
// SQL: SELECT NombreCurso, COUNT(*) as Cantidad FROM Alumnos GROUP BY NombreCurso HAVING COUNT(*) > 3
WriteLine("\n*** Cursos con más de 3 alumnos (HAVING) ***");
var cursosConMasDe3 = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(g => g.Key, g => g.Count())
    .Where(kv => kv.Value > 3)
    .ToList();

cursosConMasDe3.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} alumnos"));

// Obtener cursos con nota media mayor a 8 (HAVING)
// SQL: SELECT NombreCurso, AVG(Nota) as Media FROM Alumnos GROUP BY NombreCurso HAVING AVG(Nota) > 8
WriteLine("\n*** Cursos con nota media mayor a 8 (HAVING) ***");
var cursosNotaAlta = listaAlumnos
    .GroupBy(a => a.NombreCurso)
    .ToDictionary(g => g.Key, g => g.Average(a => a.Nota))
    .Where(kv => kv.Value > 8)
    .ToList();

cursosNotaAlta.ForEach(kv => WriteLine($"{kv.Key}: Media = {kv.Value:F2}"));

// Obtener los 3 primeros alumnos ordenados por nota
// SQL: SELECT TOP 3 * FROM Alumnos ORDER BY Nota DESC
WriteLine("\n*** Los 3 primeros alumnos por nota ***");
var tresPrimerosPorNota = listaAlumnos
    .OrderByDescending(a => a.Nota)
    .Take(3)
    .ToList();

tresPrimerosPorNota.ForEach(WriteLine);

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP)
// ============================================================

// Paginación: mostrar página 1 (5 elementos por página)
// SQL: SELECT TOP 5 * FROM Alumnos OFFSET 0 ROWS
WriteLine("\n*** Página 1 (5 elementos) ***");
var pagina1 = listaAlumnos
    .Take(5)
    .ToList();

pagina1.ForEach(WriteLine);

// Paginación: mostrar página 2 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 2 (siguientes 5 elementos) ***");
var pagina2 = listaAlumnos
    .Skip(5)
    .Take(5)
    .ToList();

pagina2.ForEach(WriteLine);

// Paginación: mostrar página 3 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 10 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 3 (últimos 5 elementos) ***");
var pagina3 = listaAlumnos
    .Skip(10)
    .Take(5)
    .ToList();

pagina3.ForEach(WriteLine);

// Verificar si existe algún alumno con nota 10
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Alumnos WHERE Nota = 10) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún alumno con nota 10? ***");
var hayNota10 = listaAlumnos.Any(a => a.Nota == 10);

WriteLine(hayNota10 ? "Sí, hay alumnos con nota 10" : "No hay alumnos con nota 10");

// Verificar si todos los alumnos son mayores de edad
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Alumnos WHERE Edad >= 18) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los alumnos son mayores de edad? ***");
var todosMayores = listaAlumnos.All(a => a.Edad >= 18);

WriteLine(todosMayores ? "Sí, todos son mayores de edad" : "No todos son mayores de edad");

// Obtener un alumno específico por su ID
// SQL: SELECT TOP 1 * FROM Alumnos WHERE Id = 5
WriteLine("\n*** Obtener alumno con ID = 5 ***");
var alumnoId5 = listaAlumnos.SingleOrDefault(a => a.Id == 5);

WriteLine(alumnoId5?.ToString() ?? "No encontrado");

// Verificar si hay exactamente un alumno con nombre "Ana"
// SQL: SELECT COUNT(*) FROM Alumnos WHERE Nombre = 'Ana'
WriteLine("\n*** ¿Hay exactamente una alumna llamada Ana? ***");
var unaAna = listaAlumnos.Count(a => a.Nombre == "Ana");

WriteLine(unaAna == 1 ? "Sí, hay exactamente una Ana" : $"Hay {unaAna} Anas");

// Obtener cursos únicos
// SQL: SELECT DISTINCT NombreCurso FROM Alumnos
WriteLine("\n*** Cursos únicos ***");
var cursosUnicos = listaAlumnos
    .Select(a => a.NombreCurso)
    .Distinct()
    .ToList();

cursosUnicos.ForEach(WriteLine);

// Obtener la nota más alta
// SQL: SELECT MAX(Nota) FROM Alumnos
WriteLine("\n*** Nota más alta ***");
var notaMaxima = listaAlumnos.Max(a => a.Nota);

WriteLine($"La nota más alta es: {notaMaxima}");

// Obtener la nota más baja
// SQL: SELECT MIN(Nota) FROM Alumnos
WriteLine("\n*** Nota más baja ***");
var notaMinima = listaAlumnos.Min(a => a.Nota);

WriteLine($"La nota más baja es: {notaMinima}");

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS)
// ============================================================

// Alumnos con nota >= 7 Y curso = Java 8
// SQL: SELECT * FROM Alumnos WHERE Nota >= 7 AND NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos con nota >= 7 y curso Java 8 ***");
var alumnosNota7Java8 = listaAlumnos
    .Where(a => a.Nota >= 7 && a.NombreCurso == "Java 8")
    .ToList();

alumnosNota7Java8.ForEach(WriteLine);

// Alumnos menores de 20 años O con nota >= 9
// SQL: SELECT * FROM Alumnos WHERE Edad < 20 OR Nota >= 9
WriteLine("\n*** Alumnos menores de 20 años o con nota >= 9 ***");
var jovenesOExcelentes = listaAlumnos
    .Where(a => a.Edad < 20 || a.Nota >= 9)
    .ToList();

jovenesOExcelentes.ForEach(WriteLine);

// Alumnos con nombre que contiene 'o' Y apellido que contiene 'z'
// SQL: SELECT * FROM Alumnos WHERE Nombre LIKE '%o%' AND Apellidos LIKE '%z%'
WriteLine("\n*** Alumnos con 'o' en nombre y 'z' en apellido ***");
var condicionDoble = listaAlumnos
    .Where(a => a.Nombre.Contains("o", StringComparison.OrdinalIgnoreCase)
                && a.Apellidos.Contains("z", StringComparison.OrdinalIgnoreCase))
    .ToList();

condicionDoble.ForEach(WriteLine);

// Alumnos del curso Python O Ruby (múltiples valores en WHERE)
// SQL: SELECT * FROM Alumnos WHERE NombreCurso IN ('Python', 'Ruby')
WriteLine("\n*** Alumnos de cursos Python o Ruby ***");
var cursosIncluidos = new[] { "Python", "Ruby" };
var alumnosPythonRuby = listaAlumnos
    .Where(a => cursosIncluidos.Contains(a.NombreCurso))
    .ToList();

alumnosPythonRuby.ForEach(WriteLine);

// Alumnos cuyo curso NO es Java 8 NI PHP
// SQL: SELECT * FROM Alumnos WHERE NombreCurso NOT IN ('Java 8', 'PHP')
WriteLine("\n*** Alumnos que NO son de Java 8 ni PHP ***");
var cursosExcluidos = new[] { "Java 8", "PHP" };
var alumnosNoJava8PHP = listaAlumnos
    .Where(a => !cursosExcluidos.Contains(a.NombreCurso))
    .ToList();

alumnosNoJava8PHP.ForEach(WriteLine);

// Alumnos con edad entre 15 y 25 años (BETWEEN)
// SQL: SELECT * FROM Alumnos WHERE Edad BETWEEN 15 AND 25
WriteLine("\n*** Alumnos con edad entre 15 y 25 años ***");
var alumnosEdadRango = listaAlumnos
    .Where(a => a.Edad >= 15 && a.Edad <= 25)
    .ToList();

alumnosEdadRango.ForEach(WriteLine);

// Alumnos con nota entre 7 y 9 (excluyendo los extremos)
// SQL: SELECT * FROM Alumnos WHERE Nota > 7 AND Nota < 9
WriteLine("\n*** Alumnos con nota entre 7 y 9 ***");
var notaEntre7y9 = listaAlumnos
    .Where(a => a.Nota > 7 && a.Nota < 9)
    .ToList();

notaEntre7y9.ForEach(WriteLine);

// Múltiples Where encadenados: filtrar Y luego ordenar
// SQL: SELECT * FROM Alumnos WHERE Nota >= 8 ORDER BY Nota DESC
WriteLine("\n*** Encadenar múltiples Where (nota >= 8 y luego mayores de 20) ***");
var multiplesWhere = listaAlumnos
    .Where(a => a.Nota >= 8)
    .Where(a => a.Edad > 20)
    .OrderByDescending(a => a.Nota)
    .ToList();

multiplesWhere.ForEach(WriteLine);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS
// ============================================================

// Proyección: obtener nombre completo y nota como tipo anónimo
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as NombreCompleto, Nota FROM Alumnos
WriteLine("\n*** Proyección: nombre completo y nota ***");
var proyeccionesNombreNota = listaAlumnos
    .Select(a => new { NombreCompleto = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota })
    .ToList();

proyeccionesNombreNota.ForEach(n => WriteLine($"{n.NombreCompleto}: {n.Nota}"));

// Proyección: crear objeto con información resumida del alumno
// SQL: SELECT Id, CONCAT(Nombre, ' ', Apellidos) as DisplayName, LEFT(NombreCurso, 3) as CursoCorto FROM Alumnos
WriteLine("\n*** Proyección: información resumida ***");
var infoResumida = listaAlumnos
    .Select(a => new
    {
        Id = a.Id,
        DisplayName = $"{a.Nombre} {a.Apellidos}",
        CursoCorto = a.NombreCurso.Length >= 3 ? a.NombreCurso.Substring(0, 3) : a.NombreCurso
    })
    .ToList();

infoResumida.ForEach(i => WriteLine($"ID: {i.Id}, Nombre: {i.DisplayName}, Curso: {i.CursoCorto}"));

// Proyección: calcular si el alumno aprueba o suspende
// SQL: SELECT Nombre, Nota, CASE WHEN Nota >= 5 THEN 'Aprobado' ELSE 'Suspendido' END as Estado FROM Alumnos
WriteLine("\n*** Proyección: estado académico ***");
var estadoAcademico = listaAlumnos
    .Select(a => new
    {
        Nombre = a.Nombre,
        Nota = a.Nota,
        Estado = a.Nota >= 5 ? "Aprobado" : "Suspendido"
    })
    .ToList();

estadoAcademico.ForEach(e => WriteLine($"{e.Nombre}: Nota={e.Nota}, Estado={e.Estado}"));

// Proyección múltiple: filtrar Y proyectar en un solo paso
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as Nombre, Nota FROM Alumnos WHERE Nota >= 9
WriteLine("\n*** Filtrar y proyectar en un solo paso ***");
var filtroYProyeccion = listaAlumnos
    .Where(a => a.Nota >= 9)
    .Select(a => new { Nombre = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota })
    .ToList();

filtroYProyeccion.ForEach(p => WriteLine($"{p.Nombre}: {p.Nota}"));

// Proyección con cálculo: nota sobre 10 convertida a porcentaje
// SQL: SELECT Nombre, (Nota * 10) as Porcentaje FROM Alumnos
WriteLine("\n*** Proyección con cálculo: nota en porcentaje ***");
var notaPorcentaje = listaAlumnos
    .Select(a => new { Nombre = a.Nombre, Porcentaje = a.Nota * 10 })
    .ToList();

notaPorcentaje.ForEach(n => WriteLine($"{n.Nombre}: {n.Porcentaje}%"));

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
    })
    .ToList();

proyeccionesCalculadas.ForEach(p => WriteLine($"{p.Nombre}: Nota={p.Nota}, Sobre100={p.Sobre100}, Aprobado={p.Aprobado}"));

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

mejorPorCursoProyeccion.ToList().ForEach(kv => WriteLine($"{kv.Key}: Mejor={kv.Value.MejorAlumno} ({kv.Value.MejorNota})"));

// ============================================================
// EXPLICACIÓN: ¿POR QUÉ USAR .ToList()?
// ============================================================

/*
LINQ utiliza EJECUCIÓN DIFERIDA (Deferred Execution):
- Las consultas no se ejecutan inmediatamente
- Se ejecutan cuando se ITERA sobre el resultado
- Cada operador (Where, Select, OrderBy) devuelve una secuencia NO ejecutada

EJEMPLO DE PROBLEMA SIN .ToList():
    var consulta = listaAlumnos.Where(a => a.Nota > 7);
    listaAlumnos.Add(new Alumno(...)); // ¡La consulta still no se ha ejecutado!
    consulta.ForEach(...); // AHORA se ejecuta, incluyendo el nuevo alumno

CON .ToList():
    var consulta = listaAlumnos.Where(a => a.Nota > 7).ToList();
    listaAlumnos.Add(new Alumno(...)); // La consulta YA se ejecutó
    // consulta ya tiene los resultados, no incluye el nuevo alumno

¿CUÁNDO USAR .ToList()?
1. Cuando quieres "congelar" los resultados en ese momento
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
- .Foreach() (en algunos casos)
*/

// Ejemplo práctico de deferred execution
WriteLine("\n*** Ejemplo: Deferred Execution sin .ToList() ***");
var consultaDiferida = listaAlumnos.Where(a => a.Nota > 8);
WriteLine("Consulta creada (no ejecutada)");
WriteLine($"Elementos antes de agregar: {consultaDiferida.Count()}");

// Modificamos la lista original
listaAlumnos.Add(new Alumno(99, "9999999999", "Nuevo", "Alumno", "Python", 9.5, 20));
WriteLine("Nuevo alumno agregado");

WriteLine($"Elementos después de agregar: {consultaDiferida.Count()}");
// La consulta se ha ejecutado DOS veces (sin caché)

// Ejemplo con .ToList() - ejecución inmediata
WriteLine("\n*** Ejemplo: Ejecución inmediata con .ToList() ***");
var consultaInmediata = listaAlumnos.Where(a => a.Nota > 8).ToList();
WriteLine("Consulta ejecutada con .ToList()");

listaAlumnos.Add(new Alumno(100, "9999999998", "Otro", "Nuevo", "Python", 10, 21));
WriteLine("Nuevo alumno agregado");

WriteLine($"Elementos en la lista: {consultaInmediata.Count()}");
// La lista ya tiene los resultados "congelados"
