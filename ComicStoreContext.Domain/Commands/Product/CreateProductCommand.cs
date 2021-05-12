using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ComicStoreContext.Domain.Commands.Product
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterOrEqualsThan(0, QuantityInStock, "CreateProductCommand.QuantityInStock", "Quantity in stock must be greater than or equal to zero")
                    .IsGreaterThan(0, Title.Length, "CreateProductCommand.Title", "The product title must contain more than 3 characters")

            );
        }
    }
}