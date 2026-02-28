
---

# Relación de Ejercicios: UD 7 - Consultas Declarativas y Persistencia en Memoria

- [Relación de Ejercicios: UD 7 - Consultas Declarativas y Persistencia en Memoria](#relación-de-ejercicios-ud-7---consultas-declarativas-y-persistencia-en-memoria)
  - [Ejercicio 1: Gestión de Alumnado (Consultas Básicas y Agregados)](#ejercicio-1-gestión-de-alumnado-consultas-básicas-y-agregados)
  - [Ejercicio 2: Catálogo de Biblioteca (Transformación y Proyección)](#ejercicio-2-catálogo-de-biblioteca-transformación-y-proyección)
  - [Ejercicio 3: Análisis de Ventas (Agregación Avanzada y Acumuladores)](#ejercicio-3-análisis-de-ventas-agregación-avanzada-y-acumuladores)
  - [Ejercicio 4: Gestión de Empleados (Filtrado Jerárquico)](#ejercicio-4-gestión-de-empleados-filtrado-jerárquico)
  - [Ejercicio 5: Sistema de Gestión de Vehículos (Arquitectura Completa)](#ejercicio-5-sistema-de-gestión-de-vehículos-arquitectura-completa)
- [Ejercicio 6: Análisis Inteligente de Flota de Vehículos (LINQ)](#ejercicio-6-análisis-inteligente-de-flota-de-vehículos-linq)
    - [El Modelo de Datos](#el-modelo-de-datos)
    - [Datos de Prueba](#datos-de-prueba)
    - [Retos de Consulta (QUÉ y no CÓMO)](#retos-de-consulta-qué-y-no-cómo)
      - [1. Filtrado de Eficiencia y Desgaste](#1-filtrado-de-eficiencia-y-desgaste)
      - [2. Transformación de Información (Proyección)](#2-transformación-de-información-proyección)
      - [3. Estadísticas y Agregación](#3-estadísticas-y-agregación)
      - [4. Agrupación e Informes Complejos](#4-agrupación-e-informes-complejos)
      - [5. Ordenación Multicriterio](#5-ordenación-multicriterio)
      - [6. Análisis de Frecuencia](#6-análisis-de-frecuencia)
- [Ejercicio 7: Music Stream Analyzer (LINQ \& Proyecciones)](#ejercicio-7-music-stream-analyzer-linq--proyecciones)
    - [El Modelo de Datos](#el-modelo-de-datos-1)
    - [Datos de Prueba](#datos-de-prueba-1)
    - [Retos de Consulta (Paradigma Declarativo)](#retos-de-consulta-paradigma-declarativo)
      - [1. Filtrado y Preferencias](#1-filtrado-y-preferencias)
      - [2. Proyecciones y Formateo de Tiempo](#2-proyecciones-y-formateo-de-tiempo)
      - [3. Estadísticas de Reproducción](#3-estadísticas-de-reproducción)
      - [4. Agrupación e Informes Jerárquicos](#4-agrupación-e-informes-jerárquicos)
      - [5. Operaciones de Conjuntos y Ordenación](#5-operaciones-de-conjuntos-y-ordenación)
    - [Requisitos Técnicos](#requisitos-técnicos)
- [Ejercicio 8: Social Media Analytics Dashboard (LINQ \& Métricas)](#ejercicio-8-social-media-analytics-dashboard-linq--métricas)
    - [El Modelo de Datos](#el-modelo-de-datos-2)
    - [Datos de Prueba](#datos-de-prueba-2)
    - [Retos de Consulta (Análisis de Datos con LINQ)](#retos-de-consulta-análisis-de-datos-con-linq)
      - [1. Filtrado de Rendimiento y Viralidad](#1-filtrado-de-rendimiento-y-viralidad)
      - [2. Cálculo de Métricas (Engagement)](#2-cálculo-de-métricas-engagement)
      - [3. Agrupaciones e Informes de Canal](#3-agrupaciones-e-informes-de-canal)
      - [4. Transformaciones y Proyecciones Avanzadas](#4-transformaciones-y-proyecciones-avanzadas)
      - [5. Búsqueda y Ordenación Multicriterio](#5-búsqueda-y-ordenación-multicriterio)
    - [Requisitos Técnicos](#requisitos-técnicos-1)


## Ejercicio 1: Gestión de Alumnado (Consultas Básicas y Agregados)

Partiendo de una colección de alumnos con: `Nombre` (String), `Nota` (Double, redondeado a dos decimales) y `Curso` (String).

### Datos de Prueba

```csharp
using System.Linq;
using static System.Console;

var alumnos = new List<Alumno>
{
    new("Juan", 7.5, "DAM"),
    new("Pedro", 8.5, "DAM"),
    new("Ana", 9.5, "DAW"),
    new("María", 8.5, "DAM"),
    new("José", 9.5, "DAW"),
    new("Alicia", 7.5, "DAW"),
    new("Alberto", 6.5, "DAM"),
    new("Amanda", 9.0, "DAW"),
    new("Carlos", 5.5, "DAM"),
    new("Carmen", 8.0, "DAW")
};

public record Alumno(string Nombre, double Nota, string Curso);
```

### Preguntas a Resolver

Utiliza **LINQ (Method Syntax)** para obtener:

1. Listado de todos los alumnos de "DAW".
2. Alumnos con nota superior o igual a 8.5.
3. Nota media de los alumnos de "DAW".
4. Alumnos cuyo nombre empieza por 'A'.
5. Agrupación de alumnos por Curso (Grupo).
6. Alumno/s con la nota máxima (sin usar variables intermedias).
7. Listado ordenado por nota de manera descendente.
8. Paginación: Obtener los alumnos de la segunda página (tamaño de página 2).

## Ejercicio 2: Catálogo de Biblioteca (Transformación y Proyección)

Dispones de una lista de objetos `Libro` con `Titulo`, `Autor`, `ISBN` y `AñoPublicacion`.

### Datos de Prueba

```csharp
using System.Linq;
using static System.Console;

var libros = new List<Libro>
{
    new("El Quijote", "Miguel de Cervantes", "978-84-376-0494-0", 1605),
    new("1984", "George Orwell", "978-84-9836-427-1", 1949),
    new("Cien Años de Soledad", "Gabriel García Márquez", "978-84-204-2068-5", 1967),
    new("La Odisea", "Homero", "978-84-9836-427-2", -800),
    new("Don Quijote", "Miguel de Cervantes", "978-84-376-0495-7", 1605),
    new("Fundación", "Isaac Asimov", "978-84-450-0780-5", 1951),
    new("Dune", "Frank Herbert", "978-84-450-0781-2", 1965),
    new("1984", "George Orwell", "978-84-9836-427-3", 1949),
    new("Brave New World", "Aldous Huxley", "978-84-450-0782-9", 1932),
    new("Fahrenheit 451", "Ray Bradbury", "978-84-450-0783-6", 1953)
};

public record Libro(string Titulo, string Autor, string ISBN, int AñoPublicacion);
```

### Preguntas a Resolver

1. Obtener un `HashSet<string>` con todos los nombres de autores únicos (sin repetir).
2. Crear un diccionario donde la clave sea el `ISBN` y el valor sea el objeto `Libro`.
3. **Proyección:** Obtener una lista de strings con el formato `"Titulo - Autor"`.
4. **Zip:** Dados dos listados (uno de Títulos y otro de ISBNs), generar la colección de objetos Libro uniendo ambas.
5. **Chunk:** Dividir la biblioteca en bloques de 5 libros para un proceso de inventario.

## Ejercicio 3: Análisis de Ventas (Agregación Avanzada y Acumuladores)

Tenemos una colección de `Venta` con `ProductoId`, `Cantidad`, `PrecioUnitario` y `Categoria`.

### Datos de Prueba

```csharp
using System.Linq;
using static System.Console;

var ventas = new List<Venta>
{
    new(1, 10, 15.50, "Electrónica"),
    new(2, 5, 120.00, "Electrónica"),
    new(3, 20, 2.50, "Alimentación"),
    new(4, 3, 89.99, "Ropa"),
    new(5, 50, 1.20, "Alimentación"),
    new(6, 2, 250.00, "Electrónica"),
    new(7, 15, 5.00, "Hogar"),
    new(8, 8, 45.00, "Ropa"),
    new(9, 30, 0.80, "Alimentación"),
    new(10, 1, 500.00, "Electrónica"),
    new(11, 6, 35.00, "Hogar"),
    new(12, 12, 8.50, "Alimentación")
};

public record Venta(int ProductoId, int Cantidad, double PrecioUnitario, string Categoria);
```

### Preguntas a Resolver

1. Calcular el total de ingresos (Suma de cantidad * precio).
2. Obtener el producto más caro vendido utilizando el método `MaxBy`.
3. **Aggregate:** Utilizar el acumulador para calcular el total de ventas aplicando un descuento del 10% solo si el total supera los 100€.
4. Contar cuántas ventas hay por cada `Categoria` (devolver un diccionario).
5. Comprobar si todas las ventas superan el precio mínimo de 1€.

## Ejercicio 4: Gestión de Empleados (Filtrado Jerárquico)

Dada una estructura donde cada `Departamento` tiene una `Lista<Empleado>`.

### Datos de Prueba

```csharp
using System.Linq;
using static System.Console;

var departamentos = new List<Departamento>
{
    new("I+D", new List<Empleado>
    {
        new("12345678A", "Ana García", 2500, 7),
        new("23456789B", "Carlos López", 3200, 10),
        new("34567890C", "María Rodríguez", 2100, 3)
    }),
    new("Marketing", new List<Empleado>
    {
        new("45678901D", "Pedro Sánchez", 1800, 2),
        new("56789012E", "Laura Martínez", 1950, 4)
    }),
    new("I+D", new List<Empleado>  // Segundo departamento I+D
    {
        new("67890123F", "Juan Torres", 2800, 8),
        new("78901234G", "Elena Ruiz", 2300, 5)
    }),
    new("Ventas", new List<Empleado>
    {
        new("89012345H", "Miguel Fernández", 2200, 6),
        new("90123456I", "Sofia Gil", 1700, 1)
    }),
    new("Recursos Humanos", new List<Empleado>
    {
        new("01234567J", "David Moreno", 2400, 9)
    })
};

public record Empleado(string DNI, string Nombre, double Salario, int AñosAntigüedad);
public record Departamento(string Nombre, List<Empleado> Empleados);
```

### Preguntas a Resolver

1. **SelectMany:** Obtener una lista plana de todos los empleados de todos los departamentos.
2. Filtrar los empleados que ganan más de 2000€ y pertenecen a un departamento que contenga la palabra "I+D".
3. **Partition:** Dividir a los empleados en dos grupos: los que llevan más de 5 años en la empresa y los que no.
4. Obtener el salario medio por departamento.
5. Encontrar el primer empleado que coincida con un DNI específico utilizando `SingleOrDefault`.

## Ejercicio 5: Sistema de Gestión de Vehículos (Arquitectura Completa)

Este ejercicio integra **Repositorio, Servicio, Validación y Caché**.

### Modelo de Datos

```csharp
public abstract record Vehiculo(string Matricula, string Marca, string Modelo, int AñoMatriculacion);
public record Coche(string Matricula, string Marca, string Modelo, int AñoMatriculacion, int NumPuertas) : Vehiculo(Matricula, Marca, Modelo, AñoMatriculacion);
public record Moto(string Matricula, string Marca, string Modelo, int AñoMatriculacion, int Cilindrada) : Vehiculo(Matricula, Marca, Modelo, AñoMatriculacion);
public record Camion(string Matricula, string Marca, string Modelo, int AñoMatriculacion, double PesoMaximo) : Vehiculo(Matricula, Marca, Modelo, AñoMatriculacion);
```

### Datos de Prueba

```csharp
var vehiculos = new List<Vehiculo>
{
    new Coche("1234ABC", "Toyota", "Corolla", 2019, 5),
    new Coche("5678DEF", "Ford", "Focus", 2018, 5),
    new Moto("9012GHI", "Honda", "CBR", 2020, 600),
    new Camion("3456JKL", "Mercedes", "Actros", 2016, 20000),
    new Coche("7890MNO", "BMW", "Serie 3", 2021, 4),
    new Moto("1112PQR", "Yamaha", "MT-07", 2022, 700),
    new Camion("2223STU", "Volvo", "FH", 2017, 25000),
    new Coche("3334VWX", "Audi", "A4", 2020, 4),
    new Moto("4445YZA", "Kawasaki", "Ninja", 2019, 400),
    new Camion("5556BCD", "MAN", "TGX", 2018, 18000)
};
```

### Preguntas a Resolver (LINQ)

1. Número de vehículos agrupados por tipo (Coche, Moto, Camion).
2. Marca que más veces aparece en todo el sistema.
3. Promedio de `PesoMaximo` de los camiones matriculados después de 2015.

### Requerimientos de Arquitectura

1. **Repositorio:** Implementa un `IVehiculoRepository` que use un `Dictionary<string, Vehiculo>` internamente.
2. **Caché:** Crea una clase `VehiculoCache` que implemente una estrategia **LRU (Least Recently Used)** limitada a los últimos 5 vehículos consultados.
3. **Servicio:** Crea un `VehiculoService` que:
   * Al buscar un vehículo, primero mire en la caché. Si no está, lo busque en el repositorio y lo guarde en la caché.
   * Valide que la matrícula cumpla el formato `NNNNLLL` y el año esté entre 2000 y 2025.
   * Lance excepciones personalizadas (`VehiculoNotFoundException`, `InvalidMatriculaException`).



---

# Ejercicio 6: Análisis Inteligente de Flota de Vehículos (LINQ)

En este ejercicio trabajaremos con una flota de vehículos para una empresa de logística. El objetivo es sustituir los clásicos bucles `foreach` por consultas declarativas utilizando **LINQ**.

### El Modelo de Datos

Define el siguiente `record` en C#:

```csharp
public record Vehiculo(
    string Marca, 
    string Modelo, 
    int AnioFabricacion, 
    string Color, 
    double Consumo, // Litros cada 100 km
    int Kilometraje
);

```

### Datos de Prueba

```csharp
var flota = new List<Vehiculo>
{
    new("Toyota", "Corolla", 2019, "Blanco", 6.5, 85000),
    new("Ford", "Fiesta", 2020, "Azul", 5.8, 40000),
    new("Honda", "Civic", 2017, "Negro", 7.0, 120000),
    new("BMW", "3 Series", 2020, "Blanco", 6.5, 100000),
    new("Toyota", "Camry", 2021, "Rojo", 6.2, 25000),
    new("Ford", "Mustang", 2018, "Amarillo", 8.5, 95000),
    new("Honda", "Accord", 2019, "Negro", 6.8, 75000),
    new("BMW", "X5", 2022, "Gris", 7.5, 15000),
    new("Toyota", "RAV4", 2020, "Blanco", 6.0, 55000),
    new("Mercedes", "C-Class", 2021, "Negro", 6.5, 80000),
    new("Audi", "A4", 2018, "Plata", 6.2, 110000),
    new("Honda", "HR-V", 2021, "Rojo", 5.9, 30000)
};
```

---

### Retos de Consulta (QUÉ y no CÓMO)

Resuelve las siguientes solicitudes utilizando únicamente **Sintaxis de Métodos (Extension Methods)** de LINQ:

#### 1. Filtrado de Eficiencia y Desgaste

* **Bajo Consumo:** Encuentra los vehículos que consumen menos de 6 litros/100km.
* **Alta Rotación:** Filtra los vehículos con más de 100,000 km.
* **Combinado:** Obtén vehículos blancos fabricados después de 2018 ordenados por año.
* **Búsqueda Específica:** Encuentra el primer vehículo que sea "Toyota Celica" (si existe).

#### 2. Transformación de Información (Proyección)

* **Marcas Únicas:** Obtén un listado de todas las marcas sin repetir.
* **Filtro de Texto:** Listado de marcas únicas que tengan más de 5 caracteres.
* **Formateo de Etiquetas:** Crea una lista de strings con el formato: `"Marca Modelo - Año"`.
* **Informe Maestro:** Convierte toda la flota en un único `string` separado por comas con el formato: `"Marca Modelo (Año) - Consumo L/100km"`.

#### 3. Estadísticas y Agregación

* **Rendimiento:** Calcula el promedio de consumo de toda la flota.
* **Líderes de Marca:** Calcula la media de consumo específicamente de los vehículos "Toyota".
* **Kilometraje Total:** Suma todos los kilómetros recorridos por la flota.
* **Extremos:** Encuentra el vehículo con el kilometraje máximo y el vehículo con el mejor rendimiento (menor consumo).
* **Validaciones:** Comprueba si **todos** los vehículos consumen menos de 8 litros y si **al menos uno** es rojo con menos de 50,000 km.

#### 4. Agrupación e Informes Complejos

* **Distribución por Color:** Agrupa los vehículos por color.
* **Conteo por Marca:** Muestra cuántos vehículos hay de cada marca.
* **Tendencia Temporal:** Agrupa por año de fabricación y muestra cuántos hay de cada uno, ordenados por cantidad de vehículos.
* **Diccionario de Modelos:** Crea un `Dictionary<string, List<string>>` donde la clave sea la marca y el valor sea la lista de modelos de esa marca.

#### 5. Ordenación Multicriterio

* **Prioridad:** Ordena los vehículos por consumo de menor a mayor. En caso de empate en consumo, ordénalos por kilometraje de forma descendente.
* **Cronología:** Obtén todos los años de fabricación presentes en la flota de manera ascendente y sin duplicados.

#### 6. Análisis de Frecuencia

* **Moda de Color:** Encuentra cuál es el color que más se repite en la flota y cuántos vehículos lo tienen.
* **Stock:** Encuentra la marca que tiene mayor presencia en la lista.

---



Para completar la serie de ejercicios, este nuevo enunciado se centra en la **Gestión de una Biblioteca Musical**. Es ideal para practicar **LINQ** con diferentes tipos de datos (tiempos, strings, números) y transformaciones complejas.

---

# Ejercicio 7: Music Stream Analyzer (LINQ & Proyecciones)

Eres el desarrollador principal de una nueva plataforma de streaming y necesitas procesar los metadatos de las canciones para generar informes de consumo.

### El Modelo de Datos

Define el siguiente `record` en **C# 14**:

```csharp
public record Cancion(
    string Titulo, 
    string Autor, 
    int DuracionSegundos, // Duración en segundos
    string Genero,
    bool EsFavorita
);

```

### Datos de Prueba

```csharp
var biblioteca = new List<Cancion>
{
    new("Bohemian Rhapsody", "Queen", 355, "Rock", true),
    new("Stairway to Heaven", "Led Zeppelin", 482, "Rock", true),
    new("Hotel California", "Eagles", 391, "Rock", false),
    new("Sweet Child O' Mine", "Guns N' Roses", 356, "Rock", true),
    new("Take Five", "Dave Brubeck", 324, "Jazz", false),
    new("So What", "Miles Davis", 562, "Jazz", true),
    new("All Blues", "Miles Davis", 693, "Jazz", false),
    new("Billie Jean", "Michael Jackson", 294, "Pop", true),
    new("Thriller", "Michael Jackson", 358, "Pop", false),
    new("Shape of You", "Ed Sheeran", 234, "Pop", true),
    new("Master of Puppets", "Metallica", 466, "Metal", true),
    new("Enter Sandman", "Metallica", 306, "Metal", false),
    new("Nothing Else Matters", "Metallica", 388, "Metal", true),
    new("Comfortably Numb", "Pink Floyd", 382, "Rock", false),
    new("Imagine", "John Lennon", 187, "Pop", true),
    new("Giant Steps", "Milestones", 292, "Jazz", false)
};
```

---

### Retos de Consulta (Paradigma Declarativo)

#### 1. Filtrado y Preferencias

* **Favoritas:** Obtén todas las canciones marcadas como favoritas.
* **Long Play (LP):** Filtra las canciones que duren más de 5 minutos (300 segundos).
* **Búsqueda por Género:** Encuentra todas las canciones de "Jazz" que no sean favoritas.
* **Coincidencia Parcial:** Busca canciones cuyo título contenga la palabra "Love" o "Night".

#### 2. Proyecciones y Formateo de Tiempo

* **Conversión de Duración:** Crea una lista de strings con el formato: `"Titulo - MM:SS"`. (Ejemplo: *"Bohemian Rhapsody - 05:55"*).
* **Ficha de Artista:** Obtén un listado de todos los autores únicos en mayúsculas.
* **Análisis por Género:** Genera una lista de objetos anónimos `new { Genero, Cantidad }` que muestre cuántas pistas hay de cada estilo.

#### 3. Estadísticas de Reproducción

* **Tiempo Total:** Calcula cuántas horas, minutos y segundos dura la lista de reproducción completa (usa `TimeSpan`).
* **Promedio por Autor:** Calcula la duración media de las canciones de un autor específico.
* **Extremos:** Encuentra la canción más corta del género "Rock".
* **Existencia:** Comprueba si hay alguna canción de "Heavy Metal" que dure menos de 2 minutos.

#### 4. Agrupación e Informes Jerárquicos

* **Discografía:** Agrupa las canciones por `Autor`. La salida debe ser un diccionario donde la clave sea el autor y el valor sea la suma total de segundos de todas sus canciones.
* **Mix por Género:** Agrupa por `Genero` y obtén solo los títulos de las canciones favoritas de cada uno.
* **Top 3:** Obtén las 3 canciones más largas de la biblioteca.

#### 5. Operaciones de Conjuntos y Ordenación

* **Ranking:** Ordena la biblioteca por `Genero` (ascendente) y, dentro de cada género, por `DuracionSegundos` (descendente).
* **Paginación de Biblioteca:** Salta las primeras 5 canciones y toma las 5 siguientes (Simulación de página 2).
* **Playlist Aleatoria:** Investiga cómo usar `OrderBy` con un `Guid.NewGuid()` o `Random` para desordenar la lista.

---

### Requisitos Técnicos

* Implementa la solución usando **Top-Level Statements**.
* Utiliza **C# 14** (Collection expressions para los datos de prueba).
* **Regla de Oro:** Prohibido el uso de `for`, `while` o `foreach` para las consultas; todo debe resolverse con **LINQ**.


Para completar la serie, este ejercicio se enfoca en el **Análisis de Métricas de Redes Sociales**. Es un escenario ideal para practicar **proyecciones complejas**, cálculos de **ratios** (como el *engagement*) y agrupaciones por categorías de contenido.

---

# Ejercicio 8: Social Media Analytics Dashboard (LINQ & Métricas)

Trabajarás con los datos de una agencia de marketing que necesita analizar el rendimiento de los "Posts" de sus creadores de contenido.

### El Modelo de Datos

Define el siguiente `record` en **C# 14**:

```csharp
public record Post(
    string Id,
    string Autor,
    string Contenido,
    int Visualizaciones,
    int Likes,
    int Compartidos,
    DateTime FechaPublicacion,
    string Categoria // "Video", "Imagen", "Texto"
);

```

### Datos de Prueba

```csharp
var fechaActual = new DateTime(2024, 1, 15);

var posts = new List<Post>
{
    new("P1", "AnaCreator", "Video de viaje a París", 15000, 800, 150, fechaActual.AddDays(-2), "Video"),
    new("P2", "AnaCreator", "Foto de comida saludable", 8000, 400, 50, fechaActual.AddDays(-5), "Imagen"),
    new("P3", "TechBlog", "Review del nuevo móvil", 25000, 1200, 300, fechaActual.AddDays(-1), "Video"),
    new("P4", "TechBlog", "5 consejos de programación", 12000, 600, 100, fechaActual.AddDays(-3), "Texto"),
    new("P5", "ViajesMax", "Mi experiencia en Tokio", 30000, 1500, 400, fechaActual.AddDays(-7), "Video"),
    new("P6", "ViajesMax", "Fotos de atardecer", 5000, 250, 30, fechaActual.AddDays(-10), "Imagen"),
    new("P7", "AnaCreator", "Tutorial de maquillaje", 10000, 700, 80, fechaActual.AddDays(-4), "Video"),
    new("P8", "TechBlog", "Unboxing tecnología", 18000, 900, 200, fechaActual.AddDays(-6), "Video"),
    new("P9", "FitnessPro", "Rutina de ejercicios", 22000, 1100, 250, fechaActual.AddDays(-2), "Video"),
    new("P10", "FitnessPro", "Tips de nutrición", 8000, 350, 45, fechaActual.AddDays(-8), "Texto"),
    new("P11", "ViajesMax", "Best beaches 2024", 15000, 800, 120, fechaActual.AddDays(-12), "Imagen"),
    new("P12", "TechBlog", "IA y el futuro", 20000, 950, 180, fechaActual.AddDays(-9), "Texto")
};
```

---

### Retos de Consulta (Análisis de Datos con LINQ)

#### 1. Filtrado de Rendimiento y Viralidad

* **Contenido Viral:** Encuentra los posts que tengan más de 10,000 visualizaciones.
* **Alta Interacción:** Filtra los posts donde el número de `Likes` sea superior al 5% de las `Visualizaciones`.
* **Recientes:** Obtén los posts publicados en los últimos 7 días.
* **Específico:** Busca el post más compartido de la categoría "Video".

#### 2. Cálculo de Métricas (Engagement)

* **Ratio de Engagement:** Crea una lista de objetos anónimos `new { Id, Autor, Ratio }` donde el Ratio sea `(Likes + Compartidos) / Visualizaciones`.
* **Total Global:** Calcula la suma total de visualizaciones de toda la agencia.
* **Medias de Interacción:** Obtén la media de `Likes` para todos los posts de categoría "Imagen".

#### 3. Agrupaciones e Informes de Canal

* **Rendimiento por Categoría:** Agrupa los posts por `Categoria` y muestra el total de visualizaciones acumuladas en cada una.
* **Actividad por Autor:** Muestra cuántos posts ha subido cada autor, ordenados de mayor a menor actividad.
* **Top Creators:** Obtén los nombres de los 3 autores con más `Likes` totales en sus publicaciones.

#### 4. Transformaciones y Proyecciones Avanzadas

* **Resumen de Texto:** Para cada post, genera una cadena con el formato: `"[CATEGORIA] Autor: Contenido (Recortado a 20 caracteres)..."`.
* **Análisis Temporal:** Agrupa los posts por el **Mes** de publicación y calcula la media de visualizaciones por mes.
* **Flattening:** Si tuvieras una lista de `Autores` y cada uno tuviera una `List<Post>`, usa `SelectMany` para obtener todos los posts con más de 500 likes.

#### 5. Búsqueda y Ordenación Multicriterio

* **Ranking de Calidad:** Ordena los posts primero por `Likes` (descendente) y luego por `FechaPublicacion` (más reciente primero).
* **Peores Registros:** Encuentra los 5 posts con menos visualizaciones que no sean de la categoría "Texto".
* **Distinct:** Obtén una lista única de todas las categorías que han superado las 1,000 interacciones totales.

---

### Requisitos Técnicos

* Usa **Top-Level Statements** y **C# 14**.
* Implementa las consultas usando **Method Syntax** (extension methods).
* **Desafío Extra:** Crea una pequeña **Caché LRU** de capacidad 3 para almacenar los resultados de los "Top 3 Posts del día" para evitar recalcular la consulta LINQ constantemente.

---
