namespace Aplicacion.Entidades;

public class Titular: Persona {
    public static int CantidadTitulares { get; set; } = 0;
    public int Id { get; set; }
    public string Direccion { get; set; } = "Indefinido";
    public string Email { get; set; } = "Indefinido";
    public List<Vehiculo>? ItemsAsegurados { get; set; } = new List<Vehiculo>();

    public Titular()
    {
    }
    public Titular(int dni, string apellido, string nombre): base(dni, nombre, apellido) {
        Id = -1;
        ItemsAsegurados = new List<Vehiculo>();

    }
    public Titular(int dni, string nombre, string apellido, string direccion): base(dni, nombre, apellido) {
        Id = -1;
        ItemsAsegurados = new List<Vehiculo>();
        Direccion = direccion;
    }

    public override string ToString()
    {
        return base.ToString() + $" {Id} {Direccion} {Email} ";
    }
    
    public void AgregarVehiculo(Vehiculo vehiculo) {
        if (ItemsAsegurados != null) {
            ItemsAsegurados.Add(vehiculo);
        }
    }
}