using MediatR;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.Commands.Client;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;
using VehicleFleetManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateClientCommand));
builder.Services.AddMediatR(typeof(CreateBookingCommand));
builder.Services.AddMediatR(typeof(CreateVehicleCommand));
builder.Services.AddMediatR(typeof(UpdateClientAddressCommand));

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
