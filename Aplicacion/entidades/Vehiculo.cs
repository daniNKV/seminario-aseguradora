namespace Aplicacion;

public class Vehiculo: IAsegurable
{
    public static int cantidadAsegurados { get; set; } = 0;
    public int id { get; set; }
    public int titularId { get; set; } 
    public String dominio { get; set; } = "Indefinido";
    public String marca { get; set; } = "Indefinido";
    public DateTime fabricacion { get; set; }
}