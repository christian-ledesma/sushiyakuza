using System.Collections.Generic;
using System.Threading.Tasks;
using Yakuza.Services.ProductAPI.Models;

namespace Yakuza.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int productId);
    }
}
