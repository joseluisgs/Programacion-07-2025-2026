using System.Linq;
using static System.Console;
using _08_AlumnosLINQ.Models;

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
// CONSULTAS BÁSICAS DE SELECCIÓN (WHERE) - QUERY SYNTAX
// ============================================================

// Obtener todos los alumnos de la lista
// SQL: SELECT * FROM Alumnos
WriteLine("*** Lista de Alumnos ***");
var todosAlumnos = from a in listaAlumnos
                   select a;
foreach (var alumno in todosAlumnos) WriteLine(alumno);

// Obtener los alumnos cuyo apellido empieza por L o G
// SQL: SELECT * FROM Alumnos WHERE Apellidos LIKE 'L%' OR Apellidos LIKE 'G%'
WriteLine("\n*** Alumnos cuyo apellido empiezan con L o G ***");
var alumnosApellidoL_O_G = from a in listaAlumnos
                           where a.Apellidos.StartsWith("L") || a.Apellidos.StartsWith("G")
                           select a;
foreach (var alumno in alumnosApellidoL_O_G) WriteLine(alumno);

// Contar el número total de alumnos
// SQL: SELECT COUNT(*) FROM Alumnos
WriteLine("\n*** Número de Alumnos ***");
var numeroAlumnos = (from a in listaAlumnos
                     select a).Count();
WriteLine(numeroAlumnos);

// Obtener los alumnos con nota mayor a 9 y que sean del curso PHP
// SQL: SELECT * FROM Alumnos WHERE Nota > 9 AND NombreCurso = 'PHP'
WriteLine("\n*** Alumnos con nota mayor a 9 y que sean del curso PHP ***");
var alumnosNotaMayor9PHP = from a in listaAlumnos
                           where a.Nota > 9 && a.NombreCurso == "PHP"
                           select a;
foreach (var alumno in alumnosNotaMayor9PHP) WriteLine(alumno);

// ============================================================
// CONSULTAS DE ELEMENTOS (TAKE, FIRST, SINGLE) - QUERY SYNTAX
// ============================================================

// Obtener los 2 primeros alumnos de la lista
// SQL: SELECT TOP 2 * FROM Alumnos
WriteLine("\n*** Imprimir los 2 primeros Alumnos de la lista ***");
var dosPrimerosAlumnos = (from a in listaAlumnos
                          select a).Take(2);
foreach (var alumno in dosPrimerosAlumnos) WriteLine(alumno);

// Obtener el alumno con menor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad ASC
WriteLine("\n*** Imprimir el alumno con menor edad ***");
var alumnoMenorEdad = (from a in listaAlumnos
                       orderby a.Edad ascending
                       select a).First();
WriteLine(alumnoMenorEdad);

// Obtener el alumno con mayor edad
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Edad DESC
WriteLine("\n*** Imprimir el alumno con mayor edad ***");
var alumnoMayorEdad = (from a in listaAlumnos
                       orderby a.Edad descending
                       select a).First();
WriteLine(alumnoMayorEdad);

// Obtener el primer alumno de la lista
// SQL: SELECT TOP 1 * FROM Alumnos
WriteLine("\n*** Encontrar el primer Alumno ***");
var primerAlumno = (from a in listaAlumnos
                   select a).First();
WriteLine(primerAlumno);

// Obtener los alumnos cuyo nombre de curso contiene la letra A
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Alumnos que tienen un curso cuyo nombre contiene la A ***");
var alumnosCursoConA = from a in listaAlumnos
                       where a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase)
                       select a;
foreach (var alumno in alumnosCursoConA) WriteLine(alumno);

// Obtener los alumnos cuyo nombre tiene más de 10 caracteres
// SQL: SELECT * FROM Alumnos WHERE LEN(Nombre) > 10
WriteLine("\n*** Alumnos cuyo nombre tiene más de 10 caracteres ***");
var alumnosNombreLargo = from a in listaAlumnos
                         where a.Nombre.Length > 10
                         select a;
foreach (var alumno in alumnosNombreLargo) WriteLine(alumno);

// Obtener los alumnos cuyo curso empieza por P y tiene longitud menor o igual a 6
// SQL: SELECT * FROM Alumnos WHERE NombreCurso LIKE 'P%' AND LEN(NombreCurso) <= 6
WriteLine("\n*** Combinación de predicados: curso que empieza por P y longitud <= 6 ***");
var alumnosCombinados = from a in listaAlumnos
                        where a.NombreCurso.ToUpper().StartsWith("P") && a.NombreCurso.Length <= 6
                        select a;
