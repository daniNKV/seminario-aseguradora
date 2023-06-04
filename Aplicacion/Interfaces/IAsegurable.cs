namespace Aplicacion.Interfaces;

public interface IAsegurable
{
    static int CantidadAsegurados { get; set; }
    int Id { get; set; }
    int TitularId { get; set; }
}