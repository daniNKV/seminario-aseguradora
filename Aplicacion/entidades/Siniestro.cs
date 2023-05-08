namespace Aplicacion;

public class Siniestro
{
    public int id { get; set; }
    public Poliza? poliza { get; set; }
    public DateTime fecha_ingreso { get; set; }
    public DateTime fecha_suceso { get; set; }
    public String direccion { get; set; } = "Indefinido";
    public String descripcion { get; set; } = "Indefinido";

}