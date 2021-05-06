using ComicStoreContext.Domain.Commands.Contracts;

namespace ComicStoreContext.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}