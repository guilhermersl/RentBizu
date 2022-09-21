using AutoMapper;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Application.LocadorContext.LocadorApp.Service;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;

namespace RentBizu.Application.AlbumContext.LocadorApp.Service
{
    public class LocadorService : ILocadorService
    {
        private readonly ILocadorRepository _locadorRepository;
        private readonly IMapper _mapper;

        public LocadorService(ILocadorRepository locadorRepository, IMapper mapper)
        {
            _locadorRepository = locadorRepository;
            _mapper = mapper;
        }

        public async Task<LocadorOutputDto> Create(LocadorInputDto dto)
        {
            var locador = _mapper.Map<Locador>(dto);

            await _locadorRepository.Save(locador);

            return _mapper.Map<LocadorOutputDto>(locador);
        }

        public async Task<List<LocadorOutputDto>> GetAll()
        {
            var result = await _locadorRepository.GetAll();

            return _mapper.Map<List<LocadorOutputDto>>(result);
        }

        public async Task<LocadorOutputDto> Get(Guid Id)
        {
            var result = await _locadorRepository.GetOneWithIncludes(Id);

            return _mapper.Map<LocadorOutputDto>(result);
        }

        public async Task<LocadorOutputDto> Update(Guid id, LocadorInputDto dto)
        {
            var locador = _mapper.Map<Locador>(dto);
            locador.Id = id;
            await _locadorRepository.Update(id, locador);
            Locador locadorGet = await _locadorRepository.Get(locador.Id);
            return _mapper.Map<LocadorOutputDto>(locadorGet);
        }

        public async Task Delete(Guid Id)
        {
            Locador locador = await _locadorRepository.Get(Id);
            await _locadorRepository.Delete(locador);
            return;
        }
    }
}