using System;

namespace MVC_DBFirst_Demo.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CatId { get; set; }
        public DateTime Mfd { get; set; }
        public DateTime Expiry { get; set; }
    }
}