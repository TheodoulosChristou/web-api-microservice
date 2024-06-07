using Application.DTOs;
using Application.Interface;
using Domain.Entities;


namespace Application.Interface.Repositories
{
    public interface ITemplateRepository : IGenericRepository<Template>
    {
        //Task<IQueryable<TemplateDto>> GetAllProjectDetails();

    }
}
