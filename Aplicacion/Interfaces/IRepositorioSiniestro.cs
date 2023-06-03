namespace Aplicacion.Interfaces;
using Entidades;
public interface IRepositorioSiniestro
{
    void AgregarSiniestro(Siniestro siniestro);
    void EliminarSiniestro(int id);
    void ModificarSiniestro(Siniestro siniestro);
    List<Siniestro> ListarSiniestros();
    List<Tercero> ListarTerceros(Siniestro siniestro);
}