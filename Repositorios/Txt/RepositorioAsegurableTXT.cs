using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Txt;

public class RepositorioVehiculoTxt: IRepositorioVehiculo
{
    private const string NombreArchivo = "asegurables.txt";

    public void Agregar(Vehiculo vehiculo)
    {
        Vehiculo.CantidadAsegurados++;
        vehiculo.Id = Vehiculo.CantidadAsegurados;
        using var writer = new StreamWriter(NombreArchivo, true);
        writer.WriteLine("Vehiculo");
        writer.WriteLine($"ID: {vehiculo.Id}");
        writer.WriteLine($"ID Titular: {vehiculo.TitularId}");
        writer.WriteLine($"Dominio: {vehiculo.Dominio}");
        writer.WriteLine($"Marca: {vehiculo.Marca}");
        writer.WriteLine($"Fabricacion: {vehiculo.Fabricacion}");
    }
    public void Eliminar(int id)
    {
        var asegurables = Listar();

        var itemAEliminar = asegurables.Find(asegurable => asegurable.Id == id);
        
        if (itemAEliminar != null && asegurables.Remove(itemAEliminar)){
            EscribirTodos(asegurables);
            Console.WriteLine($"Se ha eliminado al asegurable con ID: {id}");
        } else {
            throw new Exception("No existe asegurable con el id solicitado");
        }
    }

    public void Modificar(Vehiculo asegurable) 
    {
        var asegurables = Listar();
        var vehiculoExistente = asegurables.Find(vehiculoGrabado => vehiculoGrabado.Id == asegurable.Id);
        if (vehiculoExistente != null) {
            var indiceAModificar = asegurables.IndexOf(vehiculoExistente);
            asegurables.RemoveAt(indiceAModificar);
            asegurables.Insert(indiceAModificar, asegurable);
            EscribirTodos(asegurables);
        }
        else {
            throw new Exception($"No existe asegurable con id = {asegurable.Id}");
        }
    }
    
    public List<Vehiculo> Listar()
    {
        var vehiculos = new List<Vehiculo>();

        using var reader = new StreamReader(NombreArchivo);
        var line = reader.ReadLine() ?? "";
        while (!reader.EndOfStream) {
            var vehiculo = new Vehiculo
            {
                Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0"),
                TitularId = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0"),
                Dominio = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Marca = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Fabricacion = reader.ReadLine()?.Split(':')[1].Trim() ?? ""
            };

            reader.ReadLine();
            vehiculos.Add(vehiculo);
        }

        return vehiculos;
    }

    private static void EscribirTodos(List<Vehiculo> vehiculos)
    {
        using var writer = new StreamWriter(NombreArchivo, false);
        foreach(var v in vehiculos) {
            writer.WriteLine("Vehiculo");
            writer.WriteLine($"ID: {v.Id}");
            writer.WriteLine($"ID Titular: {v.TitularId}");
            writer.WriteLine($"Dominio: {v.Dominio}");
            writer.WriteLine($"Marca: {v.Marca}");
            writer.WriteLine($"Fabricacion: {v.Fabricacion}");
        }
    }
    

}