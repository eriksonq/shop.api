using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Core.DomainModels;
using Shop.Api.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpPost("add")]
        public void Add([FromBody]ProductModel model)
        {
            _productRepository.Add(model);
        }

        [HttpDelete("delete")]
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
        [HttpPost("")]
        public List<ProductModel> GetProduct([FromBody]FilterModel filter) {
            return _productRepository.ToList(filter);
        }

    }
}
