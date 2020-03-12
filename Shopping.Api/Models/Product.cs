using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal Price { get; set; }

        public decimal OrgPrice { get; set; }

        public string Decoration { get; set; }

        public string Size { get; set; }

        public double ClickTimes { get; set; }

        public double SaleTimes { get; set; }

        public bool IsDel { get; set; }
    }
}
