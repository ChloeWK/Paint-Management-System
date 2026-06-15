// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Security.Cryptography;
using Paint_Management_System.Models;
using Paint_Management_System.Enumerations;
using System.Net.Http.Headers;
using System.Reflection;
using System.ComponentModel;



namespace Paint_Management_System
{
    public class Program
    {
        private static List<PaintProduct> allProducts = new List<PaintProduct>();
        private static List<Orders> allOrders = new List<Orders>();

        static void Main()
        {
            CreateDefaultProducts();
            DisplayAllProducts();
            CreateSampleOrders();
            DisplayAllOrders();
        }

        private static void CreateDefaultProducts()
        {
            allProducts.Add
            (
                new PaintProduct
                    (
                        "p1",
                        (PaintTypes)1,
                        new PaintSpecification("red", 1),
                        100.00m
                    )
            );


            allProducts.Add(
                new PaintProduct
                (
                    "p2",
                    (PaintTypes)2,
                    new PaintSpecification("white", 1),
                    150.00m
                )
            );


            allProducts.Add(
                new PaintProduct
                (
                    "p3",
                    (PaintTypes)3,
                    new PaintSpecification("white", 1),
                    250.00m
                )
            );


            allProducts.Add(
                new PaintProduct
                (
                    "p4",
                    (PaintTypes)3,
                    new PaintSpecification("green", 1),
                    250.00m
                )
            );

        }

        private static void CreateSampleOrders()
        {
            allOrders.Add
            (
                new Orders
                (
                    new PaintProduct
                    (
                        "p4",
                        (PaintTypes)3,
                        new PaintSpecification("green", 1),
                        250.00m
                    ),
                    4
                )
            );
        }


        private static void DisplayAllProducts()
        {
            Console.WriteLine("--------Product List--------");
            foreach (PaintProduct product in allProducts)
            {
                product.DisplayInfo();
                Console.WriteLine(" ");
            }
        }


        private static void DisplayAllOrders()
        {
            Console.WriteLine("--------Order List--------");
            foreach (Orders order in allOrders)
            {
                order.DisplayOrder();
                order.GetTotalPrice();
                Console.WriteLine(" ");
            }

        }



    }
}
