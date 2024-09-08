using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly ShoppingCartDBContext _dbContext = null;
        public AdminService(ShoppingCartDBContext shoppingCartDBContext)
        {
            _dbContext = shoppingCartDBContext ?? throw new ArgumentNullException(nameof(shoppingCartDBContext));
        }
        public ResponseModel AdminLogin(LoginModel loginModel)
        {
           
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var data = _dbContext.AdminInfo.Where(X => X.Email == loginModel.EmailId).FirstOrDefault();
                if (data != null)
                {
                    if(data.Password == loginModel.Password)
                    {
                        responseModel.Status = true;
                        responseModel.Message = Convert.ToString(data.ID) + "|" + data.Name + "|" + data.Email;
                    }
                    else
                    {
                        responseModel.Status = false;
                        responseModel.Message = "Email not registered. Please check your Email Id!";
                    }
                    return responseModel;
                }
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.Status = false;
                responseModel.Message = "An Error has occured. Please try again!";
                return responseModel;
            }
        }

        public CategoryModel SaveCategory(CategoryModel newCategoryModel)
        {
            try
            {
                Category category = new Category();
                category.Name = newCategoryModel.Name;
                _dbContext.Add(category);
                _dbContext.SaveChanges();
                return newCategoryModel;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public List<CategoryModel> GetCategories()
        {
            var data = _dbContext.Category.ToList();
            List<CategoryModel> categoryList = new List<CategoryModel>();
            foreach(var category in data)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;
                categoryList.Add(categoryModel);
            }
            return categoryList;
        }

        public bool UpdateCategory(CategoryModel categoryModel)
        {
            bool flag = false;
            var category = _dbContext.Category.Where(x => x.Id == categoryModel.Id).FirstOrDefault();
            if (category != null)
            {
                category.Name = categoryModel.Name;
                _dbContext.Category.Update(category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public bool DeleteCategory(CategoryModel categoryModel)
        {
            bool flag = false;
            var category = _dbContext.Category.Where(x => x.Id == categoryModel.Id).FirstOrDefault();
            if (category != null)
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
    }
}
