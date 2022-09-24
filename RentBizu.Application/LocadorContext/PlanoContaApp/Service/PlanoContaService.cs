using AutoMapper;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.Application.LocadorContext.Service;
using RentBizu.Data;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;

namespace RentBizu.Application.AlbumContext.Service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAzureBlobStorage _storage;

        public PlanoContaService(IPlanoContaRepository planoContaRepository, IMapper mapper, IHttpClientFactory httpClientFactory, IAzureBlobStorage storage)
        {
            _planoContaRepository = planoContaRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _storage = storage;
        }

        public async Task<PlanoContaOutputDto> Create(Guid locadorId, PlanoContaInputDto dto)
        {
            var planoConta = _mapper.Map<PlanoConta>(dto);
            planoConta.LocadorId = locadorId;

            //Download de arquivo
            HttpClient client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync(planoConta.Imagem);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var fileName = $"{Guid.NewGuid()}.jpg";
                var pathStorage = await _storage.UploadFile(fileName, stream);
                planoConta.Imagem = pathStorage;
            }
            //

            await _planoContaRepository.Save(planoConta);

            return _mapper.Map<PlanoContaOutputDto>(planoConta);
        }

        public async Task<List<PlanoContaOutputDto>> GetAll()
        {
            var result = await _planoContaRepository.GetAll();

            return _mapper.Map<List<PlanoContaOutputDto>>(result);
        }

        public async Task<PlanoContaOutputDto> Get(Guid Id)
        {
            var result = await _planoContaRepository.Get(Id);

            return _mapper.Map<PlanoContaOutputDto>(result);
        }

        public async Task<PlanoContaOutputDto> Update(Guid locadorId, Guid id, PlanoContaInputDto dto)
        {
            var planoConta = _mapper.Map<PlanoConta>(dto);
            planoConta.LocadorId = locadorId;
            planoConta.Id = id;
            await _planoContaRepository.Update(id, planoConta);
            PlanoConta planoContaGet = await _planoContaRepository.Get(planoConta.Id);
            return _mapper.Map<PlanoContaOutputDto>(planoContaGet);
        }

        public async Task Delete(Guid Id)
        {
            PlanoConta planoConta = await _planoContaRepository.Get(Id);
            await _planoContaRepository.Delete(planoConta);
            return;
        }
    }
}