namespace Censo.Application.Validators
{

    public class PessoaValidator
    { }

    //public class PessoaValidator : AbstractValidator<Pessoa>
    //{
    //    public PessoaValidator()
    //    {
    //        RuleFor(c => c)
    //            .NotNull()
    //            .OnAnyFailure(x =>
    //            {
    //                throw new ArgumentNullException("Can't found the object.");
    //            });

    //        RuleFor(c => c.Nome)
    //            .NotEmpty().WithMessage("Is necessary to inform the Name.")
    //            .NotNull().WithMessage("Is necessary to inform the Nmae.");

    //        RuleFor(c => c.BirthDate)
    //            .NotEmpty().WithMessage("Is necessary to inform the birth date.")
    //            .NotNull().WithMessage("Is necessary to inform the birth date.");

    //        RuleFor(c => c.SobreNome)
    //            .NotEmpty().WithMessage("Is necessary to inform the SobreNome.")
    //            .NotNull().WithMessage("Is necessary to inform the SobreNome.");
    //    }
    //}
}
