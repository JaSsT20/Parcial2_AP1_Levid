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
        _contexto.Empacados.Add(empacado);
        return _contexto.SaveChanges() > 0;   
    }
    public bool Modificar(Empacado empacado)
    {
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM EmpacadoDetalle WHERE EmpacadoId = {empacado.EmpacadoId}");
        foreach (var emp in empacado.EmpacadoDetalles)
        {
            _contexto.Entry(empacado).State = EntityState.Added;
        }
        _contexto.Entry(empacado).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Eliminar(Empacado empacado)
    {
        _contexto.Entry(empacado).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public Empacado? Buscar(int EmpacadoId)
    {
        return _contexto.Empacados.Where(emp => emp.EmpacadoId == EmpacadoId).AsNoTracking().SingleOrDefault();   
    }
    public List<Empacado> GetList(Expression<Func<Empacado,bool>> criterio)
    {
        return _contexto.Empacados.AsNoTracking().Where(criterio).ToList();
    }
}