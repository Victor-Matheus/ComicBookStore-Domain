using System;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Client
    {
        public Client(Name name, Email email, Document document)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Document = document;
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
    }
}