
### Test: Persistencia de Objetos, Colecciones y LINQ

- [Test: Persistencia de Objetos, Colecciones y LINQ](#test-persistencia-de-objetos-colecciones-y-linq)
  - [Bloque 1: Evolución del Paradigma de Persistencia](#bloque-1-evolución-del-paradigma-de-persistencia)
  - [Bloque 2: El Desajuste de Impedancia](#bloque-2-el-desajuste-de-impedancia)
  - [Bloque 3: Colecciones como Bases de Datos en Memoria](#bloque-3-colecciones-como-bases-de-datos-en-memoria)
  - [Bloque 4: Programación Declarativa vs. Imperativa](#bloque-4-programación-declarativa-vs-imperativa)
  - [Bloque 5: Estructuras de Almacenamiento en C#](#bloque-5-estructuras-de-almacenamiento-en-c)
  - [Bloque 6: LINQ (Language Integrated Query)](#bloque-6-linq-language-integrated-query)
  - [Bloque 7: Sintaxis y Operaciones de LINQ](#bloque-7-sintaxis-y-operaciones-de-linq)
  - [Bloque 8: Patrón Repository y CRUD](#bloque-8-patrón-repository-y-crud)
  - [Bloque 9: Sistemas de Caché](#bloque-9-sistemas-de-caché)


#### Bloque 1: Evolución del Paradigma de Persistencia
1. **¿Cuál era el objetivo principal de las Bases de Datos Orientadas a Objetos (BDOO) puras?**
   a) Sustituir el código de programación por consultas SQL.
   b) Almacenar objetos directamente en el disco tal como existen en la memoria RAM.
   c) Forzar el uso de esquemas rígidos en aplicaciones web.
   d) Eliminar la necesidad de usar memoria RAM en el servidor.

2. **¿Qué tipo de base de datos NoSQL utiliza estructuras como MongoDB o RavenDB?**
   a) Clave-Valor.
   b) Orientadas a Grafos.
   c) Documentales.
   d) Columnares.

3. **¿Qué significa el acrónimo ORM?**
   a) Object-Relational Mapping.
   b) Optimized Relational Management.
   c) Object-Resource Model.
   d) Operational Relational Mapper.

4. **¿Cuál es una ventaja principal del uso de un ORM como Entity Framework Core?**
   a) Elimina por completo la necesidad de conocer el lenguaje C#.
   b) Garantiza que las consultas sean siempre más rápidas que el SQL manual.
   c) Ofrece seguridad de tipos (Type-safety) detectada en la compilación.
   d) Permite que la base de datos funcione sin almacenamiento físico.

5. **¿En qué consiste el principio de "Persistencia Políglota"?**
   a) Usar un solo lenguaje de programación para todas las bases de datos.
   b) Utilizar diferentes tecnologías de almacenamiento según el caso de uso específico.
   c) Traducir automáticamente consultas SQL a varios idiomas.
   d) Almacenar los mismos datos en cinco bases de datos diferentes simultáneamente.

#### Bloque 2: El Desajuste de Impedancia
6. **¿Qué es el "Desajuste de Impedancia" (Impedance Mismatch)?**
   a) Un error eléctrico en los servidores que alojan bases de datos.
   b) El conflicto entre el modelo de objetos (POO) y el modelo relacional (SQL).
   c) La diferencia de velocidad entre un procesador i7 y uno i9.
   d) La incompatibilidad entre diferentes versiones de Windows.

7. **En el contexto del desajuste de impedancia, ¿cómo se manifiesta el problema de la "Herencia"?**
   a) Las tablas SQL no soportan naturalmente jerarquías de clases.
   b) Los objetos no pueden heredar propiedades de sus padres en memoria RAM.
   c) Los hijos no pueden acceder a las claves primarias de los padres.
   d) Las bases de datos relacionales obligan a que todos los objetos sean iguales.

8. **¿Cómo define la identidad el mundo relacional (SQL)?**
   a) Mediante la dirección de memoria física.
   b) A través de referencias bidireccionales.
   c) Mediante el uso de claves primarias (Primary Keys).
   d) Utilizando polimorfismo dinámico.

