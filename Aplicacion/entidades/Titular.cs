namespace Aplicacion;

public class Titular: Persona {
    public static int cantidadTitulares { get; set; } = 0;
    private int _id { get; set; }
    public string _direccion { get; set; } = "Indefinido";
    public List<IAsegurable>? _asegurados { get; set; }

    public Titular(int dni, string nombre, string apellido): base(dni, nombre, apellido) {
        _id = -1;
    }
    public Titular(int dni, string nombre, string apellido, string direccion): base(dni, nombre, apellido) {
        _direccion = direccion;
    }

    public override string ToString()
    {
        return base.ToString() + $" {_direccion} + {_id}";
    }
}