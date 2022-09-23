using MediatR;
using RentBizu.Application.AluguelContext.Handler.Command;
using RentBizu.Application.AluguelContext.Handler.Query;
using RentBizu.Application.AluguelContext.Service;

namespace LetsMusic.Application.AluguelContext.Handler
{
    public class AluguelHandler : IRequestHandler<CreateAluguelCommand, CreateAluguelCommandResponse>,
                                IRequestHandler<GetAllAluguelQuery, GetAllAluguelQueryResponse>,
                                IRequestHandler<GetAluguelQuery, GetAluguelQueryResponse>,
                                IRequestHandler<UpdateAluguelCommand, UpdateAluguelCommandResponse>,
                                IRequestHandler<DeleteAluguelCommand, DeleteAluguelCommandResponse>
    {
        private readonly IAluguelService _aluguelService;

        public AluguelHandler(IAluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        public async Task<CreateAluguelCommandResponse> Handle(CreateAluguelCommand request, CancellationToken cancellationToken)
        {
            var result = await _aluguelService.Create(request.LocatarioId, request.PlanoContaId, request.Aluguel);
            return new CreateAluguelCommandResponse(result);
        }

        public async Task<GetAllAluguelQueryResponse> Handle(GetAllAluguelQuery request, CancellationToken cancellationToken)
        {
            var result = await _aluguelService.GetAll();
            return new GetAllAluguelQueryResponse(result);
        }

        public async Task<GetAluguelQueryResponse> Handle(GetAluguelQuery request, CancellationToken cancellationToken)
        {
            var result = await _aluguelService.Get(request.Id);
            return new GetAluguelQueryResponse(result);
        }

        public async Task<UpdateAluguelCommandResponse> Handle(UpdateAluguelCommand request, CancellationToken cancellationToken)
        {
            var result = await _aluguelService.Update(request.LocatarioId, request.PlanoContaId, request.Id, null);
            return new UpdateAluguelCommandResponse(result);
        }

        public async Task<DeleteAluguelCommandResponse> Handle(DeleteAluguelCommand request, CancellationToken cancellationToken)
        {
            await _aluguelService.Delete(request.Id);
            return new DeleteAluguelCommandResponse();
        }
    }
}
