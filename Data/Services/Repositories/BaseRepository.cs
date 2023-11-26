using Data.Services.Interfaces;

namespace Data.Services.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly EfCoreContext _context;

    public BaseRepository(EfCoreContext context)
    {
        _context = context;
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entityToDelete = _context.Set<T>().Find(id);

        if (entityToDelete == null) return;

        _context.Set<T>().Remove(entityToDelete);
        _context.SaveChanges();
    }
}