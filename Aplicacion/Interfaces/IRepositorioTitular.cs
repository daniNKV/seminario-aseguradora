namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioTitular : IRepositorio<Titular>
{
    List<Asegurable> ListarItemsAsegurados(Titular titular);
}