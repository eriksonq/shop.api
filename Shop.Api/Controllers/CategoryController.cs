using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Core.DomainModels;
using Shop.Api.Infrastructure.Models;
using Shop.Api.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private CategoryRepository _categoryRepository;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("add")]
        public void Add([FromBody]CategoryModel model)
        {
            _categoryRepository.SaveCategory(model);
        }

        [HttpGet("")]
        public List<CategoryModel> Get()
        {
            return _categoryRepository.ToList();
        }
        [HttpDelete("delete")]
        public void Delete(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
        }

        [HttpGet("get-params")]
        public List<CategoryParam> GetParams(int categoryId)
        {
            return _categoryRepository.Parameters(categoryId);
        }
    }
}
