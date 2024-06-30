#nullable disable
using ConditionalRulesSample.Classes;
using ConditionalRulesSample.Models;
using FluentValidation;
using FluentValidation.Results;

namespace ConditionalRulesSample.Validators;

/// <summary>
/// https://docs.fluentvalidation.net/en/latest/conditions.html
/// </summary>
public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {

        //When(customer => customer.CanDiscount, () =>
        //{
            
        //    RuleFor(order => order.Total).Equals(DapperOperations.OrderTotalWithDiscount(customer))
        //});
        RuleFor(order => order.CanDiscount).Equals(true);
    }
    public override ValidationResult Validate(ValidationContext<Order> context)
    {
        var validationResult = base.Validate(context);

        //var orderId = context.RootContextData["ParentId"];

        //foreach (var error in validationResult.Errors)
        //{
        //    error.ErrorMessage = $"{error.ErrorMessage} (OrderId {orderId})";
        //}
        var test = context.InstanceToValidate;
        return validationResult;
    }
}