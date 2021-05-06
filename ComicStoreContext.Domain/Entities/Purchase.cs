using System;
using System.Collections.Generic;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Purchase
    {
        public Purchase(Client client, IList<Product> products, Price amount, Price totalPaid)
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            Client = client;
            Products = products;
            Amount = amount;
        }

        public string Id { get; private set; }
        public Client Client { get; private set; }
        public IList<Product> Products { get; private set; }
        public Price Amount { get; private set; }
    }
}