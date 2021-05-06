using System;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Product
    {
        public Product(string title, string description, Price price)
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            Title = title;
            Description = description;
            Price = price;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Price Price { get; private set; }

    }
}