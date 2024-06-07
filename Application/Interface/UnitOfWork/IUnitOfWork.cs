using Application.Interface.Repositories;
using Domain.Entities;

namespace Application.Interface.UnitOfWork;

public interface IUnitOfWork
{
   
    public ITemplateRepository ITemplateRepository { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
    Task SaveChangesAsync();
    void Dispose();
}
