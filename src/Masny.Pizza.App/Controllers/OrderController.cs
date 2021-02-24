﻿using Masny.Pizza.Data.Contexts;
using Masny.Pizza.Data.Models;
using Masny.Pizza.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Masny.Pizza.App.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartService cartService;
        private readonly PizzaAppContext pizzaAppContext;

        public OrderController(ICartService cartService, PizzaAppContext pizzaAppContext)
        {
            this.cartService = cartService;
            this.pizzaAppContext = pizzaAppContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProducts = cartService.Get(userId);

            //var tp = 
            //var order = new Order
            //{
            //    Name = "Random",
            //    TotalPrice = 
            //}

            //pizzaAppContext.Orders.Add()

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SimpleTestClass simpleTestClass)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProducts = cartService.Get(userId);

            var order = new Order
            {
                UserId = userId,
                Name = "test",
                Phone = "take from db",
                Address = "take from db",
                TotalPrice = cartProducts.Products.Sum(p => p.Price)
            };

            pizzaAppContext.Orders.Add(order);
            pizzaAppContext.SaveChanges();

            foreach (var item in cartProducts.Products)
            {
                pizzaAppContext.OrderProducts.Add(new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = item.Id
                });
            }

            pizzaAppContext.SaveChanges();

            //var tp = 
            //var order = new Order
            //{
            //    Name = "Random",
            //    TotalPrice = 
            //}

            //pizzaAppContext.Orders.Add()

            cartService.Clear(userId);

            return Redirect("/Home/Index");
        }
    }

    public class SimpleTestClass
    {
        public int OrderType { get; set; }

        public string Address { get; set; }

        //public string Time { get; set; }

        public int PaymentType { get; set; }

        public string Comment { get; set; }
    }
}