using ComicStoreContext.Domain.Commands.Contracts;
using ComicStoreContext.Domain.Commands.Purchase;
using ComicStoreContext.Domain.Handlers.Contracts;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Handlers
{
    public class PurchaseHandler :
        Notifiable,
        IHandler<CreatePurchaseCommand>
    {
        public ICommandResult Handler(CreatePurchaseCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}