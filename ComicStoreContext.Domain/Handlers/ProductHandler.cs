using ComicStoreContext.Domain.Commands.Contracts;
using ComicStoreContext.Domain.Commands.Product;
using ComicStoreContext.Domain.Handlers.Contracts;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Handlers
{
    public class ProductHandler :
        Notifiable,
        IHandler<CreateProductCommand>,
        IHandler<UpdateProductCommand>
    {
        public ICommandResult Handler(CreateProductCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handler(UpdateProductCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}