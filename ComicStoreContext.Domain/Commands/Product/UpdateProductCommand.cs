using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ComicStoreContext.Domain.Commands.Product
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id, "UpdateProductCommand", "Product ID cannot be empty or null")
                    .IsGreaterOrEqualsThan(0, QuantityInStock, "updateProductCommand", "Quantity in Stock must be greater than or equal to zero")
            );
        }
    }
}
