namespace Aplicacion;

public class Poliza

{
    public enum Cobertura {
    ResponsabilidadCivil,
    TodoRiesgo
    }
    public static int cantidadPolizas { get; set; } = 0;
    public int id { get; set; }
    public Cobertura tipoCobertura { get; set; }
    public double franquicia { get; set; }
    public IAsegurable? elementoAsegurado { get; set; }
    public double valorAsegurado { get; set; }
    public DateTime inicioVigencia { get; set; }
    public DateTime finVigencia { get; set; }
    
    public Poliza() {

    }

}