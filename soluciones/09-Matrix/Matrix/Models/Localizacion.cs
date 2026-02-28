namespace Matrix.Models;

public class Localizacion(int latitud, int longitud, string ciudad) {
    public int Latitud { get; set; } = latitud;
    public int Longitud { get; set; } = longitud;
    public string Ciudad { get; set; } = ciudad;

    public override string ToString() {
        return $"[{Latitud + 1}, {Longitud + 1}] ({Ciudad})";
    }
}