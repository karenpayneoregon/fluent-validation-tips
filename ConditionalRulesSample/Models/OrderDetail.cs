
#nullable disable

namespace ConditionalRulesSample.Models;

public class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public double Discount { get; set; }
    public List<Products> Products { get; set; }
}