foreach (var alumno in alumnosCombinados) WriteLine(alumno);

// Copiar a una nueva lista los alumnos cuyo curso contiene la letra A
// SQL: SELECT * INTO NuevaLista FROM Alumnos WHERE NombreCurso LIKE '%a%'
WriteLine("\n*** Copia de datos filtrados a otra lista ***");
var nuevaLista = (from a in listaAlumnos
                  where a.NombreCurso.Contains("a", StringComparison.OrdinalIgnoreCase)
                  select a).ToList();
foreach (var alumno in nuevaLista) WriteLine(alumno);

// ============================================================
// CONSULTAS DE ESTADÍSTICAS Y AGREGACIÓN (COUNT, SUM, AVG, MIN, MAX) - QUERY SYNTAX
// ============================================================

// Obtener estadísticas de las notas: count, average, max, min
// SQL: SELECT COUNT(Nota), AVG(Nota), MAX(Nota), MIN(Nota) FROM Alumnos
WriteLine("\n*** Estadísticas de notas ***");
var notas = from a in listaAlumnos
            select a.Nota;
var listaNotas = notas.ToList();
WriteLine($"Count: {listaNotas.Count}");
WriteLine($"Average: {listaNotas.Average():F2}");
WriteLine($"Max: {listaNotas.Max()}");
WriteLine($"Min: {listaNotas.Min()}");

// Obtener los alumnos que son del curso Java 8
// SQL: SELECT * FROM Alumnos WHERE NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos del curso Java 8 ***");
var alumnosJava8 = from a in listaAlumnos
                   where a.NombreCurso == "Java 8"
                   select a;
foreach (var alumno in alumnosJava8) WriteLine(alumno);

// Obtener el mejor alumno (mayor nota)
// SQL: SELECT TOP 1 * FROM Alumnos ORDER BY Nota DESC
WriteLine("\n*** El mejor alumno (mayor nota) ***");
var mejorAlumno = (from a in listaAlumnos
                   orderby a.Nota descending
                   select a).First();
WriteLine(mejorAlumno);

// ============================================================
// CONSULTAS DE AGRUPACIÓN (GROUP BY) - QUERY SYNTAX
// ============================================================

// Agrupar alumnos por curso y mostrar el listado
// SQL: SELECT * FROM Alumnos
WriteLine("\n*** Alumnos agrupados por curso ***");
var alumnosPorCurso = from a in listaAlumnos
                     group a by a.NombreCurso into grupo
                     select grupo;
foreach (var grupo in alumnosPorCurso) 
{
    WriteLine($"\nCurso: {grupo.Key}");
    foreach (var alumno in grupo) WriteLine(alumno);
}

// Calcular la nota media por curso
// SQL: SELECT NombreCurso, AVG(Nota) FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Nota media por curso ***");
var notaMediaPorCurso = from a in listaAlumnos
                        group a by a.NombreCurso into grupo
                        select new { Curso = grupo.Key, Media = grupo.Average(a => a.Nota) };
foreach (var item in notaMediaPorCurso) WriteLine($"{item.Curso}: {item.Media:F2}");

// Agrupar por curso y obtener el mejor alumno de cada uno
// SQL: SELECT * FROM Alumnos WHERE Nota = (SELECT MAX(Nota) FROM Alumnos a2 WHERE a2.NombreCurso = Alumnos.NombreCurso)
WriteLine("\n*** Mejor alumno de cada curso ***");
var mejorPorCurso = from a in listaAlumnos
                    group a by a.NombreCurso into grupo
                    select grupo.MaxBy(a => a.Nota);
foreach (var alumno in mejorPorCurso) WriteLine(alumno);

// Agrupar por curso: mejor y peor alumno
// SQL: SELECT NombreCurso, MAX(Nota) as Mejor, MIN(Nota) as Peor FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Mejor y peor nota por curso ***");
var mejorPeorPorCurso = from a in listaAlumnos
                        group a by a.NombreCurso into grupo
                        select new 
                        { 
                            Curso = grupo.Key, 
                            Mejor = grupo.Max(a => a.Nota), 
                            Minimo = grupo.Min(a => a.Nota),
                            MejorAlumno = grupo.MaxBy(a => a.Nota)?.Nombre,
                            MinimoAlumno = grupo.MinBy(a => a.Nota)?.Nombre
                        };
