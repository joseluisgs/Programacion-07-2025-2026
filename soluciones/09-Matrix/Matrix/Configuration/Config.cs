namespace Matrix.Configuration;

/**
 * Clase de configuración para la simulación de The Matrix.
 * Valores por defecto que pueden ser modificados.
 */
public static class Config {
    // Valores por defecto (hardcoded) - se usan si no se pasan por parámetros
    public static int Dimension { get; set; } = 10;
    public static int TiempoSimulacionSegundos { get; set; } = 30;
    public static int AlmacenInitSize { get; set; } = 1000;
    public static int ProbabilidadMorirBase { get; set; } = 30;

    // Intervalos de tiempo en milisegundos
    public static int IntervaloProcesarGenericos { get; set; } = 1000;
    public static int IntervaloProcesarSmiths { get; set; } = 2000;
    public static int IntervaloProcesarNeo { get; set; } = 5000;
    public static int IntervaloAgregarNuevos { get; set; } = 10000;

    // Máximo de nuevos genéricos que pueden aparecer
    public static int MaxNuevosGenericos { get; set; } = 5;

    // Nombres disponibles para personajes genéricos
    public static string[] NombresGenericos { get; } = {
        "Cypher", "Tank", "Dozer", "Apoc", "Switch",
        "Mouse", "Morpheus", "Trinity", "Oracle", "Mifune"
    };

    // Ciudades donde pueden estar los personajes
    public static string[] Ciudades { get; } = {
        "Zion", "Nebuchadnezzar", "MegaCity", "Machine City"
    };
}