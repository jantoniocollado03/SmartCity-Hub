using SmartCity.Core;

namespace SmartCity.App;

public class Temporizador
{
    public void AvanzarHora(List<DispositivoIoT> dispositivos, ref int horaActual)
    {
        try
        {
            horaActual++;

            if (horaActual >= 24)
                horaActual = 0;

            foreach (DispositivoIoT dispositivo in dispositivos)
            {
                switch (dispositivo)
                {
                    case SemaforoInteligente semaforo:
                        semaforo.ActualizarEstado(horaActual);
                        break;

                    case SensorClima sensor:
                        sensor.TomarLectura();
                        break;

                    case FarolaSolar farola:
                        farola.ActualizarEstado(horaActual);
                        break;
                }
            }

            Console.WriteLine("Simulación avanzada correctamente.");
        }
        catch (BateriaAgotadaException ex)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ ! ] ALERTA CRÍTICA [ ! ]");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("Pulsa una tecla para continuar...");
            Console.ReadKey();
        }
    }
}