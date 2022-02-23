using VehicleFleetManagement.Application.ViewModels.Vehicle;

namespace VehicleFleetManagement.Application.Queries
{
    public interface IVehicleQueries : IQueries
    {
        Task<List<VehicleViewModel>> GetAllAsync(string? licensePlate, string? model, string? manufacturer);
    }
}
