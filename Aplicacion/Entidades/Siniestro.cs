namespace Aplicacion.Entidades;

public class Siniestro
{
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public Poliza? Poliza { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public DateTime? FechaSuceso { get; set; }
    public string Direccion { get; set; } = "Indefinido";
    public string Descripcion { get; set; } = "Indefinido";
    public List<Tercero> Terceros { get; set; } = new ();

}