foreach (var g in mejorPeorPorCurso) 
    WriteLine($"{g.Curso}: Mejor={g.Mejor} ({g.MejorAlumno}), Peor={g.Minimo} ({g.MinimoAlumno})");

// Agrupar por curso: estadísticas completas
// SQL: SELECT NombreCurso, MAX(Nota), MIN(Nota), AVG(Nota), COUNT(*) FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Estadísticas completas por curso ***");
var estadisticasPorCurso = from a in listaAlumnos
                           group a by a.NombreCurso into grupo
                           select new 
                           { 
                               Curso = grupo.Key, 
                               Maxima = grupo.Max(a => a.Nota), 
                               Minima = grupo.Min(a => a.Nota),
                               Media = grupo.Average(a => a.Nota),
                               Cantidad = grupo.Count()
                           };
foreach (var g in estadisticasPorCurso) 
    WriteLine($"{g.Curso}: Max={g.Maxima:F2}, Min={g.Minima:F2}, Media={g.Media:F2}, Cantidad={g.Cantidad}");

// Obtener cursos con más de 3 alumnos (HAVING)
// SQL: SELECT NombreCurso, COUNT(*) as Cantidad FROM Alumnos GROUP BY NombreCurso HAVING COUNT(*) > 3
WriteLine("\n*** Cursos con más de 3 alumnos (HAVING) ***");
var cursosConMasDe3 = from a in listaAlumnos
                      group a by a.NombreCurso into grupo
                      where grupo.Count() > 3
                      select new { Curso = grupo.Key, Cantidad = grupo.Count() };
foreach (var item in cursosConMasDe3) WriteLine($"{item.Curso}: {item.Cantidad} alumnos");

// Obtener cursos con nota media mayor a 8 (HAVING)
// SQL: SELECT NombreCurso, AVG(Nota) as Media FROM Alumnos GROUP BY NombreCurso HAVING AVG(Nota) > 8
WriteLine("\n*** Cursos con nota media mayor a 8 (HAVING) ***");
var cursosNotaAlta = from a in listaAlumnos
                     group a by a.NombreCurso into grupo
                     where grupo.Average(a => a.Nota) > 8
                     select new { Curso = grupo.Key, Media = grupo.Average(a => a.Nota) };
foreach (var item in cursosNotaAlta) WriteLine($"{item.Curso}: Media = {item.Media:F2}");

// Obtener los 3 primeros alumnos ordenados por nota
// SQL: SELECT TOP 3 * FROM Alumnos ORDER BY Nota DESC
WriteLine("\n*** Los 3 primeros alumnos por nota ***");
var tresPrimerosPorNota = (from a in listaAlumnos
                           orderby a.Nota descending
                           select a).Take(3);
foreach (var alumno in tresPrimerosPorNota) WriteLine(alumno);

// ============================================================
// CONSULTAS DE PAGINACIÓN (TAKE, SKIP) - QUERY SYNTAX
// ============================================================

// Paginación: mostrar página 1 (5 elementos por página)
// SQL: SELECT TOP 5 * FROM Alumnos OFFSET 0 ROWS
WriteLine("\n*** Página 1 (5 elementos) ***");
var pagina1 = (from a in listaAlumnos
               select a).Take(5);
foreach (var alumno in pagina1) WriteLine(alumno);

// Paginación: mostrar página 2 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 2 (siguientes 5 elementos) ***");
var pagina2 = (from a in listaAlumnos
               select a).Skip(5).Take(5);
foreach (var alumno in pagina2) WriteLine(alumno);

// Paginación: mostrar página 3 (5 elementos por página)
// SQL: SELECT * FROM Alumnos OFFSET 10 ROWS FETCH NEXT 5 ROWS ONLY
WriteLine("\n*** Página 3 (últimos 5 elementos) ***");
var pagina3 = (from a in listaAlumnos
               select a).Skip(10).Take(5);
foreach (var alumno in pagina3) WriteLine(alumno);

// ============================================================
// CONSULTAS DE VERIFICACIÓN (ANY, ALL) - QUERY SYNTAX
// ============================================================

