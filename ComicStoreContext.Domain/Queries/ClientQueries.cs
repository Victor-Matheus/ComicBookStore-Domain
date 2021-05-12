using System;
using System.Linq.Expressions;
using ComicStoreContext.Domain.Entities;

namespace ComicStoreContext.Domain.Queries
{
    public static class ClientQueries
    {
        public static Expression<Func<Client, bool>> GetClientById(string clientId)
        {
            return x => x.Id == clientId;
        }

        public static Expression<Func<Client, bool>> GetClientByDocument(string clientDocument)
        {
            return x => x.Document.Number == clientDocument;
        }
    }
}