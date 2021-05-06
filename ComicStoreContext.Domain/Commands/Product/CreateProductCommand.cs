using ComicStoreContext.Domain.Commands.Contracts;

namespace ComicStoreContext.Domain.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}