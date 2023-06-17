namespace Aplicacion.Entidades;

public class Siniestro
{
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public Poliza? Poliza { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaSuceso { get; set; }
    public String Direccion { get; set; } = "Indefinido";
    public String Descripcion { get; set; } = "Indefinido";

}