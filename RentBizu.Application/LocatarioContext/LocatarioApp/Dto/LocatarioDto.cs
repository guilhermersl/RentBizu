using RentBizu.Application.AluguelContext.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Dto
{
    public record LocatarioInputDto(
        string Nome,
        string Cpf,
        string Email,
        string Telefone
    );

    public record LocatarioOutputDto(
        Guid Id,
        string Nome,
        string Cpf,
        string Email,
        string Telefone,
        IList<AluguelOutputDto> Alugueis
    );
}
