using Aplicacion;
public class RepositorioTitularTXT: IRepositorioTitular
{
    readonly string _nombreArchivo = "titulares.txt";

    public void AgregarTitular(Titular titular)
    {   
        if (File.Exists(_nombreArchivo))
        {
            List<Titular> titulares = ListarTitulares();
            if (titulares.Exists(titularGrabado => titularGrabado.dni == titular.dni)) {
                throw new Exception($"Ya existe un titular con DNI {titular.dni}");
            }
        }
        Titular.cantidadTitulares++;
        titular.id = Titular.cantidadTitulares;
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, true))
        {
            writer.WriteLine("Titular");
            writer.WriteLine($"ID: {titular.id}");
            writer.WriteLine($"DNI: {titular.dni}");
            writer.WriteLine($"Nombre: {titular.nombre}");
            writer.WriteLine($"Apellido: {titular.apellido}");
            writer.WriteLine($"Telefono: {titular.telefono}");
            writer.WriteLine($"Dirección: {titular.direccion}");
            writer.WriteLine($"Email: {titular.email}");
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

    public void EliminarTitular(int titularId)
    {
        List<Titular> titulares = ListarTitulares();

        Titular? itemAEliminar = titulares.Find(titular => titular.id == titularId);
        
        if (itemAEliminar != null && titulares.Remove(itemAEliminar)){
            EscribirTodos(titulares);
            Console.WriteLine($"Se ha eliminado al titular con ID: {titularId}");
        } else {
            throw new Exception("No existe titular con el id solicitado");
        };
    }

    public void ModificarTitular(Titular titular) 
    {
        List<Titular> titulares = ListarTitulares();
        Titular? titularExistente = titulares.Find(titularGrabado => titularGrabado.dni == titular.dni);
        if (titularExistente != null) {
            int indiceAModificar = titulares.IndexOf(titularExistente);
                titulares.RemoveAt(indiceAModificar);
                titulares.Insert(indiceAModificar, titular);

                EscribirTodos(titulares);
        } else {
            throw new Exception($"No existe titular con dni = {titular.dni}");
        };
    }
    
    public List<Titular> ListarTitulares()
    {
        List<Titular> titulares = new List<Titular>();

        using (StreamReader reader = new StreamReader(_nombreArchivo))
        {
            string? line = reader.ReadLine() ?? "";
            while (!reader.EndOfStream) {
                Titular titular = new Titular();
                titular.id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                titular.dni = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                titular.nombre =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.apellido =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.telefono =  reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.direccion = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                titular.email = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                List<IAsegurable> itemsAsegurados = new List<IAsegurable>();
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null  && !line.Equals("Titular"))
                {
                    string[] item = line.Split(',');
                    Vehiculo asegurable = new Vehiculo(item[2], item[3], item[4]);
                    asegurable.id = int.Parse((item[0]));
                    asegurable.titularId = int.Parse(item[1]);
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
                writer.WriteLine($"ID: {titular.id}");
                writer.WriteLine($"DNI: {titular.dni}");
                writer.WriteLine($"Nombre: {titular.nombre}");
                writer.WriteLine($"Apellido: {titular.apellido}");
                writer.WriteLine($"Telefono: {titular.telefono}");
                writer.WriteLine($"Dirección: {titular.direccion}");
                writer.WriteLine($"Email: {titular.email}");
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