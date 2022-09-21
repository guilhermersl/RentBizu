using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;
using RentBizu.Domain.LocatarioContext;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Profile
{
    public class LocatarioProfile : AutoMapper.Profile
    {
        public LocatarioProfile()
        {
            CreateMap<Locatario, LocatarioOutputDto>();

            CreateMap<LocatarioInputDto, Locatario>();
        }
    }
}
