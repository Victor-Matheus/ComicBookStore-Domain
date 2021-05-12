using System;
using System.Linq.Expressions;
using ComicStoreContext.Domain.Entities;

namespace ComicStoreContext.Domain.Queries
{
    public static class PurchaseQueries
    {
        public static Expression<Func<Purchase, bool>> GetPurchaseById(string purchaseId)
        {
            return x => x.Id == purchaseId;
        }

        public static Expression<Func<Purchase, bool>> GetPurchaseByClientId(string clientId)
        {
            return x => x.Client.Id == clientId;
        }

        public static Expression<Func<Purchase, bool>> GetPurchaseByClientDocument(string clientDocument)
        {
            return x => x.Client.Document.Number == clientDocument;
        }
    }
}