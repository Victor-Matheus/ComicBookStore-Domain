using ComicStoreContext.Domain.ValueObjects.Contracts;
using Flunt.Validations;

namespace ComicStoreContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            Validate();
        }

        public string Address { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsEmail(Address, "Email.Address", "Invalid email")
            );
        }
    }
}