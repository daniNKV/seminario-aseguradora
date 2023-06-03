
namespace Aplicacion.Entidades;

using Interfaces;

public enum Cobertura {
    ResponsabilidadCivil,
    TodoRiesgo
}
public class Poliza

{

    public static int cantidadPolizas { get; set; } = 0;
    public int id { get; set; }
    public string tipoCobertura { get; set; } = "Indefinido";
    public double franquicia { get; set; } = -1;
    public IAsegurable? elementoAsegurado { get; set; }
    public double valorAsegurado { get; set; } = -1;
    public string inicioVigencia { get; set; } = "Indefinido";
    public string finVigencia { get; set; } = "Indefinido";
    
    public Poliza() {
        this.id = -1;

    }

    public Poliza(string cobertura, IAsegurable elementoAsegurado) {
        this.tipoCobertura = cobertura;
        this.elementoAsegurado = elementoAsegurado;
    }
    public Poliza(string cobertura, double franquicia, IAsegurable elementoAsegurado, double valorAsegurado, string inicio) {
        this.id = -1;
        this.tipoCobertura = cobertura;
        this.franquicia = franquicia;
        this.elementoAsegurado = elementoAsegurado;
        this.valorAsegurado = valorAsegurado;
        this.inicioVigencia = inicio;
    }

    public override string ToString()
    {
        return $"{id},{tipoCobertura},{franquicia},{valorAsegurado},{inicioVigencia},{finVigencia},{elementoAsegurado?.ToString()}";
    }

}