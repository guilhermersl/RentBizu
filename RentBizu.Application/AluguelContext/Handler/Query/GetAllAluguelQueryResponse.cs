using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Query
{
    public class GetAllAluguelQueryResponse
    {
        public IList<AluguelOutputDto> Alugueis { get; set; }

        public GetAllAluguelQueryResponse(IList<AluguelOutputDto> alugueis)
        {
            Alugueis = alugueis;
        }
    }
}
