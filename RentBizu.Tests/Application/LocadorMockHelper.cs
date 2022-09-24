using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace LetsMusic.Tests.Application.LocadorContext
{
    public class LocadorMockHelper
    {
        public static LocadorOutputDto MockLocadorOutputDto()
        {
            var id = Guid.NewGuid();
            return new LocadorOutputDto(Guid.NewGuid(), "Guilherme", "05875645717", "guilhermersl@yahoo.com.br", "21966733860", new List<PlanoContaOutputDto>());
        }

        public static LocadorInputDto MockLocadorInputDto()
            => new LocadorInputDto("Guilherme", "05875645717", "guilhermersl@yahoo.com.br", "21966733860");
    }
}
