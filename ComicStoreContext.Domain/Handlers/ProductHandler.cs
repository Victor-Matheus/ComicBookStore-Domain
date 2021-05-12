using System.Net;
using ComicStoreContext.Domain.Commands;
using ComicStoreContext.Domain.Commands.Contracts;
using ComicStoreContext.Domain.Commands.Product;
using ComicStoreContext.Domain.Entities;
using ComicStoreContext.Domain.Handlers.Contracts;
using ComicStoreContext.Domain.Repositories;
using ComicStoreContext.Domain.ValueObjects;
using Flunt.Notifications;

namespace ComicStoreContext.Domain.Handlers
{
    public class ProductHandler :
        Notifiable,
        IHandler<CreateProductCommand>,
        IHandler<UpdateProductCommand>,
        IHandler<DeleteProductCommand>
    {

        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handler(CreateProductCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Missing or invalid data",
                 command.Notifications
             );

            var title = command.Title;
            var description = command.Description;
            var price = new Price(command.Price);
            var quantityInStock = command.QuantityInStock;

            var notifications = price.Notifications;
            if (price.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Invalid data",
                 notifications
             );

            var product = new Product(title, description, price, quantityInStock);

            var returnObject = new
            {
                id = product.Id,
                title = product.Title,
                description = product.Description,
                price = product.Price,
                quantityInStock = product.QuantityInStock
            };

            var repositoryResponse = _repository.Create(product);

            if (repositoryResponse == Enums.EDbStatusReturn.DB_SAVED_OK) return new CommandResult(
                 HttpStatusCode.Created,
                 true,
                 "Product successfully registered",
                 returnObject
             );

            return new CommandResult(
                HttpStatusCode.InternalServerError,
                false,
                "There was a problem with the request",
                command.Notifications
            );
        }

        public ICommandResult Handler(UpdateProductCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Missing or invalid data",
                 command.Notifications
             );

            var _product = _repository.GetProductById(command.Id);

            if (_product == null) return new CommandResult(
                 HttpStatusCode.NotFound,
                 false,
                 "Product not found.",
                 command.Notifications
                 );

            var title = command.Title ?? _product.Title;
            var description = command.Description ?? _product.Description;
            var price = new Price(command.Price);
            var quantityInStock = command.QuantityInStock;

            if (price.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Invalid data",
                 price.Notifications
             );

            _product.UpdateProduct(title, description, price, quantityInStock);
            var repositoryResponse = _repository.Update(_product);

            var returnObject = new
            {
                id = _product.Id,
                title = _product.Title,
                description = _product.Description,
                price = _product.Price.price,
                quantityInStock = _product.QuantityInStock
            };

            if (repositoryResponse == Enums.EDbStatusReturn.DB_SAVED_OK) return new CommandResult(
                 HttpStatusCode.OK,
                 true,
                 "Product updated successfully",
                 returnObject
             );

            return new CommandResult(
                HttpStatusCode.InternalServerError,
                false,
                "There was a problem with the request",
                command.Notifications
            );

        }

        public ICommandResult Handler(DeleteProductCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(
                 HttpStatusCode.BadRequest,
                 false,
                 "Missing or invalid data",
                 command.Notifications
             );

            var _product = _repository.GetProductById(command.Id);

            if (_product == null) return new CommandResult(
                 HttpStatusCode.NotFound,
                 false,
                 "Product not found.",
                 command.Notifications
                 );

            var deleted = _repository.Delete(_product.Id);

            var returnObject = new
            {
                id = _product.Id,
                title = _product.Title,
                description = _product.Description,
                price = _product.Price.price,
                quantityInStock = _product.QuantityInStock
            };

            if (deleted) return new CommandResult(
                HttpStatusCode.OK,
                true,
                "Product successfully deleted",
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