namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioSiniestro : IRepositorio<Siniestro>
{
    List<Tercero> Listar(Siniestro siniestro);
}