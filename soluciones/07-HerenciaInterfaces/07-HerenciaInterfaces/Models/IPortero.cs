namespace _07_HerenciaInterfaces.Models;

public interface IPortero
{
    int Paradas { get; set; }
    double PorcentajeParadas { get; set; }
    int GolesRecibidos { get; set; }
    void Parar();
}
