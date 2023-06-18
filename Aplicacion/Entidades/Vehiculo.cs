namespace Aplicacion.Entidades;
public class Vehiculo : Asegurable
{ 
    public static int CantidadAsegurados { get; set; }
    public int TitularId { get; init; }
    public Titular? Titular { get; set; }
    public string Dominio { get; set; } = "Indefinido";
    public string Marca { get; set; } = "Indefinido";
    public string Fabricacion { get; set; } = "Indefinido";
    
    public Vehiculo() {

    }
    public Vehiculo(string dominio, string marca, string fabricacion) {
        Dominio = dominio;
        Marca = marca;
        Fabricacion = fabricacion;
    }
    public override string ToString()
    {
        return $"{Id},{TitularId},{Dominio},{Marca},{Fabricacion}";
    }
}