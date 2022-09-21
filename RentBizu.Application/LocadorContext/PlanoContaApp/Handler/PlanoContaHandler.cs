using MediatR;
using RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command;
using RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query;
using RentBizu.Application.LocadorContext.Service;

namespace LetsMusic.Application.LocadorContext.PlanoContaApp.Handler
{
    public class PlanoContaHandler : IRequestHandler<CreatePlanoContaCommand, CreatePlanoContaCommandResponse>,
                                IRequestHandler<GetAllPlanoContaQuery, GetAllPlanoContaQueryResponse>,
                                IRequestHandler<GetPlanoContaQuery, GetPlanoContaQueryResponse>,
                                IRequestHandler<UpdatePlanoContaCommand, UpdatePlanoContaCommandResponse>,
                                IRequestHandler<DeletePlanoContaCommand, DeletePlanoContaCommandResponse>
    {
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaHandler(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public async Task<CreatePlanoContaCommandResponse> Handle(CreatePlanoContaCommand request, CancellationToken cancellationToken)
        {
            var result = await _planoContaService.Create(request.LocadorId, request.PlanoConta);
            return new CreatePlanoContaCommandResponse(result);
        }

        public async Task<GetAllPlanoContaQueryResponse> Handle(GetAllPlanoContaQuery request, CancellationToken cancellationToken)
        {
            var result = await _planoContaService.GetAll();
            return new GetAllPlanoContaQueryResponse(result);
        }

        public async Task<GetPlanoContaQueryResponse> Handle(GetPlanoContaQuery request, CancellationToken cancellationToken)
        {
            var result = await _planoContaService.Get(request.Id);
            return new GetPlanoContaQueryResponse(result);
        }

        public async Task<UpdatePlanoContaCommandResponse> Handle(UpdatePlanoContaCommand request, CancellationToken cancellationToken)
        {
            var result = await _planoContaService.Update(request.LocadorId, request.Id, request.PlanoConta);
            return new UpdatePlanoContaCommandResponse(result);
        }

        public async Task<DeletePlanoContaCommandResponse> Handle(DeletePlanoContaCommand request, CancellationToken cancellationToken)
        {
            await _planoContaService.Delete(request.Id);
            return new DeletePlanoContaCommandResponse();
        }
    }
}
