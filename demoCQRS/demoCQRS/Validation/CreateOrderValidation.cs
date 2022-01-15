using demoCQRS.Command;
using FluentValidation;

namespace demoCQRS.Validation;

public class CreateOrderValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidation()
    {
        RuleFor(x => x.OrderRequest.NameCustomer).NotEmpty().WithMessage("Name customer not empty");
        RuleFor(x => x.OrderRequest.NameProduct).NotEmpty().WithMessage("Name product not empty");
    }
}