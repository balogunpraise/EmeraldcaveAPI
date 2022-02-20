using Emeraldcave.Domain.Entities;
using Emeraldcave.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emeraldcave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository<Product> _product;
        private readonly IProductRepository<ProductBrand> _brand;
        private readonly IProductRepository<ProductType> _type;

        public ProductController(IProductRepository<Product> product, IProductRepository<ProductBrand> brand,
            IProductRepository<ProductType> type)
        {
            _product = product;
            _brand = brand;
            _type = type;
        }


        [HttpGet("/product/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result = await _product.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return Ok("No item found");
        }

        [HttpGet("/products")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProductsAsync()
        {
            var result = await _product.GetAllAsync();
            return Ok(result);
        }
    }
}
