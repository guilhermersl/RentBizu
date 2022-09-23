using RentBizu.Application.AluguelContext.Dto;

namespace RentBizu.Application.AluguelContext.Handler.Query
{
    public class GetAluguelQueryResponse
    {
        public AluguelOutputDto Aluguel { get; set; }

        public GetAluguelQueryResponse(AluguelOutputDto aluguel)
        {
            Aluguel = aluguel;
        }
    }
}
