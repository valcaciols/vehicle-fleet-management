using MediatR;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.Queries;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;
using VehicleFleetManagement.Infrastructure.Denormalizeds;
using VehicleFleetManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<VehicleManagerContext>();

builder.Services.AddMediatR(typeof(CreateClientCommand));

builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
builder.Services.AddSingleton<IVehicleRepository, VehicleRepository>();
builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
builder.Services.AddSingleton<IVehicleModelRepository, VehicleModelRepository>();

builder.Services.AddSingleton<IDenormalizedClientRepository, DenormalizedClientRepository>();
builder.Services.AddSingleton<IDenormalizedBookingRepository, DenormalizedBookingRepository>();
builder.Services.AddSingleton<IDenormalizedVehicleRepository, DenormalizedVehicleRepository>();

builder.Services.AddScoped<IClientQueries, ClientQueries>();
builder.Services.AddScoped<IVehicleQueries, VehicleQueries>();
builder.Services.AddScoped<IBookingQueries, BookingQueries>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
