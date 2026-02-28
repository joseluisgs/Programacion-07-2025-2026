namespace _07_HerenciaInterfaces.Models;

// ============================================================
// CLASE: Masajista
// Hereda de Persona. Representa un masajista del equipo
// ============================================================
public class Masajista : Persona
{
    public string Titulacion { get; set; } = string.Empty;
    public int AñosExperiencia { get; set; }
    public List<string> Especialidades { get; set; } = new();

    public Masajista() { }

    public Masajista(int id, string nombre, string apellidos, int edad, string nacionalidad,
        string titulacion, int añosExperiencia, List<string> especialidades)
        : base(id, nombre, apellidos, edad, nacionalidad)
    {
        Titulacion = titulacion;
        AñosExperiencia = añosExperiencia;
        Especialidades = especialidades;
    }

    public void DarMasaje()
    {
        Console.WriteLine($"{NombreCompleto} está dando un masaje");
    }

    public override void Presentarse()
    {
        Console.WriteLine($"Soy {NombreCompleto}, masajista con {Titulacion} y {AñosExperiencia} años de experiencia");
    }
}
