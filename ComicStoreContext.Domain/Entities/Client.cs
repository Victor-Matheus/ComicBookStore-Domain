using System;
using ComicStoreContext.Domain.ValueObjects;

namespace ComicStoreContext.Domain.Entities
{
    public class Client
    {
        public Client(Name name, Email email, Document document, string password)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "");
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }

        public string Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public string Password { get; private set; }

        public void UpdateClient(Name name, Email email, Document document, string password)
        {
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }
    }
}