namespace Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    T? GetByID(long id);
    List<T> GetAll();
    void Add(T model);
    void Delete(long id);
    void Update(T model);
}
