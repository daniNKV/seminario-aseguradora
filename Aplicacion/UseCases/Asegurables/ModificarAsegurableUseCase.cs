using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class ModificarAsegurableUseCase : AsegurableUseCase
{
    public ModificarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio) {
    }
    public void Ejecutar(Vehiculo asegurable)
    {
        try {
            Repositorio.ModificarAsegurable(asegurable);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}