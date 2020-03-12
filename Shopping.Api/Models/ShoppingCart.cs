using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Propertys { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public bool IsDel { get; set; }
    }
}
