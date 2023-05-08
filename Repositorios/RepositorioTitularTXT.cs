using Aplicacion;
using System.Text.Json;
public class RepositorioTitularTXT: IRepositorioTitular
{
    readonly string _nombreArchivo = "titulares.txt";

    public void AgregarTitular(Titular titular)
    {
        using var streamWriter = new StreamWriter(_nombreArchivo, true);
        titular._id = Titular.cantidadTitulares + 1;
        streamWriter.WriteLine(ConvertirJSON(titular));
    }

    public void EliminarTitular(int titularId)
    {
        List<Titular> titulares = LeerTodas();

        Titular? itemAEliminar = titulares.Find(titular => titular._id == titularId);
        
        if (itemAEliminar != null && titulares.Remove(itemAEliminar)){
            Console.WriteLine($"Se ha eliminado al titular con ID: {titularId}");
        } else {
            throw new Exception("No existe titular con el id solicitado");
        };
    }

    public void ModificarTitular(int titularDni) 
    {
        List<Titular> titulares = LeerTodas();
        Titular? titular = titulares.Find(titular => titular._dni == titularDni);
        if (titular != null) {
            int indiceAModificar = titulares.IndexOf(titular);
            if (indiceAModificar != -1) {
                titulares.RemoveAt(indiceAModificar);
                titulares.Insert(indiceAModificar, titular);
                EscribirTodas(titulares);
            }
        } else {
            throw new Exception($"No existe titular con dni = {titularDni}");
        };
    }
    
    public List<Titular> ListarTitulares()
    {
        List<Titular> titulares = LeerTodas();

        return titulares;
    }

    private List<Titular> LeerTodas()
    {
        string titularesJson = File.ReadAllText(_nombreArchivo);        
        List<Titular> titulares = JsonSerializer.Deserialize<List<Titular>>(titularesJson) ?? new List<Titular>();
        if (titulares.Count == 0) throw new Exception("No existen titulares en existencia");
        return titulares;
    }
    
    private void EscribirTodas(List<Titular> titular)
    {
        string polizasJson = JsonSerializer.Serialize(titular);
        File.WriteAllText(_nombreArchivo, polizasJson);
    
    }

    private string ConvertirJSON(Titular poliza) 
    {
        return JsonSerializer.Serialize(poliza);
    }
    private Titular? ParseJSON(string JSONObj)
    {
        Titular? titular = JsonSerializer.Deserialize<Titular>(JSONObj);
        return titular;
    }
}