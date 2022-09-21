using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.CrossCutting.Enum;

namespace RentBizu.Application.LocadorContext.LocadorApp.Dto
{
    public record LocadorInputDto(
        string Nome,
        string Cpf,
        string Email,
        string Telefone
    );

    public record LocadorOutputDto(
        Guid Id,
        string Nome,
        string Cpf,
        string Email,
        string Telefone,
        List<PlanoContaOutputDto> PlanoContas
    );
}
