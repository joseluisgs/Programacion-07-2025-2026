namespace _07_HerenciaInterfaces.Models;

// ============================================================
// CLASE: Jugador
// Hereda de Persona. Representa un jugador de campo
// ============================================================
public class Jugador : Persona
{
    public string Posicion { get; set; } = string.Empty;
    public int Goles { get; set; }
    public int Asistencias { get; set; }
    public bool EsCapitan { get; set; }

    public Jugador() { }

    public Jugador(int id, string nombre, string apellidos, int edad, string nacionalidad,
        string posicion, int goles, int numAsistencias, bool esCapitan = false)
        : base(id, nombre, apellidos, edad, nacionalidad)
    {
        Posicion = posicion;
        Goles = goles;
        Asistencias = numAsistencias;
        EsCapitan = esCapitan;
    }

    public override void Presentarse()
    {
        Console.WriteLine($"Soy {NombreCompleto}, juego como {Posicion}, tengo {Goles} goles y {Asistencias} asistencias");
    }
}
