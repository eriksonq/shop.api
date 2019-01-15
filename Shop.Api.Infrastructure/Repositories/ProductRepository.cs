using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Core.DomainModels;
using Shop.Api.Infrastructure.Models;

namespace Shop.Api.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(ProductModel model)
        {
            var product = new Product
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                Title = model.Title,
                Price = model.Price
            };
            _context.Products.Add(product); 
            foreach(var param in model.Parameters)
            {
                var productParam = new Models.ProductParam()
                {
                    CategoryParamId = param.CategoryParamId,
                    ProductId = product.Id,
                    Value = param.Value
                };
                _context.ProductParams.Add(productParam);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(data => data.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<ProductModel> ToList(FilterModel filter) {
            
                return _context.Products
                .Include(data => data.Category)
                .Include(data => data.Params).ThenInclude(datajoin => datajoin.CategoryParam)
                .Where(data => (data.CategoryId == filter.CategoryId | filter.CategoryId == null) 
                & (data.Params.Any(data2 => filter.Params.Any(data3 => data3.Id == data2.CategoryParamId && data3.Value == data2.Value)) 
                | filter.Params.Count(par=>string.IsNullOrWhiteSpace(par.Value))== filter.Params.Count() | filter.Params == null | filter.Params.Count == 0))
                .Select(data => new ProductModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Price = data.Price,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                    CategoryName = data.Category.Title
                }).ToList();
            return null;

        }
    }
}
