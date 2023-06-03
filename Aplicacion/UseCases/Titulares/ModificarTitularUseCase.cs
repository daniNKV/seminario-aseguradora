
using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.UseCases.Titulares;

public class ModificarTitularUseCase : TitularUseCase
{
    public ModificarTitularUseCase(IRepositorioTitular repositorio) : base(repositorio) {
    }
    public void Ejecutar(Titular titular)
    {
        try {
            Repositorio.ModificarTitular(titular);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}