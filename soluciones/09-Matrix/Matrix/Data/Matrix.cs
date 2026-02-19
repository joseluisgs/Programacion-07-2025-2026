using Matrix.Models;

namespace Matrix.Data;

public class Matriz<T>(int filas, int columnas) where T : class? {
    private readonly T?[,] _datos = new T[filas, columnas];

    public int Filas => filas;
    public int Columnas => columnas;

    public T? this[int fila, int columna] {
        get => EsValida(fila, columna) ? _datos[fila, columna] : null;
        set {
            if (EsValida(fila, columna)) _datos[fila, columna] = value;
        }
    }

    public IEnumerable<Celda<T>> Celdas {
        get {
            for (var f = 0; f < Filas; f++) {
                for (var c = 0; c < Columnas; c++) yield return new Celda<T>(f, c, _datos[f, c]);
            }
        }
    }

    public T? Get(int fila, int columna) {
        return this[fila, columna];
    }

    public void Set(int fila, int columna, T? valor) {
        this[fila, columna] = valor;
    }

    public bool EsValida(int fila, int columna) {
        return fila >= 0 && fila < Filas && columna >= 0 && columna < Columnas;
    }

    public Matriz<T> Clonar() {
        var nueva = new Matriz<T>(Filas, Columnas);
        foreach (var celda in Celdas) nueva.Set(celda.Fila, celda.Columna, celda.Valor);
        return nueva;
    }

    public override string ToString() {
        var lineas = new List<string>();

        for (var f = 0; f < Filas; f++) {
            var fila = "";
            for (var c = 0; c < Columnas; c++) {
                var valor = _datos[f, c];
                if (valor is Persona p)
                    fila += p.Simbolo + " ";
                else
                    fila += ". ";
            }

            lineas.Add(fila);
        }

        return string.Join("\n", lineas);
    }
}

public record Celda<T>(int Fila, int Columna, T? Valor);