using Aplicacion;
public class RepositorioPolizaTXT: IRepositorioPoliza
{
    readonly string _nombreArchivo = "polizas.txt";

    public void AgregarPoliza(Poliza poliza)
    {
        using var streamWriter = new StreamWriter(_nombreArchivo, true);
        Poliza.cantidadPolizas++;
        streamWriter.WriteLine(Poliza.cantidadPolizas);
        streamWriter.WriteLine(poliza.elementoAsegurado);
        streamWriter.WriteLine(poliza.valorAsegurado);
        streamWriter.WriteLine(poliza.inicioVigencia);
        streamWriter.WriteLine(poliza.finVigencia);
        streamWriter.WriteLine(poliza.tipoCobertura);
        streamWriter.WriteLine(poliza.franquicia);
    }

    public void EliminarPoliza(int polizaId)
    {

    }

    public void ModificarPoliza(Poliza poliza) {

    }

    public List<Poliza> ListarPolizas()
    {
        var res = new List<Poliza>();
        using var streamReader = new StreamReader(_nombreArchivo);

        while (!streamReader.EndOfStream) {
            var poliza = new Poliza();
            poliza.id = int.Parse(streamReader.ReadLine() ?? "");
            poliza.elementoAsegurado =
        }
    }

}