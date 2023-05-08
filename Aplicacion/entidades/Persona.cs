namespace Aplicacion;

public abstract class Persona
{
    public string _nombre { get; set; } = "Indefinido";
    public string _apellido { get; set; } = "Indefinido";
    public int _dni { get; set; } = -1;
    public int _telefono{ get; set; } = -1;

    public Persona(int dni, string nombre, string apellido, int telefono) {
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _telefono = telefono;
    }
    public Persona(int dni, string nombre, string apellido) {
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
    }

    public override string ToString()
    {
        return $"{_nombre} {_apellido} {_dni} {_telefono}" ; 
    }

}