namespace Aplicacion;

public abstract class Persona
{
    public string nombre { get; set; } = "Indefinido";
    public string apellido { get; set; } = "Indefinido";
    public int dni { get; set; } = -1;
    public string telefono{ get; set; } = "Indefinido";

    public Persona() {
        
    }
    public Persona(int dni, string nombre, string apellido, string telefono) {
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
    }
    public Persona(int dni, string nombre, string apellido) {
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
    }

    public override string ToString()
    {
        return $"{nombre} {apellido} {dni} {telefono}" ; 
    }

}