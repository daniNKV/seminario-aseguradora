using Aplicacion.Entidades;
using Aplicacion.Interfaces;

public class RepositorioPolizaTXT: IRepositorioPoliza
{
    private const string NombreArchivo = "polizas.txt";

    public void Agregar(Poliza poliza)
    {
        Poliza.CantidadPolizas++;
        poliza.Id = Poliza.CantidadPolizas;
        using var writer = new StreamWriter(NombreArchivo, true);
        writer.WriteLine("Poliza");
        writer.WriteLine($"ID: {poliza.Id}");
        writer.WriteLine($"Cobertura: {poliza.TipoCobertura}");
        writer.WriteLine($"Franquicia: {poliza.Franquicia}");
        writer.WriteLine($"Valor Asegurado: {poliza.ValorAsegurado}");
        writer.WriteLine($"Inicio Vigencia: {poliza.InicioVigencia}");
        writer.WriteLine($"Fin Vigencia: {poliza.FinVigencia}");
        writer.WriteLine($"Elemento Asegurado: {poliza.ElementoAsegurado?.ToString()}");
    }

    public void Eliminar(int polizaId)
    {
        List<Poliza> polizas = Listar();

        Poliza? itemAEliminar = polizas.Find(poliza => poliza.Id == polizaId);
        
        if (itemAEliminar != null && polizas.Remove(itemAEliminar)){
            EscribirTodas(polizas);
            Console.WriteLine($"Se ha eliminado a la poliza con ID: {polizaId}");
        } else {
            throw new Exception("No existe poliza con el id solicitado");
        };
    }

    public void Modificar(Poliza poliza) 
    {
        List<Poliza> polizas = Listar();
        Poliza? polizaExistente = polizas.Find(polizaGrabada => polizaGrabada.Id == poliza.Id);

        if (polizaExistente != null) {
            int indiceAModificar = polizas.IndexOf(polizaExistente);
            polizas.RemoveAt(indiceAModificar);
            polizas.Insert(indiceAModificar, poliza);
            EscribirTodas(polizas);
        } else {
            throw new Exception($"La poliza con id = {poliza.Id} no existe");
        }
    }

    public List<Poliza> Listar()
    {
        List<Poliza> polizas = new List<Poliza>();

        using (StreamReader reader = new StreamReader(NombreArchivo))
        {
            string line = reader.ReadLine() ?? "";
            while (!reader.EndOfStream) {
                Poliza poliza = new Poliza();
                poliza.Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                poliza.TipoCobertura = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                poliza.Franquicia =  Double.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0");
                poliza.ValorAsegurado =  Double.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0");
                poliza.InicioVigencia =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                poliza.FinVigencia = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                string asegurado = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                if (asegurado != null) {
                    string[] camposAsegurado = asegurado.Split(',');
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Id = int.Parse(camposAsegurado[0]);
                    vehiculo.TitularId = int.Parse(camposAsegurado[1]);
                    vehiculo.Dominio = camposAsegurado[2];
                    vehiculo.Marca = camposAsegurado[3];
                    vehiculo.Fabricacion = camposAsegurado[4];
                    poliza.ElementoAsegurado = vehiculo;
                }
                reader.ReadLine();
                polizas.Add(poliza);
            }
        }
        return polizas;
    }
    
    private void EscribirTodas(List<Poliza> polizas)
    {
        using (StreamWriter writer = new StreamWriter(NombreArchivo, false))
        {
            foreach(Poliza poliza in polizas) {
                writer.WriteLine("Poliza");
                writer.WriteLine($"ID: {poliza.Id}");
                writer.WriteLine($"Cobertura: {poliza.TipoCobertura}");
                writer.WriteLine($"Franquicia: {poliza.Franquicia}");
                writer.WriteLine($"Valor Asegurado: {poliza.ValorAsegurado}");
                writer.WriteLine($"Inicio Vigencia: {poliza.InicioVigencia}");
                writer.WriteLine($"Fin Vigencia: {poliza.FinVigencia}");
                writer.WriteLine($"Elemento Asegurado: {poliza.ElementoAsegurado?.ToString()}");
            }
        }
    }


}