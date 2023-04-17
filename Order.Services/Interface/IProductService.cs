using Order.Model;
using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task Add(ProductDTO product);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ProductDTO product);
    }
}
