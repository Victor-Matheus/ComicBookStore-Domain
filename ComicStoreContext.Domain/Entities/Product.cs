using System;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Product
    {
        public Product(string title, string description, Price price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }

    }
}