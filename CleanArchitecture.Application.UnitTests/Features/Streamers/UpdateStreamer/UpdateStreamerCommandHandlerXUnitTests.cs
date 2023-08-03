using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraestructure;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infraestructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateStreammerCommandHandler>> _logger;

        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<UpdateStreammerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRespository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task UpdateStreamerCommand_UpdateStreamer_ReturnsUnit()
        {
            var streamerInput = new UpdateStreamerCommand
            {
                Id = 8001,
                Nombre = "VAxi stream Max",
                Url = "maximo.com"
            };

            var handler = new UpdateStreammerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
