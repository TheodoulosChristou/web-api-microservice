using Application.Interface.Repositories;

namespace Application.Interface.UnitOfWork;

public interface IUnitOfWork
{
  

    void BeginTransaction();
    void Commit();
    void Rollback();
    Task SaveChangesAsync();
    void Dispose();
}
