using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConditionalRulesSample.Handlers;
using ConditionalRulesSample.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConditionalRulesSample.Classes;
public class SqlStatements
{
    public static string OrderTotalWithoutDiscount => 
        """
        SELECT     SUM(OD.UnitPrice * OD.Quantity) AS TotalCost
         FROM      dbo.Orders AS O
        INNER JOIN dbo.OrderDetails AS OD
           ON O.OrderID = OD.OrderID
        WHERE      (O.OrderID = @OrderIdentifier);
        """;

    public static string OrderTotalWithDiscount =>
        """
        SELECT     ROUND(SUM(OD.UnitPrice * (1 - OD.Discount) * OD.Quantity), 2) AS TotalCost
         FROM      dbo.Orders AS O
        INNER JOIN dbo.OrderDetails AS OD
           ON O.OrderID = OD.OrderID
        WHERE      (O.OrderID = @OrderIdentifier);
        """;

    public static string OrderIsDiscountable =>
        """
        SELECT ProductID, Discount, SUM(UnitPrice * Quantity) total
         FROM dbo.OrderDetails
        WHERE OrderID = @OrderIdentifier AND Discount > 0
        GROUP BY ProductID, Discount;
        """;
    public static string Order =>
        """
        SELECT OrderID,
               OrderDate,
               RequiredDate,
               ShippedDate,
               DeliveredDate
         FROM dbo.Orders
        WHERE OrderID = @OrderIdentifier;
        """;
    public static string OrderDetails =>
        """
        SELECT     OD.OrderID,
                   OD.ProductID,
                   OD.UnitPrice,
                   OD.Quantity,
                   OD.Discount,
                   P.ProductName
         FROM      dbo.OrderDetails AS OD
        JOIN dbo.Products AS P
           ON OD.ProductID = P.ProductID
        WHERE      OD.OrderID = @OrderIdentifier;
        """;

    public static string GetProduct =>
        """
        SELECT ProductID
            ,ProductName
            ,SupplierID
            ,CategoryID
            ,QuantityPerUnit
            ,UnitPrice
            ,UnitsInStock
            ,UnitsOnOrder
            ,ReorderLevel
            ,Discontinued
            ,DiscontinuedDate
        FROM dbo.Products
        WHERE ProductID = @ProductId
        """;
}

public class DapperOperations
{
    public static decimal OrderTotal(int id)
    {
        using var connection = new SqlConnection(ConnectionString());
        connection.Open();
        return Math.Round(connection.Query<decimal>(SqlStatements.OrderTotalWithoutDiscount, new { OrderIdentifier = id }).FirstOrDefault(),2);
    }
    public static decimal OrderTotalWithDiscount(int id)
    {
        using var connection = new SqlConnection(ConnectionString());
        connection.Open();
        return Math.Round(connection.Query<decimal>(SqlStatements.OrderTotalWithDiscount, new { OrderIdentifier = id }).FirstOrDefault(),2);
    }
    public static bool OrderIsDiscountable(int id)
    {
        using var connection = new SqlConnection(ConnectionString());
        connection.Open();
        return connection.Query(SqlStatements.OrderIsDiscountable, new { OrderIdentifier = id }).Any();
    }
    public static List<OrderDetail> OrderDetails(int id)
    {
        using var connection = new SqlConnection(ConnectionString());
        connection.Open();
        return connection.Query<OrderDetail>(SqlStatements.OrderDetails, new { OrderIdentifier = id }).ToList();
    }
    public static List<OrderDetail> OrderDetailsWithProducts(int id)
    {
        using var connection = new SqlConnection(ConnectionString());
 
        var orderDetails = connection.Query<OrderDetail, Products, OrderDetail>(SqlStatements.OrderDetails,
            (od, prod) =>
            {
                od.Products = [prod];
                od.ProductId = prod.ProductID;
                return od;
            },
            new { OrderIdentifier = id },
            splitOn: "ProductId")
            .AsList();

        return orderDetails;
    }

    public static Order Order(int id)
    {
        SqlMapper.AddTypeHandler(new DapperSqlDateOnlyTypeHandler());
        using var connection = new SqlConnection(ConnectionString());

        var order = connection.Query<Order>(SqlStatements.Order, new { OrderIdentifier = id }).FirstOrDefault();
        order.Total = OrderTotalWithDiscount(id);
        order.CanDiscount = OrderIsDiscountable(id);
        order.OrderDetails = OrderDetails(id);

        foreach (var detail in order.OrderDetails)
        {
            detail.Products = connection.Query<Products>(SqlStatements.GetProduct, new { detail.ProductId }).ToList();
        }
        return order;
    }
}