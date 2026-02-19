namespace _07_HerenciaInterfaces.Models;

// ============================================================
// CLASE BASE: Persona
// Clase padre para todas las personas del equipo
// ============================================================
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string Nacionalidad { get; set; } = string.Empty;

    public Persona() { }

    public Persona(int id, string nombre, string apellidos, int edad, string nacionalidad)
    {
        Id = id;
        Nombre = nombre;
        Apellidos = apellidos;
        Edad = edad;
        Nacionalidad = nacionalidad;
    }

    public virtual void Presentarse()
    {
        Console.WriteLine($"Hola, soy {Nombre} {Apellidos}, tengo {Edad} años y soy de {Nacionalidad}");
    }

    public string NombreCompleto => $"{Nombre} {Apellidos}";
}
