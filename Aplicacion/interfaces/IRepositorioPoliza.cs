namespace Aplicacion;

public interface IRepositorioPoliza: IRepositorio<Poliza>
{
    void AgregarPoliza(Poliza poliza);
    void EliminarPoliza(int id);
    void ModificarPoliza(Poliza poliza);
    List<Poliza> ListarPolizas();
}