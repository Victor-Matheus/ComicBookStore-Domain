using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ComicStoreContext.Domain.Commands.Product
{
    public class DeleteProductCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "DeleteProductCommand", "Product ID cannot be empty or null")
            );
        }
    }
}