using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCase.Patient.Command.CreateCommand
{
    public class CreateParentValidator: AbstractValidator<CreatePatientCommand>
    {
        public CreateParentValidator()
        {
            RuleFor(x => x.Names)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre es requerido");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El campo campo Apellido Paterno no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Paterno es requerido");

            RuleFor(x => x.MotherMaidenName)
                .NotNull().WithMessage("El campo Apellido Materno no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Materno es requerido");

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("El campo N° de Documento no puede ser nulo")
                .NotEmpty().WithMessage("El campo N° de Documento es requerido")
                .Must(BeNumeric!).WithMessage("El campo N° de Documento debe contener sólo números");

            RuleFor(x => x.Phone)
                .NotNull().WithMessage("El campo Teléfono no puede ser nulo")
                .NotEmpty().WithMessage("El campo Teléfono es requerido")
                .Must(BeNumeric!).WithMessage("El campo Teléfono debe contener sólo números");
        }

        private bool BeNumeric(string input)
        {
            return long.TryParse(input, out _);
        }
    }
}
