using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.CommandHandlers
{
    public abstract class CommandHandler<T>
    {
        public async Task<CommandResponse<T>> Fail(string message)
        {
            return await CommandResponse<T>.Fail(message); 
        }

        public async Task<CommandResponse<T>> Ok(T obj)
        {
            return await CommandResponse<T>.Ok(obj);
        }
    }
}
