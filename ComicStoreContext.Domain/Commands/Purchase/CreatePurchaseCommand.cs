using System;
using System.Collections.Generic;
using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Commands.Purchase
{
    public class CreatePurchaseCommand : Notifiable, ICommand
    {
        public Guid ClientId { get; set; }
        public List<Guid> ProductIds { get; set; }
        public decimal Amount { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}