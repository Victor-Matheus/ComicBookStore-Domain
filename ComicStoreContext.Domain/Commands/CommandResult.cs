using System.Net;
using ComicStoreContext.Domain.Commands.Contracts;

namespace ComicStoreContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {

        public CommandResult() { }
        public CommandResult(HttpStatusCode httpStatusCode,
                             bool success,
                             string message,
                             object data)
        {
            // Guarantee no entry bugs with System.Diagnostics.Debug.Assert();
            System.Diagnostics.Debug.Assert(System.Enum.IsDefined(typeof(HttpStatusCode), httpStatusCode));
            System.Diagnostics.Debug.Assert(success == true || success == false);
            System.Diagnostics.Debug.Assert(message.Length > 0);
            //

            HttpStatusCode = httpStatusCode;
            Success = success;
            Message = message;
            Data = data;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
