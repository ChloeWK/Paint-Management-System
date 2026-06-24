// See https://aka.ms/new-console-template for more information
using System;
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
        public static List<PaintProduct> allProducts = new List<PaintProduct>();
        public static List<Order> allOrders = new List<Order>();
        public static List<User> allUsers = new List<User>();



        static void Main()
        {
            CreateDefaultProducts();
            DisplayAllProducts();
            CreateSampleOrders();
            DisplayAllOrders();
                    
            Order expensive = Order.GetMostExpensivePaintProduct(allOrders);


            int inputOrderId;
            int inputProductId;
            bool isSuccess = false;
            bool isSuccessCheck = false;
            while (!isSuccess && !isSuccessCheck)
            {
                Console.WriteLine("Input the Order ID that you want to change:");
                string inputOrder = Console.ReadLine();
                isSuccessCheck = int.TryParse(inputOrder, out inputOrderId);


                Console.WriteLine("Input the product ID that you want to remove:");
                string inputProduct = Console.ReadLine();
                isSuccess = int.TryParse(inputProduct, out inputProductId);

                if (!isSuccess && !isSuccessCheck)
                {
                    Console.WriteLine("Wrong Input! Must be a number.");
                }
                Order removePaint = Order.RemovePaintProduct(inputOrderId,inputOrderId, allOrders);
            }
        }

        private static void CreateDefaultProducts()
        {
            allProducts.Add
            (
                new PaintProduct
                    (
                        1,
                        "p1",
                        (PaintTypes)1,
                        new PaintSpecification("red", 1),
                        100.00m
                    )
            );


            allProducts.Add(
                new PaintProduct
                (
                    2,
                    "p2",
                    (PaintTypes)2,
                    new PaintSpecification("white", 1),
                    150.00m
                )
            );


            allProducts.Add(
                new PaintProduct
                (
                    3,
                    "p3",
                    (PaintTypes)3,
                    new PaintSpecification("white", 1),
                    250.00m
                )
            );


            allProducts.Add(
                new PaintProduct
                (
                    4,
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
                new Order
                (
                    1,
                    new PaintProduct
                    (
                        1,
                        "p1",
                        (PaintTypes)1,
                        new PaintSpecification("red", 1),
                        100.00m
                    ),
                    4
                )
            );

            allOrders.Add
            (
                new Order
                (
                    2,
                    new PaintProduct
                    (
                        2,
                        "p2",
                        (PaintTypes)2,
                        new PaintSpecification("white", 1),
                        150.00m
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
            foreach (Order order in allOrders)
            {
                order.DisplayOrder();
                order.GetTotalPrice();
                Console.WriteLine(" ");
            }

        }



    }
}
