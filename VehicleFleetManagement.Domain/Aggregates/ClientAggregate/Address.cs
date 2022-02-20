﻿using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public class Address: Entity
    {
        public int ClientId { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public int Cep { get; private set; }

        public Address(string street, string city, int cep)
        {
            Street = street;
            City = city;
            Cep = cep;
        }

        public void Change(string street, string city, int cep)
        {
            Street = Street.Equals(street) ? Street : street;
            City = Street.Equals(city) ? City : city;
            Cep = Cep.Equals(cep) ? Cep : cep;
        }        
    }
}
