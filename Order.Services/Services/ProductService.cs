using Microsoft.EntityFrameworkCore;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.ProductId == id);

            return product;
        }

        public async Task Add(Product product)
        {
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Product product = await GetProductById(id);
            if (product == null)
            {
                return false;
            }
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, Product product)
        {
            if(id != product.ProductId)
            {
                return false;
            }
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
