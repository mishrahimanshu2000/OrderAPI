using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.DTOs;
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
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> products = await _unitOfWork.Products.GetAllAsync();
            var productsDTO = _mapper.Map<IList<ProductDTO>>(products);
            return productsDTO;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.ProductId == id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Product product = await _unitOfWork.Products.GetAsync(p => p.ProductId == id);
            if (product == null)
            {
                return false;
            }
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, ProductDTO productDTO)
        {
            if(id != productDTO.ProductId)
            {
                return false;
            }
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
