namespace Matrix.Models;

public abstract class Persona(string nombre, Localizacion localizacion) : IComparable<Persona> {
    private static int _contador;

    public int Id { get; } = ++_contador;
    public string MarcaTiempo { get; } = DateTime.UtcNow.ToString("HH:mm:ss.ffffff");
    public string Nombre { get; set; } = nombre;
    public Localizacion Localizacion { get; set; } = localizacion;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public abstract string Simbolo { get; }

    public int CompareTo(Persona? other) {
        return other == null ? 1 : Id.CompareTo(other.Id);
    }

    public override string ToString() {
        return $"Persona(nombre='{Nombre}', id={Id}, localizacion={Localizacion})";
    }
}