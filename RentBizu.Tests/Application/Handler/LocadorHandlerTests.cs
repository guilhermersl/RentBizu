using FluentAssertions;
using LetsMusic.Application.LocadorContext.LocadorApp.Handler;
using Moq;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Command;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Query;
using RentBizu.Application.LocadorContext.LocadorApp.Service;

namespace LetsMusic.Tests.Application.LocadorContext.Handler
{
    public class LocadorHandlerTests
    {
        private Mock<ILocadorService> _serviceMock;
        private LocadorHandler _handler;

        public LocadorHandlerTests()
        {
            _serviceMock = new Mock<ILocadorService>();
            _handler = new LocadorHandler(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAllLocadorQuery_Handle_deve_retornar_conforme_esperado()
        {
            var albuns = new List<LocadorOutputDto>
            {
                LocadorMockHelper.MockLocadorOutputDto(),
                LocadorMockHelper.MockLocadorOutputDto(),
                LocadorMockHelper.MockLocadorOutputDto()
            };
            var expected = new GetAllLocadorQueryResponse(albuns);

            _serviceMock.Setup(mock => mock.GetAll()).ReturnsAsync(albuns);

            var actual = await _handler.Handle(new GetAllLocadorQuery(), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CreateLocadorCommand_Handle_deve_retornar_conforme_esperado()
        {
            var locador = LocadorMockHelper.MockLocadorOutputDto();

            var expected = new CreateLocadorCommandResponse(locador);

            var input = LocadorMockHelper.MockLocadorInputDto();
            _serviceMock.Setup(mock => mock.Create(input)).ReturnsAsync(locador);

            var actual = await _handler.Handle(new CreateLocadorCommand(input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetByIdLocadorQuery_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var locador = LocadorMockHelper.MockLocadorOutputDto();
            var expected = new GetLocadorQueryResponse(locador);

            _serviceMock.Setup(mock => mock.Get(id)).ReturnsAsync(locador);

            var actual = await _handler.Handle(new GetLocadorQuery(id), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task UpdateLocadorCommand_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var input = LocadorMockHelper.MockLocadorInputDto();

            var locador = LocadorMockHelper.MockLocadorOutputDto();
            var expected = new UpdateLocadorCommandResponse(locador);

            _serviceMock.Setup(mock => mock.Update(id, input)).ReturnsAsync(locador);

            var actual = await _handler.Handle(new UpdateLocadorCommand(id, input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        //[Fact]
        //public async Task DeleteLocadorCommand_Handle_deve_retornar_conforme_esperado()
        //{
        //    var id = Guid.NewGuid();
        //    var expected = true;

        //    _serviceMock.Setup(mock => mock.Delete(id)).ReturnsAsync(expected);

        //    var actual = await _handler.Handle(new DeleteLocadorCommand(id), new CancellationToken());

        //    actual.Should().Be(expected);
        //}
    }
}