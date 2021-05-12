using System.Collections.Generic;
using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Enums;

namespace ComicStoreContext.Domain.Repositories
{
    public interface IProductRepository
    {
        EDbStatusReturn Create(Product product);
        EDbStatusReturn Update(Product product);
        bool Delete(string productId);
        Product GetProductById(string productId);
        IEnumerable<Product> GetAllProducts();
        bool ProductIsAvailable(Product product);
    }
}