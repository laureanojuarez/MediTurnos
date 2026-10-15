using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
        List<Product>GetProducts();
        
        Product? GetById(int id);
}