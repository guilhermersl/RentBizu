using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Service
{
    public interface ILocadorService
    {
        Task<LocadorOutputDto> Create(LocadorInputDto dto);
        Task<List<LocadorOutputDto>> GetAll();
        Task<LocadorOutputDto> Get(Guid Id);
        Task<LocadorOutputDto> Update(Guid id, LocadorInputDto dto);
        Task Delete(Guid Id);

    }
}