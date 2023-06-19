using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using static System.Double;

namespace Repositorios.Txt;

public class RepositorioPolizaTxt: IRepositorioPoliza
{
    private const string NombreArchivo = "polizas.txt";

    public Poliza Obtener(int id)
    {
        throw new NotImplementedException();
    }

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
        writer.WriteLine($"Elemento Asegurado: {poliza.VehiculoAsegurado}");
    }

    public void Eliminar(int polizaId)
    {
        var polizas = Listar();

        var itemAEliminar = polizas.Find(poliza => poliza.Id == polizaId);
        
        if (itemAEliminar != null && polizas.Remove(itemAEliminar)){
            EscribirTodas(polizas);
            Console.WriteLine($"Se ha eliminado a la poliza con ID: {polizaId}");
        } else {
            throw new Exception("No existe poliza con el id solicitado");
        }
    }

    public void Modificar(Poliza poliza) 
    {
        var polizas = Listar();
        var polizaExistente = polizas.Find(polizaGrabada => polizaGrabada.Id == poliza.Id);

        if (polizaExistente != null) {
            var indiceAModificar = polizas.IndexOf(polizaExistente);
            polizas.RemoveAt(indiceAModificar);
            polizas.Insert(indiceAModificar, poliza);
            EscribirTodas(polizas);
        } else {
            throw new Exception($"La poliza con id = {poliza.Id} no existe");
        }
    }

    public List<Poliza> Listar()
    {
        var polizas = new List<Poliza>();

        using var reader = new StreamReader(NombreArchivo);
        var line = reader.ReadLine() ?? "";
        while (!reader.EndOfStream) {
            var poliza = new Poliza
            {
                Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0"),
                TipoCobertura = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Franquicia = Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0"),
                ValorAsegurado = Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0.0"),
                InicioVigencia = DateTime.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? ""),
                FinVigencia = DateTime.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "")
            };
            var asegurado = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
            if (asegurado != null) {
                var camposAsegurado = asegurado.Split(',');
                var vehiculo = new Vehiculo
                {
                    Id = int.Parse(camposAsegurado[0]),
                    TitularId = int.Parse(camposAsegurado[1]),
                    Dominio = camposAsegurado[2],
                    Marca = camposAsegurado[3],
                    Fabricacion = camposAsegurado[4]
                };
                poliza.VehiculoAsegurado = vehiculo;
            }
            reader.ReadLine();
            polizas.Add(poliza);
        }

        return polizas;
    }

    public Poliza? ObtenerPolizaDeVehiculo(Vehiculo vehiculo)
    {
        throw new NotImplementedException();
    }

    public Poliza? ObtenerPolizaDeSiniestro(Siniestro siniestro)
    {
        throw new NotImplementedException();
    }

    private static void EscribirTodas(List<Poliza> polizas)
    {
        using var writer = new StreamWriter(NombreArchivo, false);
        foreach(var poliza in polizas) {
            writer.WriteLine("Poliza");
            writer.WriteLine($"ID: {poliza.Id}");
            writer.WriteLine($"Cobertura: {poliza.TipoCobertura}");
            writer.WriteLine($"Franquicia: {poliza.Franquicia}");
            writer.WriteLine($"Valor Asegurado: {poliza.ValorAsegurado}");
            writer.WriteLine($"Inicio Vigencia: {poliza.InicioVigencia}");
            writer.WriteLine($"Fin Vigencia: {poliza.FinVigencia}");
            writer.WriteLine($"Elemento Asegurado: {poliza.VehiculoAsegurado}");
        }
    }


}