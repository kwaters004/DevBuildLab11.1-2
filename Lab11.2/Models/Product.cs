using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Lab11._2.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int productId {get; set;}
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }

        public override string ToString()
        {
            return $"{productName} {productDescription} ${price}";
        }

    }
}
