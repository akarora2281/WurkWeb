namespace Wurk.Core.Services
{
    using Wurk.Core.Models.Events;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using static Wurk.Common.MessageConstants;
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;

    public class EventOrderService : IEventOrderService
    {
        private IAppRepository _bookingRepo;

        public EventOrderService(IAppRepository bookingRepo)
        {
            this._bookingRepo = bookingRepo;
        }

        public async Task CreateOrder(EventOrderViewModel model, bool approved)
        {
            model.BookingDate = DateTime.UtcNow;
            var user = await _bookingRepo.All<ArtGalleryUser>()
                                      .FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (user == null)
            {
                throw new ArgumentException(UnknowUser);
            }

            var booking = this._bookingRepo.All<EventOrderViewModel>()
                .Where(b => b.Confirmed == approved && b.UserId == model.UserId && b.BookingDate > DateTime.UtcNow)
                .OrderBy(b => b.BookingDate)
                .To<Event>()
                .ToList();

            await this._bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();
        }

        public async Task ConfirmAsync(int id) // Manager Functionality
        {
            var eventToConfirm = this._bookingRepo
               .All<EventOrder>()
               .Where(e => e.EventId == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = true;
            await this._bookingRepo.SaveChangesAsync();
        }

        public async Task DeclineAsync(int id) // Manager Functionality
        {
            var eventToConfirm = this._bookingRepo
               .All<EventOrder>()
               .Where(e => e.EventId == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = false;
            await this._bookingRepo.SaveChangesAsync();
        }
    }
}
