using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Enums;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Repositories
{
    public interface IClientRepository
    {
        EDbStatusReturn Create(Client client);
        EDbStatusReturn Update(string id, Client client);
        bool EmailAlreadyRegistered(string email);
        bool Delete(string id);
    }
}