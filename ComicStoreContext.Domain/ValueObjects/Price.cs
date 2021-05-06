using ComicStoreContext.Domain.ValueObjects.Contracts;
using Flunt.Validations;

namespace ComicStoreContext.Domain.ValueObjects
{
    public class Price : ValueObject
    {
        public Price(decimal price)
        {
            this.price = price;
            Validate();
        }

        public decimal price { get; private set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterOrEqualsThan(0, price, "Price.price", "value must be greater than or equal to zero")
            );
        }
    }
}