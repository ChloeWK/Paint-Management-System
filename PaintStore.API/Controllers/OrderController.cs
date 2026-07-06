using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;

namespace PaintStore.API.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/Order")]
[ApiController]
public class OrderController: ControllerBase
{
    private List<Order> OrderData = new List<Order>();

    

    [HttpGet("GetPaginatedOrders")]
    public ActionResult GetPaginatedOrders([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        //assume some data from database
        List<PaintProduct> paints = new List<PaintProduct>();
        paints.Add(new PaintProduct(1, "P1", 100.00m));
        paints.Add(new PaintProduct(2, "P2", 50.00m));
        paints.Add(new PaintProduct(3, "P3", 150.00m));
        OrderData.Add(new Order(1, paints, 1));

        var orders = OrderData.OrderBy(p => p.OrderId).Skip((pageNumber - 1) * pageSize). Take(pageSize).ToList();
        return Ok(orders);
    }


    [HttpGet("GetOdersByPriceRange")]
    public ActionResult GetOrdersByPriceRange([FromQuery] decimal minPrice, decimal maxPrice)
    {
        //assume some data from database
        List<PaintProduct> paints = new List<PaintProduct>();
        paints.Add(new PaintProduct(1, "P1", 100.00m));
        paints.Add(new PaintProduct(2, "P2", 50.00m));
        paints.Add(new PaintProduct(3, "P3", 150.00m));
        OrderData.Add(new Order(1, paints, 1));

        List<Order> orders = OrderData.Where(o => o.TotalPrice > minPrice && o.TotalPrice < maxPrice).ToList();
        return Ok(orders);
    }



    [HttpGet("GetOrdersByPaintId/{paintId:int}")]
    public ActionResult GetOrdersByPaintId(int paintId)
    {
        //assume some data from database
        List<PaintProduct> paints = new List<PaintProduct>();
        paints.Add(new PaintProduct(1, "P1", 100.00m));
        paints.Add(new PaintProduct(2, "P2", 50.00m));
        paints.Add(new PaintProduct(3, "P3", 150.00m));
        OrderData.Add(new Order(1, paints, 1));

        List<Order> orders = OrderData.Where(o => o.PaintProducts.Any(p => p.PaintId == paintId)).ToList();
        return Ok(orders);
    }



    [HttpGet("GetOrdersByUserId/{userId:int}")]
    public ActionResult GetOrdersByUserId(int userId)
    {
        //assume some data from database
        List<PaintProduct> paints = new List<PaintProduct>();
        paints.Add(new PaintProduct(1, "P1", 100.00m));
        paints.Add(new PaintProduct(2, "P2", 50.00m));
        paints.Add(new PaintProduct(3, "P3", 150.00m));
        OrderData.Add(new Order(1, paints, 1));

        List<Order> orders = OrderData.Where(o => o.UserId == userId).ToList();
        return Ok(orders);
    }


    [HttpGet("GetLastMonthOrders")]
    public ActionResult GetLastMonthOrders(DateTime date)
    {
        date = DateTime.Now;
        var orders = OrderData.Where(o => o.CreatedDate.Day - date.Day >= -30).ToList();
        return Ok(orders);
    }


    [HttpGet("GetOrdersByDate")]
    public ActionResult GetOrdersByDate()
    {
        //assume some data from database
        List<PaintProduct> paints = new List<PaintProduct>();
        paints.Add(new PaintProduct(1, "P1", 100.00m));
        paints.Add(new PaintProduct(2, "P2", 50.00m));
        paints.Add(new PaintProduct(3, "P3", 150.00m));
        OrderData.Add(new Order(1, paints, 1));

        var orders = OrderData.OrderBy(o => o.CreatedDate).ToList();
        return Ok(orders);
    }
}
