using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class ModificarAsegurableUseCase
{
    private readonly IRepositorioAsegurable _repositorio;
    public ModificarAsegurableUseCase(IRepositorioAsegurable repositorio) {
        _repositorio = repositorio;
    }
    public void Ejecutar(Vehiculo asegurable)
    {
        try {
            _repositorio.ModificarAsegurable(asegurable);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}