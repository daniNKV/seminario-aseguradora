namespace Aplicacion.Entidades;

public class Tercero: Persona
{
    public int Id { get; set; }
    public string Aseguradora { get; set; } = "Indefinido";
    public int SiniestroId { get; set; } = -1;
    public Siniestro? Siniestro { get; set;}

    public Tercero(int dni, string nombre, string apellido): base(dni, nombre, apellido) {

    }

    public Tercero(int dni, string nombre, string apellido, string aseguradora): base(dni, nombre, apellido) {
        Id = -1;
        Aseguradora = aseguradora;
    }
    public Tercero(int dni, string nombre, string apellido, string aseguradora, Siniestro siniestro): base(dni, nombre, apellido) {
    Id = -1;
    Aseguradora = aseguradora;
    Siniestro = siniestro;
}
    

    public Tercero(string nombre, string apellido, int dni, string aseguradora, string telefono): base(dni, nombre, apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Aseguradora = aseguradora;
        Telefono = telefono;
    }

    public Tercero()
    {
    }
}