9. **¿Qué solución utiliza habitualmente un ORM para resolver el problema de la navegación por grafos?**
   a) Forzar al programador a usar punteros manuales.
   b) Carga diferida (Lazy Loading) o carga ansiosa (Eager Loading).
   c) Convertir todos los objetos en tablas temporales de texto.
   d) Eliminar las relaciones entre objetos.

10. **En el desajuste de impedancia, ¿qué representa el problema de la "Granularidad"?**
    a) La diferencia entre tipos complejos anidados en POO frente a columnas atómicas en SQL.
    b) El tamaño en bytes de cada registro en el disco duro.
    c) La cantidad de objetos que se pueden crear por segundo.
    d) El número de filas que puede tener una tabla.

#### Bloque 3: Colecciones como Bases de Datos en Memoria
11. **En la analogía entre colecciones y SQL, ¿qué concepto de C# equivale a una "Fila" de una tabla?**
    a) Una propiedad de una clase.
    b) Un objeto individual.
    c) Una interfaz.
    d) Un método estático.

12. **¿Qué operación de colecciones en C# equivale a un "DELETE" en SQL?**
    a) .Add()
    b) .Where()
    c) .Remove()
    d) .Clear()

13. **¿Cuál es una ventaja crítica de usar colecciones en memoria frente a una base de datos física?**
    a) Los datos sobreviven a un reinicio del sistema.
    b) No hay límite de capacidad de almacenamiento.
    c) La velocidad de acceso es en nanosegundos (extrema).
    d) Los datos se comparten automáticamente entre diferentes aplicaciones.

14. **¿Cuál es la principal limitación de las colecciones en memoria?**
    a) Son efímeras y los datos se pierden al cerrar la aplicación.
    b) No permiten el uso de tipos genéricos.
    c) Son más lentas que el acceso a disco.
    d) No pueden ser iteradas con bucles.

15. **¿Qué estructura de C# se comporta como una tabla con una restricción de unicidad (UNIQUE constraint)?**
    a) List<T>
    b) HashSet<T>
    c) Queue<T>
    d) Array

#### Bloque 4: Programación Declarativa vs. Imperativa
16. **¿En qué se centra el paradigma imperativo?**
    a) En describir "QUÉ" resultado se desea obtener.
    b) En describir paso a paso "CÓMO" realizar una tarea.
    c) En delegar la lógica al sistema operativo.
    d) En eliminar el uso de variables.

17. **¿Cuál es una característica fundamental de la programación declarativa?**
    a) El uso intensivo de bucles `for` con índices manuales.
    b) Especificar el resultado deseado sin detallar el flujo de control.
    c) El control absoluto sobre cada estado intermedio de la memoria.
    d) La imposibilidad de usar funciones.

18. **¿Cuál es el lenguaje declarativo por excelencia en el manejo de datos?**
    a) C
    b) Assembly
    c) SQL
    d) Java

19. **¿Qué herramienta trae el paradigma declarativo de SQL a las colecciones de C#?**
    a) Los punteros.
    b) LINQ (Language Integrated Query).
    c) El recolector de basura (Garbage Collector).
    d) Los archivos .dll.

20. **¿Cuándo es más recomendable usar el paradigma imperativo según las fuentes?**
    a) En el 99% de las aplicaciones de negocio.
    b) Cuando se requiere optimización extrema y lógica con muchos estados intermedios.
    c) Para realizar consultas simples de filtrado.
    d) Cuando se busca que el código sea lo más legible posible para humanos.

#### Bloque 5: Estructuras de Almacenamiento en C#
21. **¿Cuál es la complejidad temporal promedio para buscar un elemento por índice en una `List<T>`?**
    a) O(1)
    b) O(n)
    c) O(log n)
    d) O(n²)

22. **¿En qué escenario NO se recomienda usar `List<T>`?**
    a) Cuando se necesita mantener el orden de inserción.
    b) Cuando los duplicados son válidos.
    c) Cuando se realizan búsquedas frecuentes por una clave identificadora.
    d) Cuando se necesita acceso por índice (lista).

23. **¿Cuál es la principal ventaja de un `Dictionary<K,V>`?**
    a) Mantiene siempre el orden de inserción de los elementos.
    b) Permite búsquedas instantáneas O(1) mediante una clave única.
    c) No consume casi memoria RAM.
    d) Permite tener claves duplicadas para el mismo valor.

