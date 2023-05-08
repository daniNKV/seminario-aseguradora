namespace Aplicacion;

public interface IAsegurable
{
    static int CantidadAsegurados { get; set; }
    int id { get; set; }
    int titularId { get; set; }
}