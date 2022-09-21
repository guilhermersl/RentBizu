using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.Service
{
    public interface IPlanoContaService
    {
        Task<PlanoContaOutputDto> Create(Guid locadorId, PlanoContaInputDto dto);
        Task<List<PlanoContaOutputDto>> GetAll();
        Task<PlanoContaOutputDto> Get(Guid Id);
        Task<PlanoContaOutputDto> Update(Guid locadorId, Guid id, PlanoContaInputDto dto);
        Task Delete(Guid Id);

    }
}