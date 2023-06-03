namespace Aplicacion.Entidades;

using Interfaces;

public class Vehiculo: IAsegurable
{
    public static int cantidadAsegurados { get; set; } = 0;
    public int id { get; set; }
    public int titularId { get; set; } 
    public string dominio { get; set; } = "Indefinido";
    public string marca { get; set; } = "Indefinido";
    public string fabricacion { get; set; } = "Indefinido";

    public Vehiculo() {

    }



    public Vehiculo(string dominio, string marca, string fabricacion) {
        this.dominio = dominio;
        this.marca = marca;
        this.fabricacion = fabricacion;
    }


    public override string ToString()
    {
        return $"{id},{titularId},{dominio},{marca},{fabricacion}";
    }
}