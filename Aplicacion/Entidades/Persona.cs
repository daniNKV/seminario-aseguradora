namespace Aplicacion.Entidades;

public abstract class Persona
{
    public string Nombre { get; set; } = "Indefinido";
    public string Apellido { get; set; } = "Indefinido";
    public int Dni { get; set; } = -1;
    public string Telefono{ get; set; } = "Indefinido";

    protected Persona() {
        
    }
    protected Persona(int dni, string nombre, string apellido, string telefono) {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
    }
    protected Persona(int dni, string nombre, string apellido) {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
    }

    public override string ToString()
    {
        return $"{Nombre} {Apellido} {Dni} {Telefono}" ; 
    }

}