using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDBAPI.Models;
using MongoDBAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection _products;

        public ProductController(IProductCollection product)
        {
            _products = product;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _products.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(string id)
        {
            return await _products.GetProductById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Product product)
        {
            await _products.InsertProduct(product);
        }

        [HttpPut]
        public async Task Update([FromBody] Product product)
        {
            await _products.UpdateProduct(product);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _products.DeleteProduct(id);
        }
    }
}
