using Aplicacion.Entidades;
using Aplicacion.Interfaces;

namespace Repositorios.Txt;

public class RepositorioTitularTxt: IRepositorioTitular
{
    private const string NombreArchivo = "titulares.txt";

    public void Agregar(Titular titular)
    {   
        if (File.Exists(NombreArchivo))
        {
            var titulares = Listar();
            if (titulares.Exists(titularGrabado => titularGrabado.Dni == titular.Dni)) {
                throw new Exception($"Ya existe un titular con DNI {titular.Dni}");
            }
        }
        Titular.CantidadTitulares++;
        titular.Id = Titular.CantidadTitulares;
        using var writer = new StreamWriter(NombreArchivo, true);
        writer.WriteLine("Titular");
        writer.WriteLine($"ID: {titular.Id}");
        writer.WriteLine($"DNI: {titular.Dni}");
        writer.WriteLine($"Nombre: {titular.Nombre}");
        writer.WriteLine($"Apellido: {titular.Apellido}");
        writer.WriteLine($"Telefono: {titular.Telefono}");
        writer.WriteLine($"Dirección: {titular.Direccion}");
        writer.WriteLine($"Email: {titular.Email}");
        writer.WriteLine("Items asegurados:");
        if (titular.ItemsAsegurados != null)
        {
            foreach (IAsegurable item in titular.ItemsAsegurados)
            {   
                writer.WriteLine($"- {item}");
            }
        } else {
            writer.WriteLine("");
        }
    }

    public void Eliminar(int titularId)
    {
        var titulares = Listar();

        var itemAEliminar = titulares.Find(titular => titular.Id == titularId);
        
        if (itemAEliminar != null && titulares.Remove(itemAEliminar)){
            EscribirTodos(titulares);
            Console.WriteLine($"Se ha eliminado al titular con ID: {titularId}");
        } else {
            throw new Exception("No existe titular con el id solicitado");
        }
    }

    public void Modificar(Titular titular) 
    {
        var titulares = Listar();
        var titularExistente = titulares.Find(titularGrabado => titularGrabado.Dni == titular.Dni);
        if (titularExistente != null) {
            var indiceAModificar = titulares.IndexOf(titularExistente);
            titulares.RemoveAt(indiceAModificar);
            titulares.Insert(indiceAModificar, titular);

            EscribirTodos(titulares);
        } else {
            throw new Exception($"No existe titular con dni = {titular.Dni}");
        }
    }
    
    public List<Titular> Listar()
    {
        var titulares = new List<Titular>();

        using var reader = new StreamReader(NombreArchivo);
        var line = reader.ReadLine() ?? "";
        while (!reader.EndOfStream) {
            var titular = new Titular
            {
                Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0"),
                Dni = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0"),
                Nombre = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Apellido = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Telefono = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Direccion = reader.ReadLine()?.Split(':')[1].Trim() ?? "",
                Email = reader.ReadLine()?.Split(':')[1].Trim() ?? ""
            };
            var itemsAsegurados = new List<IAsegurable>();
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null  && !line.Equals("Titular"))
            {
                var item = line.Split(',');
                var asegurable = new Vehiculo(item[2], item[3], item[4])
                {
                    Id = int.Parse(item[0]),
                    TitularId = int.Parse(item[1])
                };
                itemsAsegurados.Add(asegurable); 
            }
            titulares.Add(titular);
        }

        return titulares;
    }

    public List<IAsegurable> ListarItemsAsegurados(Titular titular)
    {
        throw new NotImplementedException();
    }

    private static void EscribirTodos(List<Titular> titulares)
    {
        using var writer = new StreamWriter(NombreArchivo, false);
        foreach(var titular in titulares) {
            writer.WriteLine("Titular");
            writer.WriteLine($"ID: {titular.Id}");
            writer.WriteLine($"DNI: {titular.Dni}");
            writer.WriteLine($"Nombre: {titular.Nombre}");
            writer.WriteLine($"Apellido: {titular.Apellido}");
            writer.WriteLine($"Telefono: {titular.Telefono}");
            writer.WriteLine($"Dirección: {titular.Direccion}");
            writer.WriteLine($"Email: {titular.Email}");
            writer.WriteLine("Items asegurados:");
            if (titular.ItemsAsegurados == null) continue;
            foreach (IAsegurable item in titular.ItemsAsegurados)
            {
                writer.WriteLine($"- {item}");
            }
        }
    }
}