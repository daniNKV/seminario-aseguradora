using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class ModificarAsegurableUseCase : UseCase<IRepositorioAsegurable>
{
    public ModificarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public void Ejecutar(Vehiculo asegurable)
    {
        try {
            Repositorio.Modificar(asegurable);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}