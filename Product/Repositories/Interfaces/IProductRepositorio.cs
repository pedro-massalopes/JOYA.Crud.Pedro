using Product.Models;

namespace Product.Repositories.Interfaces
{
    public interface IProductRepositorio
    {
               
        Task<ProductModel> BuscarPorId(int id);
        Task<ProductModel> Adicionar(ProductModel product);
        Task<ProductModel> Atualizar(ProductModel product, int id);
        Task<ProductModel> Listar(ProductModel product, int id);
        Task<bool> Deletar(int id);
        
        
 
    }
}
