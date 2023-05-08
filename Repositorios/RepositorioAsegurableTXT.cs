using Aplicacion;
using System.Text.Json;
public class RepositorioAsegurableTXT: IRepositorioAsegurable
{
    readonly string _nombreArchivo = "asegurables.txt";

    public void AgregarAsegurable(IAsegurable asegurable)
    {
        using var streamWriter = new StreamWriter(_nombreArchivo, true);
        asegurable.id = IAsegurable.CantidadAsegurados + 1;
        streamWriter.WriteLine(ConvertirJSON(asegurable));
    }

    public void EliminarAsegurable(int id)
    {
        List<IAsegurable> asegurables = LeerTodas();

        IAsegurable? itemAEliminar = asegurables.Find(asegurable => asegurable.id == id);
        
        if (itemAEliminar != null && asegurables.Remove(itemAEliminar)){
            Console.WriteLine($"Se ha eliminado al asegurable con ID: {id}");
        } else {
            throw new Exception("No existe asegurable con el id solicitado");
        };
    }

    public void ModificarAsegurable(IAsegurable asegurable) 
    {
        List<IAsegurable> asegurables = LeerTodas();
        int indiceAModificar = asegurables.IndexOf(asegurable);
        if (indiceAModificar != -1) {
            asegurables.RemoveAt(indiceAModificar);
            asegurables.Insert(indiceAModificar, asegurable);
            EscribirTodas(asegurables);
        }
         else {
            throw new Exception($"No existe asegurable con id = {asegurable.id}");
        };
    }
    
    public List<IAsegurable> ListarAsegurables()
    {
        List<IAsegurable> asegurables = LeerTodas();

        return asegurables;
    }

    private List<IAsegurable> LeerTodas()
    {
        string asegurablesJson = File.ReadAllText(_nombreArchivo);        
        List<IAsegurable> asegurables = JsonSerializer.Deserialize<List<IAsegurable>>(asegurablesJson) ?? new List<IAsegurable>();
        if (asegurables.Count == 0) throw new Exception("No existen titulares en existencia");
        return asegurables;
    }
    
    private void EscribirTodas(List<IAsegurable> asegurables)
    {
        string asegurablesJson = JsonSerializer.Serialize(asegurables);
        File.WriteAllText(_nombreArchivo, asegurablesJson);
    
    }

    private string ConvertirJSON(IAsegurable asegurable) 
    {
        return JsonSerializer.Serialize(asegurable);
    }
    private IAsegurable? ParseJSON(string JSONObj)
    {
        IAsegurable? asegurable = JsonSerializer.Deserialize<IAsegurable>(JSONObj);
        return asegurable;
    }
}