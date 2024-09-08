using System.ComponentModel.DataAnnotations;


namespace Shop.DataModels.CustomModels
{
    public class CategoryModel
    {
        public int Id {  get; set; }
        [Required(ErrorMessage ="The name is required!")]
        public string Name { get; set; }
    }
}
