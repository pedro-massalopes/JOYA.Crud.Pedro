using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Repositories;
using Product.Repositories.Interfaces;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositorio productRepository;

        public ProductController(IProductRepositorio productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Listar()
        {
            List<ProductModel> products = await _productRepository.Listar();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> BuscarPorId(int id)
        {
            ProductModel product = await _productRepository.BuscarPorId(id);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> Atualizar ([FromBody] ProductModel productModel, int id)
        {
            productModel.ID = id;
            ProductModel product = await _productRepository.Atualizar(productModel, id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> Adicionar( [FromBody] ProductModel productModel)
        {
            ProductModel product = await _productRepository.Adicionar(productModel);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> Deletar(int id)
        {
            bool deletado = await _productRepository.Deletar(id);
            return Ok(deletado);
        }

    }
}
