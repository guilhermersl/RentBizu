
using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Command
{
    public class CreateAluguelCommandResponse
    {
        public AluguelOutputDto Aluguel { get; set; }

        public CreateAluguelCommandResponse(AluguelOutputDto aluguel)
        {
            Aluguel = aluguel;
        }
    }
}
