namespace Matrix.Models;

public class Smith(string nombre, Localizacion localizacion, int probInfectar) : Persona(nombre, localizacion) {
    public int ProbInfectar { get; } = probInfectar;

    public override string Simbolo => "😈";

    public override string ToString() {
        return $"{Simbolo} Smith(id={Id}, prob={ProbInfectar})";
    }
}