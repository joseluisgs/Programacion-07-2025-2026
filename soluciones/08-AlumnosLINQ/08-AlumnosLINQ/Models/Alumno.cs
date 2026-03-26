namespace _08_AlumnosLINQ.Models;

public record Alumno(int Id, string Dni, string Nombre, string Apellidos, string NombreCurso, double Nota, int Edad)
{
    public string NombreCompleto => $"{Nombre} {Apellidos}";
}
