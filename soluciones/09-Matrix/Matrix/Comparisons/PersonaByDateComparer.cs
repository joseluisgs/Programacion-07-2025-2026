using Matrix.Models;

namespace Matrix.Comparisons;

public class PersonaByDateComparer : IComparer<Persona> {
    public int Compare(Persona? a, Persona? b) {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.CreatedAt.CompareTo(b.CreatedAt);
    }
}