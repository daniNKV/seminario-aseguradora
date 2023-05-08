namespace Aplicacion;

public class Titular: Persona {
    public static int cantidadTitulares { get; set; } = 0;
    public int id { get; set; }
    public string direccion { get; set; } = "Indefinido";
    public string email { get; set; } = "Indefinido";
    public List<Vehiculo>? ItemsAsegurados { get; set; }

    public Titular(): base(){
        ItemsAsegurados = new List<Vehiculo>();
    }
    public Titular(int dni, string apellido, string nombre): base(dni, nombre, apellido) {
        id = -1;
        ItemsAsegurados = new List<Vehiculo>();

    }
    public Titular(int dni, string nombre, string apellido, string direccion): base(dni, nombre, apellido) {
        id = -1;
        ItemsAsegurados = new List<Vehiculo>();
        this.direccion = direccion;
    }

    public override string ToString()
    {
        return base.ToString() + $" {id} {direccion} {email} ";
    }
    
    public void agregarVehiculo(Vehiculo vehiculo) {
        if (ItemsAsegurados != null) {
            this.ItemsAsegurados.Add(vehiculo);
        }
    }
}