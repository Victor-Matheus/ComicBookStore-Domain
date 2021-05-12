using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Enums;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Repositories
{
    public interface IClientRepository
    {
        EDbStatusReturn Create(Client client);
        EDbStatusReturn Update(Client client);
        Client GetClientById(string clientId);
        bool EmailAlreadyRegistered(string email);
        bool Delete(string id);
    }
}