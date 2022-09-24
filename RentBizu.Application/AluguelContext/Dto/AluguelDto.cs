using RentBizu.CrossCutting.Enum;

namespace RentBizu.Application.AluguelContext.Dto
{
    public record AluguelInputDto(
        string Descricao
    );

    public record AluguelOutputDto(
        Guid Id,      
        Guid LocatarioId,
        Guid PlanoContaId,
        DateTime Data,
        string Descricao
    );
}
