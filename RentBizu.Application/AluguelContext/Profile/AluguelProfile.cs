using RentBizu.Application.AluguelContext.Dto;
using RentBizu.Domain.AluguelContext;

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
