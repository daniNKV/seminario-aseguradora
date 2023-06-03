namespace Aplicacion.Entidades;

public class Tercero: Persona
{
    private int _id { get; set; }
    public string _aseguradora { get; set; } = "Indefinido";
    public Siniestro? _siniestro { get => _siniestro; set => _siniestro = value;}

    public Tercero(int dni, string nombre, string apellido): base(dni, nombre, apellido) {

    }

    public Tercero(int dni, string nombre, string apellido, string aseguradora): base(dni, nombre, apellido) {
        _id = -1;
        _aseguradora = aseguradora;
    }
    public Tercero(int dni, string nombre, string apellido, string aseguradora, Siniestro siniestro): base(dni, nombre, apellido) {
    _id = -1;
    _aseguradora = aseguradora;
    _siniestro = siniestro;
}
}