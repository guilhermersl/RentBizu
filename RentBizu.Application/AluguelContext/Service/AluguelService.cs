using AutoMapper;
using RentBizu.Application.AluguelContext.Dto;
using RentBizu.Application.AluguelContext.Service;
using RentBizu.Domain.AluguelContext;
using RentBizu.Domain.AluguelContext.Repositories;

namespace RentBizu.Application.AlbumContext.Service
{
    public class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IMapper _mapper;

        public AluguelService(IAluguelRepository aluguelRepository, IMapper mapper)
        {
            _aluguelRepository = aluguelRepository;
            _mapper = mapper;
        }

        public async Task<AluguelOutputDto> Create(Guid locatarioId, Guid planoContaId, AluguelInputDto dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            aluguel.LocatarioId = locatarioId;
            await _aluguelRepository.Save(aluguel);

            return _mapper.Map<AluguelOutputDto>(aluguel);
        }

        public async Task<List<AluguelOutputDto>> GetAll()
        {
            var result = await _aluguelRepository.GetAll();

            return _mapper.Map<List<AluguelOutputDto>>(result);
        }

        public async Task<AluguelOutputDto> Get(Guid Id)
        {
            var result = await _aluguelRepository.Get(Id);

            return _mapper.Map<AluguelOutputDto>(result);
        }

        public async Task<AluguelOutputDto> Update(Guid locatarioId, Guid planoContaId, Guid id, AluguelInputDto dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            aluguel.LocatarioId = locatarioId;
            aluguel.PlanoContaId = planoContaId;
            aluguel.Id = id;
            await _aluguelRepository.Update(id, aluguel);
            Aluguel aluguelGet = await _aluguelRepository.Get(aluguel.Id);
            return _mapper.Map<AluguelOutputDto>(aluguelGet);
        }

        public async Task Delete(Guid Id)
        {
            Aluguel aluguel = await _aluguelRepository.Get(Id);
            await _aluguelRepository.Delete(aluguel);
            return;
        }
    }
}