using ComicStoreContext.Domain.Commands.Client;
using ComicStoreContext.Domain.Commands.Contracts;
using ComicStoreContext.Domain.Handlers.Contracts;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Handlers
{
    public class ClientHandler :
        Notifiable,
        IHandler<CreateClientCommand>,
        IHandler<UpdateClientCommand>
    {
        public ICommandResult Handler(CreateClientCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handler(UpdateClientCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}