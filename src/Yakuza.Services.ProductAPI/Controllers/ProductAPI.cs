using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yakuza.Services.ProductAPI.Models;
using Yakuza.Services.ProductAPI.Models.DTOs;
using Yakuza.Services.ProductAPI.Repository;

namespace Yakuza.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPI : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPI(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                _response.Result = products;
            }
            catch(Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                _response.Result = product;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<object> Create([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<object> Update([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.UpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var model = await _productRepository.DeleteProduct(id);
                _response.Result = model;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
    }
}
