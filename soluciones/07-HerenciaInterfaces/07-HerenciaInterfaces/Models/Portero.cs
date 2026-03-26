namespace _07_HerenciaInterfaces.Models;

// ============================================================
// CLASE: Portero
// Hereda de Jugador e implementa IPortero
// Representa un guardameta
// ============================================================
public class Portero : Jugador, IPortero
{
    public int Paradas { get; set; }
    public double PorcentajeParadas { get; set; }
    public int GolesRecibidos { get; set; }
    public int PenalesAtajados { get; set; }

    public Portero() { }

    public Portero(int id, string nombre, string apellidos, int edad, string nacionalidad,
        int paradas, double porcentajeParadas, int golesRecibidos, int penalesAtajados)
        : base(id, nombre, apellidos, edad, nacionalidad, "Portero", 0, 0)
    {
        Paradas = paradas;
        PorcentajeParadas = porcentajeParadas;
        GolesRecibidos = golesRecibidos;
        PenalesAtajados = penalesAtajados;
    }

    public void Parar()
    {
        Console.WriteLine($"{NombreCompleto} realiza una parada");
    }

    public override void Presentarse()
    {
        Console.WriteLine($"Soy {NombreCompleto}, soy portero con {Paradas} paradas ({PorcentajeParadas}%)");
    }
}
