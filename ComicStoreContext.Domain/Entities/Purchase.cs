using System;
using System.Collections.Generic;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Purchase
    {
        public Purchase(Client client, IList<Product> products, Price amount, Price totalPaid)
        {
            Id = Guid.NewGuid();
            Client = client;
            Products = products;
            Amount = amount;
            TotalPaid = totalPaid;
        }

        public Guid Id { get; set; }
        public Client Client { get; set; }
        public IList<Product> Products { get; set; }
        public Price Amount { get; set; }
        public Price TotalPaid { get; set; }
    }
}