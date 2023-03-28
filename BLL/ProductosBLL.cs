using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
public class ProductosBLL
{
    private Contexto _contexto;
    public ProductosBLL(Contexto contexto)
    {	
        _contexto = contexto;
    }
    public bool Existe(int productoId)
    {
        return _contexto.Productos.Any(prd => prd.ProductoId == productoId);
    }
    public bool Insertar(Productos producto)
    {
        _contexto.Productos.Add(producto);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(Productos producto)
    {
        _contexto.Entry(producto).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Guardar(Productos producto)
    {
        try{
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }
        catch(Exception e)
        {
            System.Console.WriteLine($"Error {e.Message}");
            return false;
        }   
    }
    public bool Eliminar(Productos producto)
    {
        try{
            _contexto.Entry(producto).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        catch(Exception){
            return false;
        }
    }
    public List<Productos> GetList(Expression<Func<Productos,bool>> criterio)
    {
        return _contexto.Productos.AsNoTracking().Where(criterio).ToList();
    }

    public Productos? Buscar(int ProductoId)
    {
        return _contexto.Productos.Where(prod => prod.ProductoId == ProductoId).AsNoTracking().SingleOrDefault();
    }
}