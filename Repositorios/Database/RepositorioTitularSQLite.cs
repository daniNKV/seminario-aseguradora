using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class RepositorioTitularSqLite : IRepositorioTitular
{
    public void Agregar(Titular elemento)
    {
        using var context = new AseguradoraContexto();
        context.Titulares.Add(elemento);
        context.SaveChanges();    
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Titular elemento)
    {
        throw new NotImplementedException();
    }

    public List<Titular> Listar()
    {
        using var context = new AseguradoraContexto();
        var titulares = context.Titulares.ToList();
        return titulares;    
    }

    public List<Vehiculo> ListarItemsAsegurados(Titular titular)
    {
        throw new NotImplementedException();

    }
    public List<Titular> ListarTitularesConSusVehiculos()
    {
        using var context = new AseguradoraContexto();
        var titulares = context.Titulares.Include(t => t.ItemsAsegurados).ToList();
        return titulares;        
    }
}