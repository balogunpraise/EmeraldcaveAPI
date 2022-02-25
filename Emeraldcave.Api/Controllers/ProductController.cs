using Emeraldcave.Api.Extensions;
using Emeraldcave.Domain.Entities;
using Emeraldcave.Domain.Interfaces;
using Emeraldcave.Domain.Specification;
using Microsoft.AspNetCore.Mvc;
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
                return Ok(result.AsProductDto());
            return Ok("No item found");
        }

        [HttpGet("/products")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProductsAsync()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var result = await _product.ListAllAsync(spec);
            return Ok(result.Select(x => x.AsProductDto()));
        }


        [HttpGet("/product-brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandsAsync()
        {
            return Ok(await _brand.GetAllAsync());
        }

        [HttpGet("/product-types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypesAsync()
        {
            return Ok(await _type.GetAllAsync());
        }


    }
}
