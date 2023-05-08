namespace Aplicacion;

interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza poliza);
    void EliminarPoliza(int polizaId);
    void ModificarPoliza(int polizaId);
    List<Poliza> ListarPolizas();
}