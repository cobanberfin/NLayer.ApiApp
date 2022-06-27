using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entites;
using NLayer.Core.Services;
using System.Collections.Generic;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService )
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        //[HttpGet("GetProductsWithCategory")]
        //public async Task<IActionResult> GetProductsWithCategory()
        //{
        //    return( await _productService.GetProductsWithCategory)
        //}




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(productsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var prod = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productdto = _mapper.Map<ProductDto>(prod);
            return Ok(productdto);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)//baseden gelen createdate yok bu clasta 
        {
             await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));

            return NoContent(); //gerıye bsıey donmuyorsa
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove( int id)
        {
            var produc = await _service.GetByIdAsync(id);
            if(produc != null)
            {
                await _service.RemoveAsync(produc);
            }
          
            return NoContent();
           
        }

    }
}