namespace _07_HerenciaInterfaces.Models;

// ============================================================
// CLASE: Entrenador
// Hereda de Persona e implementa IEntrenar e ICapitan
// Representa un entrenador del equipo
// ============================================================
public class Entrenador : Persona, IEntrenar, ICapitan
{
    public string Especialidad { get; set; } = string.Empty;
    public int AñosExperiencia { get; set; }
    public string EquipoActual { get; set; } = string.Empty;
    public int TitulosGanados { get; set; }

    public Entrenador() { }

    public Entrenador(int id, string nombre, string apellidos, int edad, string nacionalidad,
        string especialidad, int añosExperiencia, string equipoActual, int titulosGanados)
        : base(id, nombre, apellidos, edad, nacionalidad)
    {
        Especialidad = especialidad;
        AñosExperiencia = añosExperiencia;
        EquipoActual = equipoActual;
        TitulosGanados = titulosGanados;
    }

    public void Entrenar()
    {
        Console.WriteLine($"{NombreCompleto} está entrenando al equipo");
    }

    public void DarDiscurso()
    {
        Console.WriteLine($"{NombreCompleto}: \"¡Vamos a darlo todo en el campo!\"");
    }

    public void Motivacion()
    {
        Console.WriteLine($"{NombreCompleto} motiva a sus jugadores");
    }

    public override void Presentarse()
    {
        Console.WriteLine($"Soy {NombreCompleto}, entrenador de {EquipoActual}, tengo {AñosExperiencia} años de experiencia");
    }
}
