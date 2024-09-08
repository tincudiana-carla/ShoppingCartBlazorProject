using Shop.DataModels.CustomModels;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;

namespace Shop.Admin.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly HttpClient httpClient;
        public AdminPanelService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ResponseModel> AdminLogin(LoginModel loginModel)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:7116/api/Admin/AdminLogin", loginModel);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseModel>();
                return result;
            }
            else
            {
                return new ResponseModel
                {
                    Status = false,
                    Message = "Login failed or API error."
                };
            }
        }

        public async Task<CategoryModel> SaveCategory(CategoryModel newCategoryModel)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:7116/api/Admin/SaveCategory", newCategoryModel);

            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadFromJsonAsync<CategoryModel>();
                return category;
            }
            else
            {
                throw new Exception("Failed to save category. Status code: " + response.StatusCode);
            }
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await httpClient.GetFromJsonAsync<List<CategoryModel>>("https://localhost:7116/api/Admin/GetCategories");
        }

        public async Task<bool> UpdateCategory(CategoryModel categoryToEdit)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:7116/api/Admin/EditCategory", categoryToEdit);
            return response.IsSuccessStatusCode==true ? true : false;      
        }

        public async Task<bool> DeleteCategory(CategoryModel categoryToDelete)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:7116/api/Admin/DeleteCategory", categoryToDelete);
            return response.IsSuccessStatusCode == true ? true : false;
        }
    }
}

