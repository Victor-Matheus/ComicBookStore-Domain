using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Enums;

namespace ComicStoreContext.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        EDbStatusReturn Create(Purchase purchase);
    }
}