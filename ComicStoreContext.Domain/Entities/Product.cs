using System;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Product
    {
        public Product(string title, string description, Price price, int quantityInStock)
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            Title = title;
            Description = description;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Price Price { get; private set; }
        public int QuantityInStock { get; private set; }

        public void UpdateProduct(string title, string description, Price price, int quantityInStock)
        {
            Title = title;
            Description = description;
            Price = price;
            QuantityInStock = quantityInStock;
        }

    }
}