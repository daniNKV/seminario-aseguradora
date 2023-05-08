namespace Aplicacion;

public enum Cobertura {
    ResponsabilidadCivil,
    TodoRiesgo
}

public class PolizaVehicular: Poliza
{
    public Cobertura tipoCobertura { get; set; }
    public double franquicia { get; set; }
}