using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ComicStoreContext.Domain.Commands.Client
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Enums.EDocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterOrEqualsThan(Password.Length, 6, "CreateClientCommand.Password", "The password must contain at least 6 characters")
            );
        }
    }
}