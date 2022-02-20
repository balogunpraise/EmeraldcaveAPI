using Emeraldcave.Domain.Dtos;
using Emeraldcave.Domain.Entities;

namespace Emeraldcave.Api.Extensions
{
    public static class ProductDtoExtension
    {
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductBrandId = product.ProductBrandId,
                ProductTypeId = product.ProductTypeId
            };
        }
    }
}
