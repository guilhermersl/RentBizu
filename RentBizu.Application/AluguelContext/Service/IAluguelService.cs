﻿using RentBizu.Application.AluguelContext.PlanoContaApp.Dto;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.AluguelContext.Service
{
    public interface IAluguelService
    {
        Task<AluguelOutputDto> Create(Guid locatarioId, Guid PlanoContaId, AluguelInputDto dto);
        Task<List<AluguelOutputDto>> GetAll();
        Task<AluguelOutputDto> Get(Guid Id);
        Task<AluguelOutputDto> Update(Guid locatarioId, Guid PlanoContaId, Guid id, AluguelInputDto dto);
        Task Delete(Guid Id);

    }
}