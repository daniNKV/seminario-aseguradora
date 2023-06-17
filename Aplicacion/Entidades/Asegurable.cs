namespace Aplicacion.Entidades;

public abstract class Asegurable
{
    public static int TotalItemsAsegurados { get; set; }
    public int Id { get; set; }
    public int TitularId { get; init; }
    
}