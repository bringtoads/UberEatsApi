using FluentValidation;

namespace UberEats.Application.Menu.Commands
{
    public class CreateMenuCommandvalidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandvalidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x=> x.Sections).NotEmpty();
        }
    }
}
