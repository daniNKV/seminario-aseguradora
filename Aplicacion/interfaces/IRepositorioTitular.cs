namespace Aplicacion;

interface IRepositorioTitular
{
    void AgregarTitular(Titular titular);
    void EliminarTitular(int titularId);
    void ModificarTitular(int titularId);
    List<IAsegurable> ListarTitulares();
}