namespace Matrix.Models;

public class Posicion(int fila, int columna) {
    public int Fila { get; set; } = fila;
    public int Columna { get; set; } = columna;

    public override string ToString() {
        return $"[{Fila + 1}, {Columna + 1}]";
    }
}