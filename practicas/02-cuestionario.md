- [Investigación sobre Persistencia y Modelado](#investigación-sobre-persistencia-y-modelado)
- [Desarrollo y Estructuras de Datos en C#](#desarrollo-y-estructuras-de-datos-en-c)
- [Profundización en LINQ y Programación Declarativa](#profundización-en-linq-y-programación-declarativa)
- [Arquitectura y Gestión de Datos](#arquitectura-y-gestión-de-datos)


### Investigación sobre Persistencia y Modelado
1.  **Evolución y fracaso de las BDOO:** Investiga por qué, a pesar de ofrecer ventajas como la **navegación natural** y el soporte nativo para la herencia, las Bases de Datos Orientadas a Objetos puras no lograron desplazar al modelo relacional en el ámbito empresarial.
2.  **El Desajuste de Impedancia en la práctica:** Explica detalladamente cómo un ORM (como Entity Framework Core) resuelve el problema de la **identidad** mediante el uso de un *Identity Map* y cómo esto se diferencia de la identidad basada en claves primarias del mundo SQL.
3.  **Persistencia Políglota:** Analiza el principio de que "no existe una base de datos única para todo". Diseña un escenario para una aplicación moderna donde sea beneficioso usar simultáneamente una base de datos **documental** (NoSQL) y una **relacional** (SQL).
4.  **El problema de las consultas N+1:** Investiga en qué consiste este error común al usar ORMs y cómo el uso de estrategias de carga como **Eager Loading** frente a **Lazy Loading** puede mitigar o agravar este problema de rendimiento.

### Desarrollo y Estructuras de Datos en C#
5.  **Optimización de colecciones:** Compara el rendimiento de una `List<T>` frente a un `Dictionary<K,V>` al realizar búsquedas frecuentes por un identificador único. ¿Por qué se dice que el diccionario tiene una complejidad de **O(1)** en estas operaciones?.
6.  **Unicidad y comparación de objetos:** Desarrolla una explicación técnica sobre por qué es obligatorio sobrescribir los métodos **`Equals()` y `GetHashCode()`** cuando se desea utilizar una clase personalizada dentro de un `HashSet<T>` para garantizar que no existan duplicados por valor.
7.  **Relaciones N:M en memoria:** Basándote en el modelado de objetos, describe cómo implementarías una relación **Muchos a Muchos** entre "Estudiantes" y "Cursos" utilizando únicamente colecciones de C#, y compáralo con el uso de una tabla intermedia en SQL.

### Profundización en LINQ y Programación Declarativa
8.  **Ejecución Diferida (Lazy Evaluation):** Investiga el funcionamiento interno de la palabra clave **`yield return`**. ¿Cómo permite esta funcionalidad procesar secuencias de datos potencialmente infinitas sin agotar la memoria RAM?.
9.  **IEnumerable vs. IQueryable:** Explica la diferencia crítica entre estas dos interfaces en términos de dónde se ejecuta el filtrado de los datos (memoria local vs. servidor de base de datos) y en qué escenarios es un error grave convertir un `IQueryable` a `IEnumerable` prematuramente.
10. **Métodos de Extensión:** Crea un ejemplo teórico de un **método de extensión** personalizado para la interfaz `IEnumerable<T>` que no exista en la librería estándar de LINQ (por ejemplo, un método `Shuffled()` para desordenar una lista).
11. **Transformaciones complejas con SelectMany:** Describe un escenario real donde el operador `.Select()` sea insuficiente y sea necesario utilizar **`.SelectMany()`** para "aplanar" una jerarquía de objetos (por ejemplo, obtener todos los pedidos de una lista de clientes).

### Arquitectura y Gestión de Datos
12. **Patrón Repository y Testabilidad:** ¿Cómo facilita el uso del **Patrón Repository** la creación de pruebas unitarias (*unit testing*)? Investiga cómo podrías sustituir un repositorio real por uno "mock" o simulado para probar la lógica de negocio sin depender de una base de datos.
13. **Comparativa de estrategias de Caché:** Analiza las diferencias entre las estrategias de desalojo **FIFO y LRU**. ¿En qué tipo de aplicaciones sería más eficiente utilizar LRU (donde el acceso afecta al orden) en lugar de un simple FIFO?.
14. **Inmutabilidad y programación declarativa:** Investiga por qué el enfoque declarativo de LINQ ("el qué") suele generar código con **menos errores** y más fácil de mantener que el enfoque imperativo basado en bucles manuales ("el cómo").
15. **Limitaciones de la memoria RAM:** Si las colecciones en memoria ofrecen **velocidad extrema** (nanosegundos), investiga y debate cuáles son los riesgos críticos de seguridad y persistencia al utilizarlas como único sistema de almacenamiento en una aplicación de misión crítica.

***

