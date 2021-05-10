using System.Collections.Generic;
using System.Net;
using ComicStoreContext.Domain.Commands;
using ComicStoreContext.Domain.Commands.Client;
using ComicStoreContext.Domain.Commands.Contracts;
using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Handlers.Contracts;
using ComicStoreContext.Domain.Repositories;
using ComicStoreContext.Domain.ValueObjects;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Handlers
{
    public class ClientHandler :
        Notifiable,
        IHandler<CreateClientCommand>,
        IHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _repository;

        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handler(CreateClientCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Missing or invalid data",
                 command.Notifications
             );

            var emailInUse = _repository.EmailAlreadyRegistered(command.Email);
            if (emailInUse) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Email Already Registered",
                 command.Email
             );
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.DocumentType, command.DocumentNumber);
            var password = command.Password;
            IList<dynamic> notifications = new List<dynamic>();
            notifications.Add(name.Notifications);
            notifications.Add(email.Notifications);
            notifications.Add(document.Notifications);

            if (name.Invalid || email.Invalid || document.Invalid)
                return new CommandResult(
                    HttpStatusCode.BadRequest,
                    false,
                    "Invalid data",
                    notifications
                );

            var client = new Client(name, email, document, password);

            _repository.Create(client);

            return new CommandResult(
                HttpStatusCode.Created,
                true,
                "User successfully created",
                client
            );
        }

        public ICommandResult Handler(UpdateClientCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Missing or invalid data",
                 command.Notifications
             );
            throw new System.NotImplementedException();
        }
    }
}