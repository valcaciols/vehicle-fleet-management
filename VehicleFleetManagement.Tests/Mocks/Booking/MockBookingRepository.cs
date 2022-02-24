using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;

namespace VehicleFleetManagement.Tests.Mocks.Booking
{
    public class MockBookingRepository : IBookingRepository
    {
        public Task<Domain.Aggregates.BookingAggregate.Booking> AddAsync(Domain.Aggregates.BookingAggregate.Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistActiveByClientId(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Aggregates.BookingAggregate.Booking>> GetAllByClientIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Aggregates.BookingAggregate.Booking> GetAsync(int bookingId)
        {
            return await Task.FromResult(new Domain.Aggregates.BookingAggregate.Booking(0, 1, DateTime.Now, DateTime.Now));
        }

        public Task UpdateDateReturnAsync(int bookingId, DateTime dateReturn)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDateWithdrawnAsync(int bookingId, DateTime dateWithdrawn)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpectedDateAsync(int bookingId, DateTime? dateExpectedWithdrawn, DateTime? dateExpectedReturn)
        {
            throw new NotImplementedException();
        }
    }
}
