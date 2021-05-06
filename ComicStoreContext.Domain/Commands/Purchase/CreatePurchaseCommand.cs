using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Commands.Purchase
{
    public class CreatePurchaseCommand : Notifiable
    {
        public Guid ClientId { get; set; }
        public List<Guid> ProductIds { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalPaid { get; set; }
    }
}