using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Enums;

namespace ComicStoreContext.Domain.Repositories
{
    public interface IProductRepository
    {
        EDbStatusReturn Create(Product product);
        EDbStatusReturn Update(string id, Product product);
        bool ProductIsAvailable(Product product);
    }
}