namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioSiniestro : IRepositorio<Siniestro>
{
    List<Tercero> ListarTerceros(Siniestro siniestro);
}