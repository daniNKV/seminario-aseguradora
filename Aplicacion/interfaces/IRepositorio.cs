namespace Aplicacion;

public interface IRepositorio<T>
{
    void Agregar(T elemento);
    void Eliminar(int id);
    void Modificar(int id);
    List<T> Listar();
}