// Verificar si existe algún alumno con nota 10
// SQL: SELECT CASE WHEN EXISTS(SELECT 1 FROM Alumnos WHERE Nota = 10) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Existe algún alumno con nota 10? ***");
var hayNota10 = (from a in listaAlumnos
                 where a.Nota == 10
                 select a).Any();
WriteLine(hayNota10 ? "Sí, hay alumnos con nota 10" : "No hay alumnos con nota 10");

// Verificar si todos los alumnos son mayores de edad
// SQL: SELECT CASE WHEN COUNT(*) = (SELECT COUNT(*) FROM Alumnos WHERE Edad >= 18) THEN 1 ELSE 0 END
WriteLine("\n*** ¿Todos los alumnos son mayores de edad? ***");
var todosMayores = (from a in listaAlumnos
                    select a).All(a => a.Edad >= 18);
WriteLine(todosMayores ? "Sí, todos son mayores de edad" : "No todos son mayores de edad");

// Obtener un alumno específico por su ID
// SQL: SELECT TOP 1 * FROM Alumnos WHERE Id = 5
WriteLine("\n*** Obtener alumno con ID = 5 ***");
var alumnoId5 = (from a in listaAlumnos
                 where a.Id == 5
                 select a).SingleOrDefault();
WriteLine(alumnoId5?.ToString() ?? "No encontrado");

// Verificar si hay exactamente un alumnollamada "Ana"
// SQL: SELECT COUNT(*) FROM Alumnos WHERE Nombre = 'Ana'
WriteLine("\n*** ¿Hay exactamente una alumna llamada Ana? ***");
var unaAna = (from a in listaAlumnos
              where a.Nombre == "Ana"
              select a).Count();
WriteLine(unaAna == 1 ? "Sí, hay exactamente una Ana" : $"Hay {unaAna} Anas");

// Obtener cursos únicos
// SQL: SELECT DISTINCT NombreCurso FROM Alumnos
WriteLine("\n*** Cursos únicos ***");
var cursosUnicos = (from a in listaAlumnos
                    select a.NombreCurso).Distinct().ToList();
cursosUnicos.ForEach(WriteLine);

// Obtener la nota más alta
// SQL: SELECT MAX(Nota) FROM Alumnos
WriteLine("\n*** Nota más alta ***");
var notaMaxima = (from a in listaAlumnos
                  select a.Nota).Max();
WriteLine($"La nota más alta es: {notaMaxima}");

// Obtener la nota más baja
// SQL: SELECT MIN(Nota) FROM Alumnos
WriteLine("\n*** Nota más baja ***");
var notaMinima = (from a in listaAlumnos
                  select a.Nota).Min();
WriteLine($"La nota más baja es: {notaMinima}");

// ============================================================
// CONSULTAS CON MÚLTIPLES WHERE (COMBINACIÓN DE PREDICADOS) - QUERY SYNTAX
// ============================================================

// Alumnos con nota >= 7 Y curso = Java 8
// SQL: SELECT * FROM Alumnos WHERE Nota >= 7 AND NombreCurso = 'Java 8'
WriteLine("\n*** Alumnos con nota >= 7 y curso Java 8 ***");
var alumnosNota7Java8 = from a in listaAlumnos
                        where a.Nota >= 7 && a.NombreCurso == "Java 8"
                        select a;
foreach (var alumno in alumnosNota7Java8) WriteLine(alumno);

// Alumnos menores de 20 años O con nota >= 9
// SQL: SELECT * FROM Alumnos WHERE Edad < 20 OR Nota >= 9
WriteLine("\n*** Alumnos menores de 20 años o con nota >= 9 ***");
var jovenesOExcelentes = from a in listaAlumnos
                         where a.Edad < 20 || a.Nota >= 9
                         select a;
foreach (var alumno in jovenesOExcelentes) WriteLine(alumno);

// Alumnos con nombre que contiene 'o' Y apellido que contiene 'z'
// SQL: SELECT * FROM Alumnos WHERE Nombre LIKE '%o%' AND Apellidos LIKE '%z%'
WriteLine("\n*** Alumnos con 'o' en nombre y 'z' en apellido ***");
var condicionDoble = from a in listaAlumnos
                     where a.Nombre.Contains("o", StringComparison.OrdinalIgnoreCase) 
                           && a.Apellidos.Contains("z", StringComparison.OrdinalIgnoreCase)
                     select a;
