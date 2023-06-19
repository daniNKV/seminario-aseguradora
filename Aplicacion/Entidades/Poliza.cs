
using Aplicacion.Interfaces;

namespace Aplicacion.Entidades;

public enum Cobertura {
    ResponsabilidadCivil,
    TodoRiesgo
}
public class Poliza
{
    public static int CantidadPolizas { get; set; }
    public int Id { get; set; }
    public string TipoCobertura { get; set; } = "Indefinido";
    public double Franquicia { get; set; } = -1;
    public int VehiculoAseguradoId { get; set; } = -1;
    public Vehiculo? VehiculoAsegurado { get; set; }
    public double ValorAsegurado { get; set; } = -1;
    public string InicioVigencia { get; set; } = "Indefinido";
    public string FinVigencia { get; set; } = "Indefinido";
    
    public Poliza() {
    }

    public Poliza(string cobertura, Vehiculo vehiculoAsegurado) {
        TipoCobertura = cobertura;
        VehiculoAsegurado = vehiculoAsegurado;
    }
    public Poliza(string cobertura, double franquicia, Vehiculo vehiculoAsegurado, double valorAsegurado, string inicio) {
        Id = -1;
        TipoCobertura = cobertura;
        Franquicia = franquicia;
        VehiculoAsegurado = vehiculoAsegurado;
        ValorAsegurado = valorAsegurado;
        InicioVigencia = inicio;
    }

    public override string ToString()
    {
        return $"{Id},{TipoCobertura},{Franquicia},{ValorAsegurado},{InicioVigencia},{FinVigencia},{VehiculoAsegurado}";
    }

}