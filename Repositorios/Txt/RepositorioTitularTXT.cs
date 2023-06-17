using Aplicacion.Entidades;
using Aplicacion.Interfaces;

public class RepositorioTitularTXT: IRepositorioTitular
{
    readonly string _nombreArchivo = "titulares.txt";

    public void Agregar(Titular titular)
    {   
        if (File.Exists(_nombreArchivo))
        {
            List<Titular> titulares = Listar();
            if (titulares.Exists(titularGrabado => titularGrabado.Dni == titular.Dni)) {
                throw new Exception($"Ya existe un titular con DNI {titular.Dni}");
            }
        }
        Titular.CantidadTitulares++;
        titular.Id = Titular.CantidadTitulares;
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, true))
        {
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
                    writer.WriteLine($"- {item.ToString()}");
                }
            } else {
                writer.WriteLine("");
            }
        }
    }

    public void Eliminar(int titularId)
    {
        List<Titular> titulares = Listar();

        Titular? itemAEliminar = titulares.Find(titular => titular.Id == titularId);
        
        if (itemAEliminar != null && titulares.Remove(itemAEliminar)){
            EscribirTodos(titulares);
            Console.WriteLine($"Se ha eliminado al titular con ID: {titularId}");
        } else {
            throw new Exception("No existe titular con el id solicitado");
        };
    }

    public void Modificar(Titular titular) 
    {
        List<Titular> titulares = Listar();
        Titular? titularExistente = titulares.Find(titularGrabado => titularGrabado.Dni == titular.Dni);
        if (titularExistente != null) {
            int indiceAModificar = titulares.IndexOf(titularExistente);
                titulares.RemoveAt(indiceAModificar);
                titulares.Insert(indiceAModificar, titular);

                EscribirTodos(titulares);
        } else {
            throw new Exception($"No existe titular con dni = {titular.Dni}");
        };
    }
    
    public List<Titular> Listar()
    {
        List<Titular> titulares = new List<Titular>();

        using (StreamReader reader = new StreamReader(_nombreArchivo))
        {
            string? line = reader.ReadLine() ?? "";
            while (!reader.EndOfStream) {
                Titular titular = new Titular();
                titular.Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                titular.Dni = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                titular.Nombre =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.Apellido =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.Telefono =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.Direccion = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.Email = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                List<IAsegurable> itemsAsegurados = new List<IAsegurable>();
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null  && !line.Equals("Titular"))
                {
                    string[] item = line.Split(',');
                    Vehiculo asegurable = new Vehiculo(item[2], item[3], item[4]);
                    asegurable.Id = int.Parse((item[0]));
                    asegurable.TitularId = int.Parse(item[1]);
                    itemsAsegurados.Add(asegurable); 
                }
                titulares.Add(titular);
            }
        }
        return titulares;
    }

    private void EscribirTodos(List<Titular> titulares)
    {
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, false))
        {
            foreach(Titular titular in titulares) {
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
                        writer.WriteLine($"- {item.ToString()}");
                    }
                }
            }
        }
    }
}