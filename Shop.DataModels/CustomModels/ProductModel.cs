using System.ComponentModel.DataAnnotations;

namespace Shop.DataModels.CustomModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The product's name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The product's price is required!")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "The product's stock is required!")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "The product's category is required!")]
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "The file is required!")]
        public string FileName { get; set; }

        public byte[] FileContent {  get; set; }
        public bool CartFlag { get; set; }
    }
}
