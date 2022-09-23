using MediatR;
using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Command
{
    public class UpdateAluguelCommand : IRequest<UpdateAluguelCommandResponse>
    {
        public Guid LocatarioId { get; set; }
        public Guid PlanoContaId { get; set; }
        public Guid Id { get; set; }
        public AluguelInputDto Aluguel { get; set; }

        public UpdateAluguelCommand(Guid locatarioId, Guid planoContaId, Guid id, AluguelInputDto? aluguel)
        {
            LocatarioId = locatarioId;
            PlanoContaId = planoContaId;
            Id = id;
            Aluguel = aluguel;
        }
    }
}
