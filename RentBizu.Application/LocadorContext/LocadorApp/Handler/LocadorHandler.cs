using MediatR;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Command;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Query;
using RentBizu.Application.LocadorContext.LocadorApp.Service;

namespace LetsMusic.Application.LocadorContext.LocadorApp.Handler
{
    public class LocadorHandler : IRequestHandler<CreateLocadorCommand, CreateLocadorCommandResponse>,
                                IRequestHandler<GetAllLocadorQuery, GetAllLocadorQueryResponse>,
                                IRequestHandler<GetLocadorQuery, GetLocadorQueryResponse>,
                                IRequestHandler<UpdateLocadorCommand, UpdateLocadorCommandResponse>,
                                IRequestHandler<DeleteLocadorCommand, DeleteLocadorCommandResponse>
    {
        private readonly ILocadorService _locadorService;

        public LocadorHandler(ILocadorService locadorService)
        {
            _locadorService = locadorService;
        }

        public async Task<CreateLocadorCommandResponse> Handle(CreateLocadorCommand request, CancellationToken cancellationToken)
        {
            var result = await _locadorService.Create(request.Locador);
            return new CreateLocadorCommandResponse(result);
        }

        public async Task<GetAllLocadorQueryResponse> Handle(GetAllLocadorQuery request, CancellationToken cancellationToken)
        {
            var result = await _locadorService.GetAll();
            return new GetAllLocadorQueryResponse(result);
        }

        public async Task<GetLocadorQueryResponse> Handle(GetLocadorQuery request, CancellationToken cancellationToken)
        {
            var result = await _locadorService.Get(request.Id);
            return new GetLocadorQueryResponse(result);
        }

        public async Task<UpdateLocadorCommandResponse> Handle(UpdateLocadorCommand request, CancellationToken cancellationToken)
        {
            var result = await _locadorService.Update(request.Id, request.Locador);
            return new UpdateLocadorCommandResponse(result);
        }

        public async Task<DeleteLocadorCommandResponse> Handle(DeleteLocadorCommand request, CancellationToken cancellationToken)
        {
            await _locadorService.Delete(request.Id);
            return new DeleteLocadorCommandResponse();
        }
    }
}
