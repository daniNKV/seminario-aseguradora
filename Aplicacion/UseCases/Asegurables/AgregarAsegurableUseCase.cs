using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Asegurables;

public class AgregarAsegurableUseCase : AsegurableUseCase
{
    public AgregarAsegurableUseCase(IRepositorioAsegurable repositorio) : base(repositorio){
    }

    public void Ejecutar(Vehiculo asegurable)
    { 
        Repositorio.AgregarAsegurable(asegurable);
    }
}