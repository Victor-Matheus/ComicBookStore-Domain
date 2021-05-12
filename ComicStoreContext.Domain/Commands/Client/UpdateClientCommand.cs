using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ComicStoreContext.Domain.Commands.Client
{
    public class UpdateClientCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
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
                    .IsNotNullOrEmpty(Id, "UpdateClientCommand", "Client ID cannot be empty or null")
                    .IsGreaterOrEqualsThan(Password.Length, 6, "UpdateClientCommand.Password", "The password must contain at least 6 characters")
            );
        }
    }
}