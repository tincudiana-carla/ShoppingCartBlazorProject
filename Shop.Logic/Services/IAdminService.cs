﻿using Shop.DataModels.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
    public interface IAdminService
    { 
        ResponseModel AdminLogin(LoginModel loginModel);
        CategoryModel SaveCategory(CategoryModel newCategoryModel);
        List<CategoryModel> GetCategories();
        bool UpdateCategory(CategoryModel categoryModel);
        bool DeleteCategory(CategoryModel categoryModel);
        List<ProductModel> GetProducts();
        bool DeleteProduct(int id);
        int GetNewProductId();
        ProductModel SaveProduct(ProductModel newProduct);
        List<StockModel> GetProductStock();
        bool UpdateProductStock(StockModel stock);


    }
}