24. **¿Qué sucede si intentas añadir un elemento duplicado a un `HashSet<T>`?**
    a) El programa lanza una excepción crítica.
    b) El conjunto ignora el nuevo elemento y mantiene la unicidad.
    c) Se crea una lista interna para almacenar ambos elementos.
    d) Se sobrescribe el elemento anterior automáticamente.

25. **¿Qué tipo de relación de datos se modela en C# mediante una lista de objetos dentro de otra clase (ej. Cliente con List<Pedido>)?**
    a) Relación 1:1.
    b) Relación 1:N (Uno a Muchos).
    c) Relación N:M mediante tabla intermedia.
    d) Relación de herencia pura.

#### Bloque 6: LINQ (Language Integrated Query)
26. **¿Sobre qué interfaces principales funciona LINQ?**
    a) ISerializable e ICloneable.
    b) IEnumerable<T> e IQueryable<T>.
    c) IDisposable e IComparable.
    d) IList e IDictionary.

27. **¿Qué proveedor de LINQ se utiliza para consultar colecciones en memoria como `List<T>`?**
    a) LINQ to SQL.
    b) LINQ to XML.
    c) LINQ to Objects.
    d) LINQ to Entities.

28. **¿Cuál es la diferencia clave entre `IEnumerable` e `IQueryable`?**
    a) `IEnumerable` es para bases de datos y `IQueryable` para memoria.
    b) `IQueryable` permite que el filtrado ocurra en el servidor de base de datos.
    c) `IEnumerable` no permite usar métodos de extensión.
    d) No existe ninguna diferencia, son alias del mismo tipo.

29. **¿Qué permiten hacer los "Métodos de Extensión" en C#?**
    a) Borrar métodos de clases selladas.
    b) "Agregar" métodos a tipos existentes sin modificar su código fuente original.
    c) Aumentar la velocidad del procesador mediante software.
    d) Cambiar la visibilidad de variables privadas a públicas.

30. **¿Para qué sirve la palabra clave `yield return` en C#?**
    a) Para detener la ejecución de la aplicación inmediatamente.
    b) Para convertir un método en un generador con ejecución diferida (Lazy Evaluation).
    c) Para retornar múltiples valores al mismo tiempo en una tupla fija.
    d) Para liberar la memoria RAM de forma manual.

#### Bloque 7: Sintaxis y Operaciones de LINQ
31. **¿Qué dos sintaxis ofrece LINQ para realizar consultas?**
    a) Sintaxis de Compilación y Sintaxis de Ejecución.
    b) Method Syntax (Sintaxis de Métodos) y Query Syntax (Sintaxis de Consulta).
    c) Sintaxis Imperativa y Sintaxis Binaria.
    d) Sintaxis de Atributos y Sintaxis de Interfaces.

32. **¿Cuál es una ventaja de la "Method Syntax" frente a la "Query Syntax"?**
    a) Es idéntica al lenguaje SQL.
    b) Soporta todos los operadores de LINQ (como Take o Skip).
    c) No requiere el uso de lambdas.
    d) Es más legible para personas que solo saben SQL.

33. **¿Qué operador de LINQ se utiliza para transformar o proyectar elementos a un nuevo tipo?**
    a) .Where()
    b) .Select()
    c) .GroupBy()
    d) .Any()

34. **¿Qué diferencia hay entre `First()` y `FirstOrDefault()`?**
    a) `First()` devuelve una lista, `FirstOrDefault()` un solo objeto.
    b) `First()` lanza una excepción si no hay resultados; `FirstOrDefault()` devuelve un valor por defecto (null).
    c) `FirstOrDefault()` es mucho más lento que `First()`.
    d) `First()` solo funciona con diccionarios.

35. **¿Qué método de LINQ utilizarías para verificar si AL MENOS UN elemento cumple una condición?**
    a) .All()
    b) .Contains()
    c) .Any()
    d) .Single()

36. **¿Cuál es la función del operador `.SelectMany()`?**
    a) Seleccionar muchos elementos de forma aleatoria.
    b) Proyectar cada elemento a una secuencia y luego aplanar los resultados en una sola secuencia.
    c) Realizar múltiples consultas en paralelo.
    d) Contar cuántos elementos hay en una subcolección.

