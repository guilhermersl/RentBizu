using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Application.LocadorContext.LocadorApp.Profile
{
    public class LocadorProfile : AutoMapper.Profile
    {
        public LocadorProfile()
        {
            CreateMap<Locador, LocadorOutputDto>();

            CreateMap<LocadorInputDto, Locador>();
        }
    }
}
