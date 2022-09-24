using AutoMapper;
using FluentAssertions;
using LetsMusic.Tests.Application.LocadorContext;
using Moq;
using RentBizu.Application.AlbumContext.LocadorApp.Service;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Data;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;

namespace RentBizu.Tests.Application.LocadorContext.Service
{
    public class LocadorServiceTests
    {
        private Mock<ILocadorRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHttpClientFactory> _httpClientFactory;
        private Mock<IAzureBlobStorage> _storage;
        private LocadorService _service;

        public LocadorServiceTests()
        {
            _repositoryMock = new Mock<ILocadorRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new LocadorService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAll_deve_retornar_conforme_esperado()
        {
            var expected = new List<LocadorOutputDto>{
                LocadorMockHelper.MockLocadorOutputDto()
            };

            IList<PlanoConta> planosConta = new List<PlanoConta>();

            var locadores = new List<Locador>{
                new Locador(expected.ElementAt(0).Nome, expected.ElementAt(0).Cpf, expected.ElementAt(0).Email, expected.ElementAt(0).Telefone, planosConta)
            };

            _repositoryMock.Setup(mock => mock.GetAll()).ReturnsAsync(locadores);
            _mapperMock.Setup(mock => mock.Map<List<LocadorOutputDto>>(locadores)).Returns(expected);

            var actual = await _service.GetAll();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Create_deve_retornar_conforme_esperado()
        {
            var input = LocadorMockHelper.MockLocadorInputDto();
            var expected = LocadorMockHelper.MockLocadorOutputDto();
            IList<PlanoConta> planosConta = new List<PlanoConta>();
            var locador = new Locador(input.Nome, input.Cpf, input.Email, input.Telefone, planosConta);

            _mapperMock.Setup(mock => mock.Map<Locador>(input)).Returns(locador);
            _mapperMock.Setup(mock => mock.Map<LocadorOutputDto>(locador)).Returns(expected);

            var actual = await _service.Create(input);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public async Task Create_deve_chamar_repositorio_conforme_esperado()
        {
            var input = LocadorMockHelper.MockLocadorInputDto();
            var expected = LocadorMockHelper.MockLocadorOutputDto();
            IList<PlanoConta> planosConta = new List<PlanoConta>();
            var locador = new Locador(input.Nome, input.Cpf, input.Email, input.Telefone, planosConta)
            {
                Id = expected.Id
            };

            _mapperMock.Setup(mock => mock.Map<Locador>(input)).Returns(locador);
            _mapperMock.Setup(mock => mock.Map<LocadorOutputDto>(locador)).Returns(expected);

            _ = await _service.Create(input);

            _repositoryMock.Verify(mock => mock.Save(It.Is<Locador>(a => a.Id == locador.Id)), Times.Once);
        }

        //[Fact]
        //public async Task GetById_deve_gerar_IdNotFoundException_quando_id_invalido()
        //{
        //    _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Locador)null);

        //    Func<Task> act = () => _service.Get(Guid.NewGuid());
        //    await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Locador não localizado");
        //}

        //[Fact]
        //public async Task Update_deve_gerar_IdNotFoundException_quando_id_invalido()
        //{
        //    _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Locador)null);

        //    Func<Task> act = () => _service.Update(Guid.NewGuid(), LocadorMockHelper.MockLocadorInputDto());
        //    await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Locador não localizado");
        //}

        //[Fact]
        //public async Task Delete_deve_gerar_IdNotFoundException_quando_id_invalido()
        //{
        //    _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Locador)null);

        //    Func<Task> act = () => _service.Delete(Guid.NewGuid());
        //    await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Locador não localizado");
        //}
    }
}