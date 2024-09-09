using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataModels.Models
{
    public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public string ImageURL {  get; set; }

    }
}
