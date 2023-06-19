namespace Aplicacion.Interfaces;

public interface IRepositorio<T>
{
    T? Obtener(int id);
    void Agregar(T elemento);
    void Eliminar(int id);
    void Modificar(T elemento);
    List<T> Listar();
}