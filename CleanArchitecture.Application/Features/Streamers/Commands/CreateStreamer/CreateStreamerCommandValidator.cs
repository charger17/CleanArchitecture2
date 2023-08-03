using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre).NotEmpty()
                .WithMessage("{Nombre} No puede estar en blanco").
                NotNull()
                .MaximumLength(50).WithMessage("{Nombre} No puede exceder de los 50 caracteres");
            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("La {Url} no puede estar en blanco");

        }
    }
}