foreach (var alumno in condicionDoble) WriteLine(alumno);

// Alumnos del curso Python O Ruby (múltiples valores en WHERE)
// SQL: SELECT * FROM Alumnos WHERE NombreCurso IN ('Python', 'Ruby')
WriteLine("\n*** Alumnos de cursos Python o Ruby ***");
var cursosIncluidos = new[] { "Python", "Ruby" };
var alumnosPythonRuby = from a in listaAlumnos
                       where cursosIncluidos.Contains(a.NombreCurso)
                       select a;
foreach (var alumno in alumnosPythonRuby) WriteLine(alumno);

// Alumnos cuyo curso NO es Java 8 NI PHP
// SQL: SELECT * FROM Alumnos WHERE NombreCurso NOT IN ('Java 8', 'PHP')
WriteLine("\n*** Alumnos que NO son de Java 8 ni PHP ***");
var cursosExcluidos = new[] { "Java 8", "PHP" };
var alumnosNoJava8PHP = from a in listaAlumnos
                        where !cursosExcluidos.Contains(a.NombreCurso)
                        select a;
foreach (var alumno in alumnosNoJava8PHP) WriteLine(alumno);

// Alumnos con edad entre 15 y 25 años (BETWEEN)
// SQL: SELECT * FROM Alumnos WHERE Edad BETWEEN 15 AND 25
WriteLine("\n*** Alumnos con edad entre 15 y 25 años ***");
var alumnosEdadRango = from a in listaAlumnos
                       where a.Edad >= 15 && a.Edad <= 25
                       select a;
foreach (var alumno in alumnosEdadRango) WriteLine(alumno);

// Alumnos con nota entre 7 y 9 (excluyendo los extremos)
// SQL: SELECT * FROM Alumnos WHERE Nota > 7 AND Nota < 9
WriteLine("\n*** Alumnos con nota entre 7 y 9 ***");
var notaEntre7y9 = from a in listaAlumnos
                   where a.Nota > 7 && a.Nota < 9
                   select a;
foreach (var alumno in notaEntre7y9) WriteLine(alumno);

// Múltiples Where encadenados: filtrar Y luego ordenar
// SQL: SELECT * FROM Alumnos WHERE Nota >= 8 ORDER BY Nota DESC
WriteLine("\n*** Encadenar múltiples Where (nota >= 8 y luego mayores de 20) ***");
var multiplesWhere = from a in listaAlumnos
                      where a.Nota >= 8
                      where a.Edad > 20
                      orderby a.Nota descending
                      select a;
foreach (var alumno in multiplesWhere) WriteLine(alumno);

// ============================================================
// PROYECCIONES CON TIPOS ANÓNIMOS - QUERY SYNTAX
// ============================================================

// Proyección: obtener nombre completo y nota como tipo anónimo
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as NombreCompleto, Nota FROM Alumnos
WriteLine("\n*** Proyección: nombre completo y nota ***");
var proyeccionesNombreNota = from a in listaAlumnos
                             select new { NombreCompleto = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota };
foreach (var n in proyeccionesNombreNota) WriteLine($"{n.NombreCompleto}: {n.Nota}");

// Proyección: crear objeto con información resumida del alumno
// SQL: SELECT Id, CONCAT(Nombre, ' ', Apellidos) as DisplayName, LEFT(NombreCurso, 3) as CursoCorto FROM Alumnos
WriteLine("\n*** Proyección: información resumida ***");
var infoResumida = from a in listaAlumnos
                   select new 
                   { 
                       Id = a.Id, 
                       DisplayName = $"{a.Nombre} {a.Apellidos}", 
                       CursoCorto = a.NombreCurso.Length >= 3 ? a.NombreCurso.Substring(0, 3) : a.NombreCurso 
                   };
foreach (var i in infoResumida) WriteLine($"ID: {i.Id}, Nombre: {i.DisplayName}, Curso: {i.CursoCorto}");

// Proyección: calcular si el alumno aprueba o suspende
// SQL: SELECT Nombre, Nota, CASE WHEN Nota >= 5 THEN 'Aprobado' ELSE 'Suspendido' END as Estado FROM Alumnos
WriteLine("\n*** Proyección: estado académico ***");
var estadoAcademico = from a in listaAlumnos
                      select new 
                      { 
                          Nombre = a.Nombre, 
                          Nota = a.Nota, 
                          Estado = a.Nota >= 5 ? "Aprobado" : "Suspendido" 
                      };
