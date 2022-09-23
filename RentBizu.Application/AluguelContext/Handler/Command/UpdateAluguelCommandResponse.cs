using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Command
{
    public class UpdateAluguelCommandResponse
    {
        public AluguelOutputDto Aluguel { get; set; }

        public UpdateAluguelCommandResponse(AluguelOutputDto Aluguel)
        {
            Aluguel = Aluguel;
        }
    }
}
