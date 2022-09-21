using RentBizu.Application.AluguelContext.PlanoContaApp.Dto;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.Domain.AluguelContext;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Application.AluguelContext.Profile
{
    public class AluguelProfile : AutoMapper.Profile
    {
        public AluguelProfile()
        {
            CreateMap<Aluguel, AluguelOutputDto>();

            CreateMap<AluguelInputDto, Aluguel>();
        }
    }
}
