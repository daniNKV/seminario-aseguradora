namespace Aplicacion;

public interface IRepositorioTitular: IRepositorio<Titular>
{
    void AgregarTitular(Titular titular);
    void EliminarTitular(int titularDni);
    void ModificarTitular(int titularDni);
    List<Titular> ListarTitulares();
}