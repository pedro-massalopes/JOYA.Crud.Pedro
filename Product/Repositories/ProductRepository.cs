using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;
using Product.Repositories.Interfaces;

namespace Product.Repositories
{

    public class ProductRepository : IProductRepositorio

    {
        private readonly SistemaDbContext _dbContext;

        public ProductRepository(SistemaDbContext sistemadbContext)
        {
            _dbContext = sistemadbContext;
        }

        public async Task<ProductModel> BuscarPorId(int id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<ProductModel>> Listar()
        {
            return await _dbContext.Product.ToListAsync();
        }
        public Task<ProductModel> Adicionar(ProductModel product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();

            return product;
        }

        public async Task<ProductModel> Atualizar(ProductModel product, int id)
        {
            ProductModel productForId = await BuscarPorId(id);

            if (productForId == null)
            {
                throw new Exception($"Produto para o ID {id} não foi encontrado no banco de dados!");
            }
            productForId.Name = product.Name;
            productForId.Description = product.Description;

            _dbContext.Product.Update(productForId);
            _dbContext.SaveChanges();

            return productForId;
        }


        public async Task<bool> Deletar(int id)
        { 
        ProductModel productForId = await BuscarPorId(id);

            if (productForId == null)
            { 
                throw new Exception($"Produto para o ID { id } não foi encontrado no banco de dados!");
            }
            _dbContext.Product.Remove(productForId);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
