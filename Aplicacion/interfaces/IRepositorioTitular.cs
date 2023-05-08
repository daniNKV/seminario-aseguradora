namespace Aplicacion;

public interface IRepositorioTitular
{
    void AgregarTitular(Titular titular);
    void EliminarTitular(int titularId);
    void ModificarTitular(int titularDni);
    List<Titular> ListarTitulares();
}