foreach (var e in estadoAcademico) WriteLine($"{e.Nombre}: Nota={e.Nota}, Estado={e.Estado}");

// Proyección múltiple: filtrar Y proyectar en un solo paso
// SQL: SELECT CONCAT(Nombre, ' ', Apellidos) as Nombre, Nota FROM Alumnos WHERE Nota >= 9
WriteLine("\n*** Filtrar y proyectar en un solo paso ***");
var filtroYProyeccion = from a in listaAlumnos
                        where a.Nota >= 9
                        select new { Nombre = $"{a.Nombre} {a.Apellidos}", Nota = a.Nota };
foreach (var p in filtroYProyeccion) WriteLine($"{p.Nombre}: {p.Nota}");

// Proyección con cálculo: nota sobre 10 convertida a porcentaje
// SQL: SELECT Nombre, (Nota * 10) as Porcentaje FROM Alumnos
WriteLine("\n*** Proyección con cálculo: nota en porcentaje ***");
var notaPorcentaje = from a in listaAlumnos
                     select new { Nombre = a.Nombre, Porcentaje = a.Nota * 10 };
foreach (var n in notaPorcentaje) WriteLine($"{n.Nombre}: {n.Porcentaje}%");

// Proyección con múltiples propiedades calculadas
// SQL: SELECT Nombre, Nota, Nota * 10 as Sobre100, CASE WHEN Nota >= 5 THEN 1 ELSE 0 END as Aprobado FROM Alumnos
WriteLine("\n*** Proyección con múltiples cálculos ***");
var proyeccionesCalculadas = from a in listaAlumnos
                            select new 
                            { 
                                Nombre = a.Nombre,
                                Nota = a.Nota,
                                Sobre100 = a.Nota * 10,
                                Aprobado = a.Nota >= 5 ? "Sí" : "No"
                            };
foreach (var p in proyeccionesCalculadas) WriteLine($"{p.Nombre}: Nota={p.Nota}, Sobre100={p.Sobre100}, Aprobado={p.Aprobado}");

// Proyección en grupo: obtener estudiantes destacados por curso
// SQL: SELECT NombreCurso, MAX(Nota) as MejorNota FROM Alumnos GROUP BY NombreCurso
WriteLine("\n*** Proyección en grupo: mejor nota por curso ***");
var mejorPorCursoProyeccion = from a in listaAlumnos
                              group a by a.NombreCurso into grupo
                              select new 
                              { 
                                  Curso = grupo.Key, 
                                  MejorNota = grupo.Max(a => a.Nota),
                                  MejorAlumno = grupo.MaxBy(a => a.Nota)?.Nombre
                              };
foreach (var m in mejorPorCursoProyeccion) WriteLine($"{m.Curso}: Mejor={m.MejorAlumno} ({m.MejorNota})");

// ============================================================
// EXPLICACIÓN: QUERY SYNTAX VS METHOD SYNTAX
// ============================================================

/*
LINQ QUERY SYNTAX (Declarativa - Similar a SQL):
  - Se escribe con palabras clave: from, where, select, orderby, group, join
  - Más legible para quienes conocen SQL
  - Se traduce a Method Syntax internamente

LINQ METHOD SYNTAX ( Imperativa - Con lambdas):
  - Se escribe con métodos de extensión: .Where(), .Select(), .OrderBy()
  - Más flexible para consultas complejas
  - Más utilizada en código moderno

EQUIVALENCIAS:
  Query Syntax          →  Method Syntax
  ---------------------------------------------------
  from x in lista       →  lista
  where condición       →  .Where(x => condición)
  select x             →  .Select(x => x)
  orderby x            →  .OrderBy(x => x)
  orderby x descending →  .OrderByDescending(x => x)
  group x by clave     →  .GroupBy(x => clave)
  join y in lista2     →  .Join(lista2, ...)
    on x.id equals y.id
  
AMBAS SINTAXIS SE PUEDEN COMBINAR:
  var resultado = (from a in lista where a.Nota > 5 select a).Average();
*/

WriteLine("\n=== FIN ===");
