using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services
{
    public interface IAdminPanelService
    {
        Task<ResponseModel> AdminLogin(LoginModel loginModel);
        Task<CategoryModel> SaveCategory(CategoryModel newCategoryModel);
        Task<List<CategoryModel>> GetCategories();
        Task<bool> UpdateCategory(CategoryModel categoryToEdit);
        Task<bool> DeleteCategory(CategoryModel categoryToDelete);
    }
}
