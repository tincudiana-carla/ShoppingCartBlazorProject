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

        public List<ProductModel> GetProducts()
        {   
            List<Category> categoryData = _dbContext.Category.ToList();
            List<Product> productData = _dbContext.Product.ToList();
            List<ProductModel> productList = new List<ProductModel>();
            foreach (var product in productData)
            {
                ProductModel productModel = new ProductModel();
                productModel.Id = product.Id;
                productModel.Name = product.Name;
                productModel.Price = product.Price;
                productModel.Stock = product.Stock;
                productModel.ImageURL = product.ImageURL;
                productModel.CategoryId = product.CategoryId;
                productModel.CategoryName = categoryData.Where(x => x.Id == product.CategoryId).Select(x => x.Name).FirstOrDefault();
                productList.Add(productModel);  
            }
            return productList;
        }

        public bool DeleteProduct(int productId)
        {
            bool flag = false;
            var product = _dbContext.Product.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {

                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
                flag = true;
            }

            return flag;
        }


        public ProductModel SaveProduct(ProductModel newProduct)
        {
            try
            {
                Product product = new Product();
                product.Name = newProduct.Name;
                product.Price =(int)newProduct.Price;
                product.Stock = (int)newProduct.Stock;
                product.CategoryId =(int)newProduct.CategoryId;
                product.ImageURL = newProduct.ImageURL;
                _dbContext.Add(product);
                _dbContext.SaveChanges();
                return newProduct;
            }
            catch (Exception ex) { throw;  }
        }

        public int GetNewProductId()
        {
            try
            {
                int nextProductId = _dbContext.Product.ToList().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault(); return nextProductId;
            }
            catch(Exception ex) { throw; }
        }

        public List<StockModel> GetProductStock()
        {
            List<StockModel> productStock = new List<StockModel>();
            List<Category> categoryData = _dbContext.Category.ToList();
            List<Product> productData = _dbContext.Product.ToList();

            foreach(var product in productData)
            {
                StockModel stockModel = new StockModel();
                stockModel.Id = product.Id;
                stockModel.Name = product.Name;
                stockModel.Stock = product.Stock;
                stockModel.CategoryName = categoryData.Where(x => x.Id == product.CategoryId).Select(x => x.Name).FirstOrDefault();
                productStock.Add(stockModel);
            }
            return productStock;
        }

        public bool UpdateProductStock(StockModel stock)
        {
            bool flag = false;
            var product = _dbContext.Product.Where(x => x.Id == stock.Id).First();
            if (product!=null)
            {
                product.Stock = (int)(stock.Stock + stock.NewStock);
                _dbContext.Product.Update(product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

    }
}
