using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AbilityContext _context;

    public GenericRepo(AbilityContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T entity)
    {

    }
}
