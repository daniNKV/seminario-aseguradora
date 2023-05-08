namespace Aplicacion;

public class Titular: Persona {
    private int id;
    public String direccion { get; set; } = "Indefinido";
    public List<IAsegurable>? asegurados;
}