using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Command
{
    public class UpdateLocadorCommandResponse
    {
        public LocadorOutputDto Locador { get; set; }

        public UpdateLocadorCommandResponse(LocadorOutputDto locador)
        {
            Locador = locador;
        }
    }
}
