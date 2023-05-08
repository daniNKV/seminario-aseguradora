using Aplicacion;
using System.Text.Json;
public class RepositorioPolizaTXT: IRepositorioPoliza
{
    readonly string _nombreArchivo = "polizas.txt";

    public void AgregarPoliza(Poliza poliza)
    {
        using var streamWriter = new StreamWriter(_nombreArchivo, true);
        poliza.id = Poliza.cantidadPolizas + 1;
        streamWriter.WriteLine(ConvertirJSON(poliza));
    }

    public void EliminarPoliza(int polizaId)
    {
        List<Poliza> polizas = LeerTodas();

        Poliza? itemAEliminar = polizas.Find(poliza => poliza.id == polizaId);
        
        if (itemAEliminar != null && polizas.Remove(itemAEliminar)){
            Console.WriteLine($"Se ha eliminado a la poliza con ID: {polizaId}");
        } else {
            throw new Exception("No existe poliza con el id solicitado");
        };
    }

    public void ModificarPoliza(Poliza poliza) 
    {
        List<Poliza> polizas = LeerTodas();

        int indiceAModificar = polizas.IndexOf(poliza);

        if (indiceAModificar != -1) {
            polizas.RemoveAt(indiceAModificar);
            polizas.Insert(indiceAModificar, poliza);
            EscribirTodas(polizas);
        } else {
            throw new Exception($"La poliza con id = {poliza.id} no existe");
        }
    }

    public List<Poliza> ListarPolizas()
    {
        List<Poliza> polizas = LeerTodas();
        
        return polizas;
    }

    private Poliza? LeerPoliza(StreamReader stream)
    {
        Poliza poliza = new Poliza();
        string polizaJson = stream.ReadLine() ?? "";
        return ParseJSON(polizaJson);
    }

    private List<Poliza> LeerTodas()
    {
        string polizasJson = File.ReadAllText(_nombreArchivo);        
        List<Poliza> polizas = JsonSerializer.Deserialize<List<Poliza>>(polizasJson) ?? new List<Poliza>();
        if (polizas.Count == 0) throw new Exception("No existen polizas en existencia");
        return polizas;
    }
    
    private void EscribirTodas(List<Poliza> polizas)
    {
        string polizasJson = JsonSerializer.Serialize(polizas);
        File.WriteAllText(_nombreArchivo, polizasJson);
    
    }

    private string ConvertirJSON(Poliza poliza) 
    {
        return JsonSerializer.Serialize(poliza);
    }
    private Poliza? ParseJSON(string JSONObj)
    {
        Poliza? poliza = JsonSerializer.Deserialize<Poliza>(JSONObj);
        return poliza;
    }

}