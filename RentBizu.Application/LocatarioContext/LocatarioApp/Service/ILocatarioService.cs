
using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Service
{
    public interface ILocatarioService
    {
        Task<LocatarioOutputDto> Create(LocatarioInputDto dto);
        Task<List<LocatarioOutputDto>> GetAll();
        Task<LocatarioOutputDto> Get(Guid Id);
        Task<LocatarioOutputDto> Update(Guid id, LocatarioInputDto dto);
        Task Delete(Guid Id);

    }
}