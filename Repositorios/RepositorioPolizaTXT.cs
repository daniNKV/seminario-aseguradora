using Aplicacion;
using System.Text.Json;
public class RepositorioPolizaTXT: IRepositorioPoliza
{
    readonly string _nombreArchivo = "polizas.txt";

    public void AgregarPoliza(Poliza poliza)
    {
        Poliza.cantidadPolizas++;
        poliza.id = Poliza.cantidadPolizas;
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, true))
        {
            writer.WriteLine("Poliza");
            writer.WriteLine($"ID: {poliza.id}");
            writer.WriteLine($"Cobertura: {poliza.tipoCobertura}");
            writer.WriteLine($"Franquicia: {poliza.franquicia}");
            writer.WriteLine($"Valor Asegurado: {poliza.valorAsegurado}");
            writer.WriteLine($"Inicio Vigencia: {poliza.inicioVigencia}");
            writer.WriteLine($"Fin Vigencia: {poliza.finVigencia}");
            writer.WriteLine($"Elemento Asegurado: {poliza.elementoAsegurado?.ToString()}");

        }
    }

    public void EliminarPoliza(int polizaId)
    {
        List<Poliza> polizas = ListarPolizas();

        Poliza? itemAEliminar = polizas.Find(poliza => poliza.id == polizaId);
        
        if (itemAEliminar != null && polizas.Remove(itemAEliminar)){
            EscribirTodas(polizas);
            Console.WriteLine($"Se ha eliminado a la poliza con ID: {polizaId}");
        } else {
            throw new Exception("No existe poliza con el id solicitado");
        };
    }

    public void ModificarPoliza(Poliza poliza) 
    {
        List<Poliza> polizas = ListarPolizas();
        Poliza? polizaExistente = polizas.Find(polizaGrabada => polizaGrabada.id == poliza.id);

        if (polizaExistente != null) {
            int indiceAModificar = polizas.IndexOf(polizaExistente);
            polizas.RemoveAt(indiceAModificar);
            polizas.Insert(indiceAModificar, poliza);
            EscribirTodas(polizas);
        } else {
            throw new Exception($"La poliza con id = {poliza.id} no existe");
        }
    }

    public List<Poliza> ListarPolizas()
    {
        List<Poliza> polizas = new List<Poliza>();

        using (StreamReader reader = new StreamReader(_nombreArchivo))
        {
            string line = reader.ReadLine() ?? "";
            while (!reader.EndOfStream) {
                Poliza poliza = new Poliza();
                poliza.id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                poliza.tipoCobertura = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                poliza.franquicia =  Double.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0");
                poliza.valorAsegurado =  Double.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0");
                poliza.inicioVigencia =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                poliza.finVigencia = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                string asegurado = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                if (asegurado != null) {
                    string[] camposAsegurado = asegurado.Split(',');
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.id = int.Parse(camposAsegurado[0]);
                    vehiculo.titularId = int.Parse(camposAsegurado[1]);
                    vehiculo.dominio = camposAsegurado[2];
                    vehiculo.marca = camposAsegurado[3];
                    vehiculo.fabricacion = camposAsegurado[4];
                    poliza.elementoAsegurado = vehiculo;
                }
                reader.ReadLine();
                polizas.Add(poliza);
            }
        }
        return polizas;
    }
    
    private void EscribirTodas(List<Poliza> polizas)
    {
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, false))
        {
            foreach(Poliza poliza in polizas) {
                writer.WriteLine("Poliza");
                writer.WriteLine($"ID: {poliza.id}");
                writer.WriteLine($"Cobertura: {poliza.tipoCobertura}");
                writer.WriteLine($"Franquicia: {poliza.franquicia}");
                writer.WriteLine($"Valor Asegurado: {poliza.valorAsegurado}");
                writer.WriteLine($"Inicio Vigencia: {poliza.inicioVigencia}");
                writer.WriteLine($"Fin Vigencia: {poliza.finVigencia}");
                writer.WriteLine($"Elemento Asegurado: {poliza.elementoAsegurado?.ToString()}");
            }
        }
    }


}