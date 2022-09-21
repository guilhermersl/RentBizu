using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Command
{
    public class CreateLocadorCommandResponse
    {
        public LocadorOutputDto Locador { get; set; }

        public CreateLocadorCommandResponse(LocadorOutputDto locador)
        {
            Locador = locador;
        }
    }
}
