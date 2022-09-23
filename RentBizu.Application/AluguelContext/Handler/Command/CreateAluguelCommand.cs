using MediatR;
using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Command
{
    public class CreateAluguelCommand : IRequest<CreateAluguelCommandResponse>
    {
        public Guid LocatarioId { get; set; }
        public Guid PlanoContaId { get; set; }
        public AluguelInputDto Aluguel { get; set; }

        public CreateAluguelCommand(Guid locatarioId, Guid planoContaId, AluguelInputDto aluguel)
        {
            LocatarioId = locatarioId;
            PlanoContaId = planoContaId;
            Aluguel = aluguel;
        }
    }
}
