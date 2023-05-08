namespace Aplicacion;

interface IRepositorioTitular
{
    void AgregarTitular(Titular titular);
    void EliminarTitular(int titularDni);
    void ModificarTitular(int titularDni);
    List<Titular> ListarTitulares();
}