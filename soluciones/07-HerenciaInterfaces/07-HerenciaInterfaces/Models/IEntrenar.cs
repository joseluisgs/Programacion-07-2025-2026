namespace _07_HerenciaInterfaces.Models;

public interface IEntrenar
{
    string Especialidad { get; set; }
    int AñosExperiencia { get; set; }
    void Entrenar();
}
