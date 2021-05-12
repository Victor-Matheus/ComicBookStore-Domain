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

            var repositoryResponse = _repository.Create(client);

            if (repositoryResponse == Enums.EDbStatusReturn.DB_SAVED_OK) return new CommandResult(
                 HttpStatusCode.Created,
                 true,
                 "User successfully created",
                 client
             );

            return new CommandResult(
                HttpStatusCode.InternalServerError,
                false,
                "There was a problem with the request",
                command.Notifications
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

            var _client = _repository.GetClientById(command.Id);

            if (_client == null) return new CommandResult(
                 HttpStatusCode.NotFound,
                 false,
                 "Client not found",
                 command.Notifications
             );

            var name = new Name(command.FirstName ?? _client.Name.FirstName, command.LastName ?? _client.Name.LastName);
            var email = new Email(command.Email ?? _client.Email.Address);
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

            _client.UpdateClient(name, email, document, password);
            var repositoryResponse = _repository.Update(_client);

            var returnObject = new {
                id = _client.Id,
                firstName = _client.Name.FirstName,
                lastName = _client.Name.LastName,
                Document = _client.Document,
                email = _client.Email.Address
            };

            if(repositoryResponse == Enums.EDbStatusReturn.DB_SAVED_OK) return new CommandResult(
                HttpStatusCode.OK,
                true,
                "Client updated successfully",
                returnObject
            );

            return new CommandResult(
                HttpStatusCode.InternalServerError,
                false,
                "There was a problem with the request",
                command.Notifications
            );
        }
    }
}