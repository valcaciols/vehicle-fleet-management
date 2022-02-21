
namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    
    public class CommandResponse<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public CommandResponse(string message)
        {
            Message = message;
            Status = false;
        }

        public CommandResponse(T data)
        {
            Data = data;
            Status = true;
        }

        public static async Task<CommandResponse<T>> Fail(string message)
        {
            return await Task.FromResult(new CommandResponse<T>(message));
        }

        public static async Task<CommandResponse<T>> Ok(T obj)
        {
            return await Task.FromResult(new CommandResponse<T>(obj));
        }
    }
}
