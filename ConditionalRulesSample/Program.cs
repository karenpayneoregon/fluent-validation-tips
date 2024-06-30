using ConditionalRulesSample.Classes;
using ConditionalRulesSample.Validators;

namespace ConditionalRulesSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        var odp = DapperOperations.OrderDetailsWithProducts(10250);
        var total = DapperOperations.OrderTotal(10250);
        var discount = DapperOperations.OrderTotalWithDiscount(10250);
        var isDiscountable = DapperOperations.OrderIsDiscountable(10250);
        var order = DapperOperations.Order(10250);
        OrderValidator validator = new();
        var validate = validator.Validate(order);
        

        Console.WriteLine(total);
        Console.WriteLine(discount);
        Console.WriteLine(isDiscountable);
        Console.ReadLine();
    }
}