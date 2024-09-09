using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services
{
    //ToDo: Make a generic interface so it won't be repetitive code.
    public interface IAdminPanelService
    {
        Task<ResponseModel> AdminLogin(LoginModel loginModel);
        Task<CategoryModel> SaveCategory(CategoryModel newCategoryModel);
        Task<List<CategoryModel>> GetCategories();
        Task<bool> UpdateCategory(CategoryModel categoryToEdit);
        Task<bool> DeleteCategory(CategoryModel categoryToDelete);

        Task<List<ProductModel>> GetProducts();
        Task<bool> DeleteProduct(int id);
        Task<ProductModel> SaveProduct(ProductModel newProductModel);
        Task<List<StockModel>> GetProductStock();
        Task<bool> UpdateProductStock(StockModel stockModel);
    }
}
