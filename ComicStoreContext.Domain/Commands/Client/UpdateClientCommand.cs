using ComicStoreContext.Domain.Commands.Contracts;
using Flunt.Notifications;

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

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}