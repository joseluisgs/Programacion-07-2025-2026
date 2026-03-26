using Matrix.Configuration;

namespace Matrix.Models;

public class Generico(string nombre, Localizacion localizacion) : Persona(nombre, localizacion) {
    private float _probMorir = Random.Shared.Next(101);

    public float ProbMorir {
        get => _probMorir;
        set => _probMorir = Math.Max(0, value);
    }

    public bool DebeMorir => _probMorir < Config.ProbabilidadMorirBase;

    public override string Simbolo => "🤖";

    public override string ToString() {
        return $"{Simbolo} Generico(id={Id}, nombre={Nombre}, prob={_probMorir:F2})";
    }
}