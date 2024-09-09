
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;

namespace Shop.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly ShoppingCartDBContext _dbContext = null;
        public UserService(ShoppingCartDBContext shoppingCartDBContext)
        {
            _dbContext = shoppingCartDBContext ?? throw new ArgumentNullException(nameof(shoppingCartDBContext));
        }
        public List<CategoryModel> GetCategories()
        {
            var data = _dbContext.Category.ToList();
            List<CategoryModel> categoryList = new List<CategoryModel>();
            foreach (var category in data)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;
                categoryList.Add(categoryModel);
            }
            return categoryList;
        }

        public List<ProductModel> GetProductsByCategoryId(int categoryId)
        {
            var data = _dbContext.Product.Where(x => x.CategoryId == categoryId).ToList();

            List<ProductModel> productList = new List<ProductModel>();

            foreach (var product in data)
            {
                ProductModel productModel = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageURL = product.ImageURL,
                    Stock = product.Stock
                };
                productList.Add(productModel);
            }

            return productList;
        }


    }
}
