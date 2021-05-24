using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace Lab11._2.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string category { get; set; }
    }
}
