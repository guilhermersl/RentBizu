using FluentAssertions;
using LetsMusic.Api.Controllers;
using LetsMusic.Tests.Application.LocadorContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Command;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Query;
using RentBizu.Data;

namespace RentBizu.Tests.Api
{
    public class LocadorControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private LocadorController _controller;

        public LocadorControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new LocadorController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ListarTodos_deve_retornar_conforme_esperado()
        {
            var expected = new List<LocadorOutputDto>
            {
                LocadorMockHelper.MockLocadorOutputDto(),
                LocadorMockHelper.MockLocadorOutputDto()
            };

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetAllLocadorQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllLocadorQueryResponse(expected));

            var result = await _controller.ListarTodos();

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_retornar_conforme_esperado()
        {
            var expected = LocadorMockHelper.MockLocadorOutputDto();
            var input = LocadorMockHelper.MockLocadorInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateLocadorCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateLocadorCommandResponse(expected));

            var result = await _controller.Criar(input);

            var actual = result as CreatedResult;

            actual.StatusCode.Should().Be(201);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = LocadorMockHelper.MockLocadorInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateLocadorCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateLocadorCommandResponse(LocadorMockHelper.MockLocadorOutputDto()));

            _ = await _controller.Criar(input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<CreateLocadorCommand>(command => command.Locador == input), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ListarPorId_deve_retornar_conforme_esperado()
        {
            var expected = LocadorMockHelper.MockLocadorOutputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetLocadorQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetLocadorQueryResponse(expected));

            var result = await _controller.ListarUm(id);

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().Be(expected);
        }

        [Fact]
        public async Task ListarPorId_deve_chamar_mediatr_conforme_esperado()
        {
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetLocadorQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetLocadorQueryResponse(LocadorMockHelper.MockLocadorOutputDto()));

            _ = await _controller.ListarUm(id);

            _mediatorMock.Verify(mock => mock.Send(It.Is<GetLocadorQuery>(command => command.Id == id), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Atualizar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = LocadorMockHelper.MockLocadorInputDto();
            var id = Guid.NewGuid();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<UpdateLocadorCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateLocadorCommandResponse(LocadorMockHelper.MockLocadorOutputDto()));

            _ = await _controller.Atualizar(id, input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<UpdateLocadorCommand>(command => command.Id == id && command.Locador == input), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}