using Aplicacion.Entidades;
using Aplicacion.Interfaces;
public class RepositorioAsegurableTXT: IRepositorioAsegurable
{
    readonly string _nombreArchivo = "asegurables.txt";

    public void AgregarAsegurable(Vehiculo vehiculo)
    {
        Vehiculo.cantidadAsegurados++;
        vehiculo.id = Vehiculo.cantidadAsegurados;
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, true))
        {
            writer.WriteLine("Vehiculo");
            writer.WriteLine($"ID: {vehiculo.id}");
            writer.WriteLine($"ID Titular: {vehiculo.titularId}");
            writer.WriteLine($"Dominio: {vehiculo.dominio}");
            writer.WriteLine($"Marca: {vehiculo.marca}");
            writer.WriteLine($"Fabricacion: {vehiculo.fabricacion}");
        }
    }
    public void EliminarAsegurable(int id)
    {
        List<Vehiculo> asegurables = ListarAsegurables();

        Vehiculo? itemAEliminar = asegurables.Find(asegurable => asegurable.id == id);
        
        if (itemAEliminar != null && asegurables.Remove(itemAEliminar)){
            EscribirTodos(asegurables);
            Console.WriteLine($"Se ha eliminado al asegurable con ID: {id}");
        } else {
            throw new Exception("No existe asegurable con el id solicitado");
        };
    }

    public void ModificarAsegurable(Vehiculo asegurable) 
    {
        List<Vehiculo> asegurables = ListarAsegurables();
        Vehiculo? vehiculoExistente = asegurables.Find(vehiculoGrabado => vehiculoGrabado.id == asegurable.id);
        if (vehiculoExistente != null) {
            int indiceAModificar = asegurables.IndexOf(vehiculoExistente);
            asegurables.RemoveAt(indiceAModificar);
            asegurables.Insert(indiceAModificar, asegurable);
            EscribirTodos(asegurables);
        }
         else {
            throw new Exception($"No existe asegurable con id = {asegurable.id}");
        };
    }
    
    public List<Vehiculo> ListarAsegurables()
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();

        using (StreamReader reader = new StreamReader(_nombreArchivo))
        {
            string line = reader.ReadLine() ?? "";
            while (!reader.EndOfStream) {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                vehiculo.titularId = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                vehiculo.dominio = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                vehiculo.marca = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                vehiculo.fabricacion= reader.ReadLine()?.Split(':')[1].Trim() ?? "";

                reader.ReadLine();
                vehiculos.Add(vehiculo);
            }
        }
        return vehiculos;
    }

        private void EscribirTodos(List<Vehiculo> vehiculos)
    {
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, false))
        {
            foreach(Vehiculo v in vehiculos) {
                writer.WriteLine("Vehiculo");
                writer.WriteLine($"ID: {v.id}");
                writer.WriteLine($"ID Titular: {v.titularId}");
                writer.WriteLine($"Dominio: {v.dominio}");
                writer.WriteLine($"Marca: {v.marca}");
                writer.WriteLine($"Fabricacion: {v.fabricacion}");
            }
        }
    }
    

}