using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class AgregarTitularUseCase : TitularUseCase
{

    public AgregarTitularUseCase(IRepositorioTitular repositorio) : base(repositorio) {
    }

    public void Ejecutar(Titular titular)
    {
        try {
            Repositorio.AgregarTitular(titular);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}