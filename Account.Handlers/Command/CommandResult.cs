using Newtonsoft.Json;
using System.Collections.Generic;

namespace Account.Handlers.Command
{
    public class CommandResult : ICommandResult
    {
        [JsonIgnore]
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        #region Default Results

        private static CommandResult InsufficientPrivilegesCommandResult = new CommandResult() { Success = false, Message = "Insufficient privileges" };

        public static CommandResult InsufficientPrivileges()
        {
            return InsufficientPrivilegesCommandResult;
        }

        public static CommandResult AnyHandlerFound<TCommand>()
        {
            return new CommandResult()
            {
                Success = false,
                Message = "Any handler found for " + typeof(TCommand).Name
            };
        }

        public static CommandResult InvalidRequest(IDictionary<string, string[]> modelStateErrors)
        {
            return new CommandResult()
            {
                Success = false,
                Message = "Invalid request",
                Data = modelStateErrors
            };
        }

        #endregion Default Results
    }
}