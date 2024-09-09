using Shop.DataModels.CustomModels;

namespace Shop.Web.Services
{
    public class UserPanelService : IUserPanelService
	{
        private readonly HttpClient httpClient;
        public UserPanelService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

		public async Task<List<CategoryModel>> GetCategories()
		{
			return await httpClient.GetFromJsonAsync<List<CategoryModel>>("https://localhost:7116/api/User/GetCategories");
		}

        public async Task<List<ProductModel>> GetProductsByCategoryId(int categoryId)
        {
            return await httpClient.GetFromJsonAsync<List<ProductModel>>($"https://localhost:7116/api/User/GetProductsByCategoryId?ID={categoryId}");
        }

    }
}
