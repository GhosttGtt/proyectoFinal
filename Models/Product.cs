﻿namespace POS.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}