using AutoMapper;
using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;
using RentBizu.Domain.LocatarioContext;
using RentBizu.Domain.LocatarioContext.Repositories;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Service
{
    public class LocatarioService : ILocatarioService
    {
        private readonly ILocatarioRepository _locatarioRepository;
        private readonly IMapper _mapper;

        public LocatarioService(ILocatarioRepository locatarioRepository, IMapper mapper)
        {
            _locatarioRepository = locatarioRepository;
            _mapper = mapper;
        }

        public async Task<LocatarioOutputDto> Create(LocatarioInputDto dto)
        {
            var locatario = _mapper.Map<Locatario>(dto);

            await _locatarioRepository.Save(locatario);

            return _mapper.Map<LocatarioOutputDto>(locatario);
        }

        public async Task<List<LocatarioOutputDto>> GetAll()
        {
            var result = await _locatarioRepository.GetAll();

            return _mapper.Map<List<LocatarioOutputDto>>(result);
        }

        public async Task<LocatarioOutputDto> Get(Guid Id)
        {
            var result = await _locatarioRepository.GetOneWithIncludes(Id);

            return _mapper.Map<LocatarioOutputDto>(result);
        }

        public async Task<LocatarioOutputDto> Update(Guid id, LocatarioInputDto dto)
        {
            var locatario = _mapper.Map<Locatario>(dto);
            locatario.Id = id;
            await _locatarioRepository.Update(id, locatario);
            Locatario locatarioGet = await _locatarioRepository.Get(locatario.Id);
            return _mapper.Map<LocatarioOutputDto>(locatarioGet);
        }

        public async Task Delete(Guid Id)
        {
            Locatario locatario = await _locatarioRepository.Get(Id);
            await _locatarioRepository.Delete(locatario);
            return;
        }
    }
}