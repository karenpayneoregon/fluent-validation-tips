#nullable disable
namespace ConditionalRulesSample.Models;

public class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly RequiredDate { get; set; }

    public DateOnly ShippedDate { get; set; }

    public DateOnly DeliveredDate { get; set; }

    public bool CanDiscount { get; set; }
    public decimal Total { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}