using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Application.LocadorContext.Profile
{
    public class PlanoContaProfile : AutoMapper.Profile
    {
        public PlanoContaProfile()
        {
            CreateMap<PlanoConta, PlanoContaOutputDto>();

            CreateMap<PlanoContaInputDto, PlanoConta>();
        }
    }
}
