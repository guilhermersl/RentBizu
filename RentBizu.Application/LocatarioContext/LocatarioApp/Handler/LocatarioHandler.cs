using MediatR;
using RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command;
using RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query;
using RentBizu.Application.LocatarioContext.LocatarioApp.Service;

namespace RentBizu.Application.LocadorContext.LocatarioApp.Handler
{
    public class LocatarioHandler : IRequestHandler<CreateLocatarioCommand, CreateLocatarioCommandResponse>,
                                IRequestHandler<GetAllLocatarioQuery, GetAllLocatarioQueryResponse>,
                                IRequestHandler<GetLocatarioQuery, GetLocatarioQueryResponse>,
                                IRequestHandler<UpdateLocatarioCommand, UpdateLocatarioCommandResponse>,
                                IRequestHandler<DeleteLocatarioCommand, DeleteLocatarioCommandResponse>
    {
        private readonly ILocatarioService _locatarioService;

        public LocatarioHandler(ILocatarioService locatarioService)
        {
            _locatarioService = locatarioService;
        }

        public async Task<CreateLocatarioCommandResponse> Handle(CreateLocatarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _locatarioService.Create(request.Locatario);
            return new CreateLocatarioCommandResponse(result);
        }

        public async Task<GetAllLocatarioQueryResponse> Handle(GetAllLocatarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _locatarioService.GetAll();
            return new GetAllLocatarioQueryResponse(result);
        }

        public async Task<GetLocatarioQueryResponse> Handle(GetLocatarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _locatarioService.Get(request.Id);
            return new GetLocatarioQueryResponse(result);
        }

        public async Task<UpdateLocatarioCommandResponse> Handle(UpdateLocatarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _locatarioService.Update(request.Id, request.Locatario);
            return new UpdateLocatarioCommandResponse(result);
        }

        public async Task<DeleteLocatarioCommandResponse> Handle(DeleteLocatarioCommand request, CancellationToken cancellationToken)
        {
            await _locatarioService.Delete(request.Id);
            return new DeleteLocatarioCommandResponse();
        }
    }
}
