using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Api.Core.DomainModels;
using Shop.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void SaveCategory(CategoryModel model)
        {   
            var category = new Category();
            category.Title = model.Title;
            _context.Categories.Add(category);

            foreach (var param in model.Parameters)
            {
                var categoryParam = new Models.CategoryParam()
                {
                    CategoryId = category.Id,
                    Title = param.Title
                };
                _context.CategoryParams.Add(categoryParam);
            }
            _context.SaveChanges();
        }

        public List<CategoryModel> ToList()
        {
            return _context.Categories
                .Include(data => data.Params)
                .Select(data => new CategoryModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Parameters = data.Params.Select(datajoin => new CategoryParamModel() {
                        Id = datajoin.Id,
                        Title = datajoin.Title
                    }).ToList()
                }).ToList();
        }

        public void Delete(int categoryId) {
            var category = _context.Categories.SingleOrDefault(data => data.Id == categoryId);            
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<CategoryParam> Parameters(int categoryId)
        {
            return _context.CategoryParams.Select(data => new CategoryParam
            {
                Id = data.Id,
                Title = data.Title
            }).ToList();
        }
    }
}
