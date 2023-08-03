using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreammerCommandHandler : IRequestHandler<UpdateStreamerCommand, Unit>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreammerCommandHandler> _logger;

        public UpdateStreammerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStreammerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate is null)
            {
                _logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

            _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);
            await _unitOfWork.Complete();
            _logger.LogInformation($"La operación fue exitosa actualizando el streamer");

            return Unit.Value;
        }

      
    }
}
