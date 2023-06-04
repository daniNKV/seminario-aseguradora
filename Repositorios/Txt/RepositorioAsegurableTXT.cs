using Aplicacion.Entidades;
using Aplicacion.Interfaces;
public class RepositorioAsegurableTXT: IRepositorioAsegurable
{
    readonly string _nombreArchivo = "asegurables.txt";

    public void AgregarAsegurable(Vehiculo vehiculo)
    {
        Vehiculo.CantidadAsegurados++;
        vehiculo.Id = Vehiculo.CantidadAsegurados;
        using (StreamWriter writer = new StreamWriter(_nombreArchivo, true))
        {
            writer.WriteLine("Vehiculo");
            writer.WriteLine($"ID: {vehiculo.Id}");
            writer.WriteLine($"ID Titular: {vehiculo.TitularId}");
            writer.WriteLine($"Dominio: {vehiculo.Dominio}");
            writer.WriteLine($"Marca: {vehiculo.Marca}");
            writer.WriteLine($"Fabricacion: {vehiculo.Fabricacion}");
        }
    }
    public void EliminarAsegurable(int id)
    {
        List<Vehiculo> asegurables = ListarAsegurables();

        Vehiculo? itemAEliminar = asegurables.Find(asegurable => asegurable.Id == id);
        
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
        Vehiculo? vehiculoExistente = asegurables.Find(vehiculoGrabado => vehiculoGrabado.Id == asegurable.Id);
        if (vehiculoExistente != null) {
            int indiceAModificar = asegurables.IndexOf(vehiculoExistente);
            asegurables.RemoveAt(indiceAModificar);
            asegurables.Insert(indiceAModificar, asegurable);
            EscribirTodos(asegurables);
        }
         else {
            throw new Exception($"No existe asegurable con id = {asegurable.Id}");
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
                vehiculo.Id = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                vehiculo.TitularId = int.Parse(reader.ReadLine()?.Split(':')[1].Trim() ?? "0");
                vehiculo.Dominio = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                vehiculo.Marca = reader.ReadLine()?.Split(':')[1].Trim() ?? "";
                vehiculo.Fabricacion= reader.ReadLine()?.Split(':')[1].Trim() ?? "";

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
                writer.WriteLine($"ID: {v.Id}");
                writer.WriteLine($"ID Titular: {v.TitularId}");
                writer.WriteLine($"Dominio: {v.Dominio}");
                writer.WriteLine($"Marca: {v.Marca}");
                writer.WriteLine($"Fabricacion: {v.Fabricacion}");
            }
        }
    }
    

}