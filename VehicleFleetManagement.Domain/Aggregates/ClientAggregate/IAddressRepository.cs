﻿using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public interface IAddressRepository: IRepository
    {
        Task<Address> UpdateAddressAsync(Address address);
        Task<Address> AddAsync(Address address);
    }
}