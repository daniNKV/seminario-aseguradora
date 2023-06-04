
using Aplicacion.Interfaces;

namespace Aplicacion.Entidades;

public enum Cobertura {
    ResponsabilidadCivil,
    TodoRiesgo
}
public class Poliza
{
    public static int CantidadPolizas { get; set; } = 0;
    public int Id { get; set; }
    public string TipoCobertura { get; set; } = "Indefinido";
    public double Franquicia { get; set; } = -1;
    public IAsegurable? ElementoAsegurado { get; set; }
    public double ValorAsegurado { get; set; } = -1;
    public string InicioVigencia { get; set; } = "Indefinido";
    public string FinVigencia { get; set; } = "Indefinido";
    
    public Poliza() {
        Id = -1;

    }

    public Poliza(string cobertura, IAsegurable elementoAsegurado) {
        TipoCobertura = cobertura;
        ElementoAsegurado = elementoAsegurado;
    }
    public Poliza(string cobertura, double franquicia, IAsegurable elementoAsegurado, double valorAsegurado, string inicio) {
        Id = -1;
        TipoCobertura = cobertura;
        Franquicia = franquicia;
        ElementoAsegurado = elementoAsegurado;
        ValorAsegurado = valorAsegurado;
        InicioVigencia = inicio;
    }

    public override string ToString()
    {
        return $"{Id},{TipoCobertura},{Franquicia},{ValorAsegurado},{InicioVigencia},{FinVigencia},{ElementoAsegurado}";
    }

}