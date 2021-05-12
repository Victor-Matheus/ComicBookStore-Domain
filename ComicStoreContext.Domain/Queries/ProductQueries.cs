using System;
using System.Linq.Expressions;
using ComicStoreContext.Domain.Entities;

namespace ComicStoreContext.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetProductById(string productId)
        {
            return x => x.Id.Equals(productId);
        }

        public static Expression<Func<Product, bool>> GetAllProductsFromOnePrice(decimal productPrice)
        {
            return x => productPrice < x.Price.price;
        }
    }
}