namespace Matrix.Models;

public class Neo() : Persona("Neo", new Localizacion(0, 0, "Ciudad 01")) {
    public bool EsElegido { get; private set; }

    public override string Simbolo => "🧔";

    public void ActualizarElegido() {
        EsElegido = Random.Shared.Next(2) == 1;
    }

    public override string ToString() {
        return $"{Simbolo} Neo(id={Id})";
    }
}