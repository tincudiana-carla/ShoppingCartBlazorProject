using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.Logic.Services;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAdminService adminService;

        public AdminController(IWebHostEnvironment webHostEnvironment, IAdminService adminService)
        {
            this._webHostEnvironment = webHostEnvironment;
            this.adminService = adminService;
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(LoginModel loginModel)
        {
            var data = adminService.AdminLogin(loginModel);
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveCategory")]
        public IActionResult SaveCategory(CategoryModel categoryModel)
        {
            var data = adminService.SaveCategory(categoryModel);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var data = adminService.GetCategories();
            return Ok(data);
        }

        [HttpPost]
        [Route("EditCategory")]
        public IActionResult EditCategory(CategoryModel categoryModel)
        {
            var data = adminService.UpdateCategory(categoryModel);
            return Ok(data);
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(CategoryModel categoryModel)
        {
            var data = adminService.DeleteCategory(categoryModel);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProdcuts()
        {
            var data = adminService.GetProducts();
            return Ok(data);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = adminService.DeleteProduct(id);
            if (result)
                return Ok(true);
            return BadRequest(false);
        }


        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProduct(ProductModel productModel)
        {
            int nextProductId = adminService.GetNewProductId();
            productModel.ImageURL = @"Image/" + nextProductId + ".png";
            var path = $"{_webHostEnvironment.WebRootPath}\\Images\\{nextProductId + ".png"}";
            var file = System.IO.File.Create(path);
            file.Write(productModel.FileContent,0,productModel.FileContent.Length);
            file.Close();
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            var data = adminService.SaveProduct(productModel);
            return Ok(data);
        }


    }
}
