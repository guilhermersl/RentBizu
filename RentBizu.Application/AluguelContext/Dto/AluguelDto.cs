﻿using RentBizu.CrossCutting.Enum;

namespace RentBizu.Application.AluguelContext.PlanoContaApp.Dto
{
    public record AluguelInputDto(
    );

    public record AluguelOutputDto(
        Guid Id,      
        Guid LocatarioId,
        Guid PlanoContaId,
        DateTime Data
    );
}