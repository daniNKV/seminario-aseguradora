namespace Aplicacion;

public interface IRepositorioPoliza: IRepositorio<Poliza>
{
    void AgregarPoliza(Poliza poliza);
    void EliminarPoliza(int polizaId);
    void ModificarPoliza(int polizaId);
    List<Poliza> ListarPolizas();
}