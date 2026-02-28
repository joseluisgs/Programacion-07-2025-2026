using System.Text;
using Matrix.Configuration;
using Matrix.Services;
using static System.Console;

OutputEncoding = Encoding.UTF8;

WriteLine();
WriteLine("================================================");
WriteLine("            BIENVENIDO A THE MATRIX");
WriteLine("================================================");
WriteLine();

var config = InicializarConfiguracion();

WriteLine();
WriteLine($"  Iniciando simulacion con dimension: {config.Dimension}x{config.Dimension}");
WriteLine($"  Tiempo de ejecucion: {config.TiempoSimulacionSegundos}s");
WriteLine();

var matrix = new MatrixService(config.Dimension, config.TiempoSimulacionSegundos * 1000);

matrix.Inicializar();

matrix.Ejecutar();

matrix.MostrarInforme();

ConfigValues InicializarConfiguracion() {
    var args = Environment.GetCommandLineArgs();

    if (args.Length >= 3)
        if (int.TryParse(args[1], out var dimension) &&
            int.TryParse(args[2], out var tiempo)) {
            Config.Dimension = dimension;
            Config.TiempoSimulacionSegundos = tiempo;
        }

    WriteLine($"  Configuracion - Dimension: {Config.Dimension}, Tiempo: {Config.TiempoSimulacionSegundos}s");

    return new ConfigValues(Config.Dimension, Config.TiempoSimulacionSegundos);
}