37. **¿Qué operador garantiza que hay exactamente un elemento que cumple la condición y lanza excepción en caso contrario?**
    a) .First()
    b) .Single()
    c) .LastOrDefault()
    d) .Distinct()

38. **Para ordenar una lista por un criterio secundario (después de un `OrderBy`), ¿qué método se debe usar?**
    a) .OrderBy() de nuevo.
    b) .ThenBy()
    c) .SortNext()
    d) .AndBy()

39. **¿Qué hace el operador `.Aggregate()`?**
    a) Suma automáticamente todos los números de una lista.
    b) Permite definir una acumulación personalizada basada en una función.
    c) Agrupa los elementos por una clave común.
    d) Elimina los elementos duplicados de la secuencia.

40. **¿Cuál es la finalidad del método `.Take(n)`?**
    a) Saltar los primeros n elementos.
    b) Tomar exactamente los primeros n elementos de la secuencia.
    c) Dividir la colección en n lotes.
    d) Eliminar los últimos n elementos.

#### Bloque 8: Patrón Repository y CRUD
41. **¿Qué representan las siglas CRUD?**
    a) Create, Read, Update, Delete.
    b) Copy, Run, Undo, Disconnect.
    c) Class, Record, Union, Data.
    d) Create, Remove, Use, Define.

42. **¿Cuál es el objetivo principal del Patrón Repository (Repositorio)?**
    a) Aumentar la velocidad de la red.
    b) Abstraer el acceso a datos para que la lógica de negocio no sepa dónde se almacenan.
    c) Crear copias de seguridad automáticas en la nube.
    d) Obligar al uso de bases de datos relacionales únicamente.

43. **¿Por qué es importante sobrescribir `Equals()` y `GetHashCode()` al usar un `HashSet` con objetos de tipo `class`?**
    a) Para que los objetos ocupen menos espacio en memoria.
    b) Porque, por defecto, las clases se comparan por referencia y no por el valor de sus propiedades.
    c) Para que el compilador no dé errores de sintaxis.
    d) Para poder usar el bucle `foreach`.

44. **En el patrón repositorio, ¿qué ventaja ofrece el uso de interfaces como `ICrudRepository`?**
    a) Hace que el código sea imposible de testear.
    b) Permite intercambiar la implementación (de Lista a Diccionario o BD) sin tocar la lógica de negocio.
    c) Reduce el número de líneas de código a la mitad.
    d) Elimina la necesidad de manejar excepciones.

45. **¿Qué equivalente SQL tiene la operación "Update" de CRUD?**
    a) SELECT
    b) INSERT
    c) UPDATE
    d) DELETE

#### Bloque 9: Sistemas de Caché
46. **¿Qué es una caché en el desarrollo de software?**
    a) Una base de datos permanente de gran capacidad.
    b) Un almacenamiento temporal de acceso rápido para reducir latencias.
    c) Un virus que ralentiza el ordenador.
    d) Un tipo de memoria que solo existe en las tarjetas gráficas.

47. **¿Cuál es una desventaja notable de implementar una caché?**
    a) Aumenta demasiado el tráfico de red.
    b) Los datos pueden quedar obsoletos (stale data) respecto a la fuente original.
    c) Obliga a que la aplicación sea más lenta.
    d) Solo se puede usar con archivos de texto plano.

48. **¿En qué consiste la estrategia de desalojo FIFO (First In, First Out)?**
    a) El elemento usado más recientemente es el primero en salir.
    b) El primer elemento que entró en la caché es el primero en ser eliminado cuando esta se llena.
    c) Se eliminan elementos de forma aleatoria.
    d) No se elimina nada hasta que el ordenador se reinicia.

49. **¿Qué diferencia a la estrategia LRU (Least Recently Used) de la FIFO?**
    a) LRU es mucho más sencilla de implementar.
    b) En LRU, el acceso a un dato (lectura) afecta a su posición en la cola de desalojo.
    c) FIFO siempre es más eficiente que LRU en todos los casos.
    d) LRU no utiliza la memoria RAM.

50. **¿Cuál es el principal problema de tener una caché con capacidad ilimitada?**
    a) Que la búsqueda de datos se vuelve instantánea.
    b) Que la memoria RAM es finita y la aplicación podría colapsar (Out of Memory).
    c) Que los datos se vuelven más seguros.
    d) Que no se pueden guardar objetos complejos.

***
