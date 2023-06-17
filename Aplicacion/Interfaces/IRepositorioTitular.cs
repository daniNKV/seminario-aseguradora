namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioTitular : IRepositorio<Titular>
{
    List<IAsegurable> ListarItemsAsegurados(Titular titular);
}