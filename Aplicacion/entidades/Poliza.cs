namespace Aplicacion;

public abstract class Poliza
{
    public int id { get; set; }
    public IAsegurable? elementoAsegurado { get; set; }
    public double valorAsegurado { get; set; }
    public DateTime inicioVigencia { get; set; }
    public DateTime finVigencia { get; set; }
    
}