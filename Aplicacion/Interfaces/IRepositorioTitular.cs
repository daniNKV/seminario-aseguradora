namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioTitular
{
    void AgregarTitular(Titular titular);
    void EliminarTitular(int titularId);
    void ModificarTitular(Titular titular);
    List<Titular> ListarTitulares();
}