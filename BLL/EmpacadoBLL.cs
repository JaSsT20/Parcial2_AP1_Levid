using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
public class EmpacadoBLL
{
    private Contexto _contexto;
    public EmpacadoBLL(Contexto contexto)
    {	
        _contexto = contexto;
    }

    public bool Existe(int EmpacadoId)
    {
        return _contexto.Empacados.Any(emp => emp.EmpacadoId == EmpacadoId);
    }
    public bool Insertar(Empacado empacado)
    {
        bool modificado = false;
        try{
            Productos? producto;
            foreach(var detalle in empacado.EmpacadoDetalles)
            {
                producto = _contexto.Productos.SingleOrDefault(p => p.ProductoId == detalle.ProductoId);
                if(producto != null)
                {
                    producto.Existencia -= detalle.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    _contexto.Entry(detalle).State = EntityState.Added;
                }
            }
            var producido = _contexto.Productos.SingleOrDefault(p => p.ProductoId == empacado.ProductoId);
            if(producido != null)
            {
                producido.Existencia += empacado.Cantidad;
                _contexto.Entry(producido).State = EntityState.Modified;
            }
            _contexto.Entry(empacado).State = EntityState.Added;
            modificado = _contexto.SaveChanges() >0;
            _contexto.Entry(empacado).State = EntityState.Detached;
        } 
        catch(Exception)
        {
            return modificado;
        }
        return modificado;
    }
    public bool Modificar(Empacado empacado)
    {
        bool modificado = false;
        try{
            var EmpacadoAntiguo = Buscar(empacado.EmpacadoId);
            Productos? producto;
            if(EmpacadoAntiguo != null){
                foreach(var detalle in EmpacadoAntiguo.EmpacadoDetalles)
                {
                    producto = _contexto.Productos.Find(detalle.Id);
                    if(producto !=null)
                        producto.Existencia += detalle.Cantidad;
                }
                var producidoAntiguo = _contexto.Productos.Find(EmpacadoAntiguo.ProductoId);
                if(producidoAntiguo != null)
                {
                    producidoAntiguo.Existencia -= EmpacadoAntiguo.Cantidad;
                    _contexto.Entry(producidoAntiguo).State = EntityState.Modified;
                }
            }
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM EmpacadosDetalle WHERE EmpacadoId = {empacado.EmpacadoId}");
            foreach (var nuevo in empacado.EmpacadoDetalles)
            {
                producto = _contexto.Productos.Find(nuevo.Id);
                if(producto != null)
                    producto.Existencia -= nuevo.Cantidad;
                _contexto.Entry(nuevo).State = EntityState.Added;
            }
            var ProducidoNuevo = _contexto.Productos.Find(empacado.ProductoId);
            if(ProducidoNuevo != null)
            {
                ProducidoNuevo.Existencia += empacado.Cantidad;
                _contexto.Entry(ProducidoNuevo).State = EntityState.Modified;
            }
            _contexto.Entry(empacado).State = EntityState.Modified;
            modificado= _contexto.SaveChanges() > 0;
            _contexto.Entry(empacado).State = EntityState.Detached;
        }
        catch(Exception)
        {
            return false;
        }
        return modificado;
    }
    public bool Guardar(Empacado empacado)
    {
        try{
            if(!Existe(empacado.EmpacadoId))
                return Insertar(empacado);
            else
                return Modificar(empacado);   
        }
        catch(Exception)
        {
            return false;
        }
    }
    public bool Eliminar(Empacado empacado)
    {
        bool modificado = false;
        try{
            Productos? producto;
            foreach (var detalle in empacado.EmpacadoDetalles)
            {
                producto = _contexto.Productos.SingleOrDefault(p => p.ProductoId == detalle.ProductoId);
                if(producto != null)
                {
                    producto.Existencia += detalle.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                }
            }
            var producido = _contexto.Productos.SingleOrDefault(p => p.ProductoId == empacado.ProductoId);
            if(producido != null)
            {
                producido.Existencia -= empacado.Cantidad;
                _contexto.Entry(producido).State = EntityState.Modified;
            }
            _contexto.Entry(empacado).State = EntityState.Deleted;
            modificado = _contexto.SaveChanges() > 0;
            _contexto.Entry(empacado).State = EntityState.Detached;
            
        }
        catch(Exception)
        {
            return modificado;
        }
        return modificado;
    }
    public Empacado? Buscar(int EmpacadoId)
    {
        return _contexto.Empacados.Include(e => e.EmpacadoDetalles).Where(emp => emp.EmpacadoId == EmpacadoId).AsNoTracking().SingleOrDefault();   
    }
    public List<Empacado> GetList(Expression<Func<Empacado,bool>> criterio)
    {
        return _contexto.Empacados.Include(e => e.EmpacadoDetalles).AsNoTracking().Where(criterio).ToList();
    }
}