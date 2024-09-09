using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Logic.Services;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var data = userService.GetCategories();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProductsByCategoryId")]
        public IActionResult GetProductsByCategoryId(int ID)
        {
            var data = userService.GetProductsByCategoryId(ID);
            return Ok(data);
        }

    }
}
