namespace SmartCity.Core;

public abstract class DispositivoIoT
{
    public int Id { get; set; }
    public bool Estado { get; set; }
    public int Bateria { get; set; }

    public DispositivoIoT(int id, bool estado, int bateria)
    {
        Id = id;
        Estado = estado;
        Bateria = bateria;
    }

    public virtual void RealizarDiagnostico()
    {
        Console.WriteLine($"[ID: {Id} Estado: {(Estado ? "Encendido" : "Apagado")} Bateria: {Bateria}%]");
    }
    public void RecargarBateria()
    {
        Bateria = 100;
    }
}