namespace Wurk.Core.Services
{
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.Events;
    using Wurk.Core.Models.Home;
    using Wurk.Infrastructure.Data;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Wurk.Common.GlobalConstants.Formating;

    public class EventService : IEventService
    {
        private readonly IAppRepository _eventRepo;
        private readonly ApplicationDbContext _applicationDbContext;
        public EventService(IAppRepository eventRepo, ApplicationDbContext applicationDbContext)
        {
            this._eventRepo = eventRepo;
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<bool> CreateEventAsync(string name, decimal price, string date,
            string type, string ticketSelection, string description)
        {
            bool isCreated = false;
            var createEvent = new EventCreateInputViewModel();

            if (createEvent != null)
            {
                createEvent.Name = name;
                createEvent.Price = price;
                createEvent.Date = date;
                createEvent.Type = Enum.Parse<EventType>(type);
                createEvent.TicketSelection = Enum.Parse<TicketType>(ticketSelection);
                createEvent.Description = description;

                //this._eventRepo.AddAsync(createEvent);
                //await this._eventRepo.SaveChangesAsync();

                _applicationDbContext.Events.Add(new Event()
                {
                    Name = name,
                    Price = price,
                    Date = Convert.ToDateTime(date),
                    Type = Enum.Parse<EventType>(type),
                    TicketSelection = Enum.Parse<TicketType>(ticketSelection),
                    Description = description,
                    CreatedOn = DateTime.UtcNow,

                });

                _applicationDbContext.SaveChanges();

            }

            return isCreated;
        }

        public async Task<bool> UpdateEventAsync(EventEditViewModel model)
        {
            bool isUpdated = false;
            //var updateEvent = this._eventRepo.All<Event>()
            //                       .FirstOrDefault(e => e.Id == model.EventId);
            var updateEvent = _applicationDbContext.Events
                             .FirstOrDefault(e => e.Id == model.EventId);

            if (updateEvent != null)
            {
                updateEvent.Name = model.Name;
                updateEvent.Price = model.Price;
                //updateEvent.Date = DateTime.ParseExact(Convert.ToString(model.Date),
                //                            NormalDateFormat, CultureInfo.InvariantCulture);
                updateEvent.Date = DateTime.Parse(model.Date);
                updateEvent.Type = model.Type;
                updateEvent.TicketSelection = model.TicketSelection;
                updateEvent.Description = model.Description;

                //this._eventRepo.Update(updateEvent);
                //await this._eventRepo.SaveChangesAsync();
                _applicationDbContext.Events.Update(updateEvent);
                _applicationDbContext.SaveChanges();
                isUpdated = true;
            }

            return isUpdated;
        }

        public void Delete(int id)
        {
            //var eventToDelete = this._eventRepo
            //             .All<Event>()
            //             .Where(e => e.Id == id)
            //             .FirstOrDefault();

            var eventToDelete = _applicationDbContext.Events
                        .FirstOrDefault(e => e.Id == id);

            //this._eventRepo.Delete(eventToDelete);
            //this._eventRepo.SaveChangesAsync();
            _applicationDbContext.Events.Remove(eventToDelete);
            _applicationDbContext.SaveChanges();
        }

        public int AllEventsCount()
        {
            //return this._eventRepo
            //       .All<Event>()
            //       .Count();

            return _applicationDbContext.Events
                  .Count();
        }

        public IEnumerable<EventViewModel> GetAllEvents(int eventId)
        {
            //return this._eventRepo
            //    .All<Event>()
            //    .To<EventViewModel>()
            //    .OrderByDescending(p => p.EventId == eventId)
            //    .ToList();

            // Code changes by bhavin.   
            return _applicationDbContext.Events.Select(x => new EventViewModel
            {
                EventId = x.Id,
                Name = x.Name,
                Date = x.Date,
                Price = x.Price,
                Description = x.Description,
                TicketSelection = x.TicketSelection,
                Type = x.Type
            })
            .OrderByDescending(p => p.EventId == eventId)
            .ToList();
        }

        public async Task AddAsync(EventCreateInputViewModel model)
        {
            //await this._eventRepo.AddAsync(new EventViewModel
            //{
            //    Name = model.Name,
            //    Price = model.Price,
            //    Date = DateTime.ParseExact(model.Date,
            //           DateTimeFormat, CultureInfo.InvariantCulture),
            //    Description = model.Description,
            //});

            await _applicationDbContext.Events.AddAsync(new Event
            {
                Name = model.Name,
                Price = model.Price,
                Date = DateTime.ParseExact(model.Date,
                      DateTimeFormat, CultureInfo.InvariantCulture),
                Description = model.Description,
            });

            // await this._eventRepo.SaveChangesAsync();
            await _applicationDbContext.SaveChangesAsync();
        }

        public IEnumerable<int> GetByIdAsync(int eventId)
        {
            //var events = this._eventRepo
            //        .All<EventViewModel>()
            //        .Where(x => x.EventId == eventId)
            //        .FirstOrDefault();

            var events = _applicationDbContext.Events
                   .FirstOrDefault(x => x.Id == eventId);

            return (IEnumerable<int>)events;
        }

        public async Task<IEnumerable<UpcomingEventViewModel>> GetUpcomingByIdAsync<T>(int eventId)
        {
            // Code changes by behaviour.   
            //return await this._eventRepo.All<Event>()
            //                     .Where(x => x.Id == eventId &&
            //                        x.Date.Date > DateTime.UtcNow.Date)
            //                     .OrderBy(x => x.Date)
            //                     .To<T>()
            //                     .Take(3)
            //                     .ToListAsync();

            return await _applicationDbContext.Events
                // .Where(x => x.Id == eventId && x.Date.Date > DateTime.UtcNow.Date)
                .Where(x => x.Date.Date > DateTime.UtcNow.Date)
                .Select(x => new UpcomingEventViewModel
                {
                    Date = x.Date.ToString(),
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type,
                })
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToListAsync();

        }

        public async Task<EventViewModel> GetEventDetailsByIdAsync<T>(int eventId)
        {
            //var eventDetails = this._eventRepo
            //                .All<EventViewModel>()
            //                .Where(e => e.EventId == eventId)
            //                .To<T>()
            //                .FirstOrDefault();

            var eventDetails = _applicationDbContext.Events
                            .Where(x => x.Id == eventId)
                            .Select(x => new EventViewModel()
                            {
                                EventId = eventId,
                                Name = x.Name,
                                Date = x.Date,
                                Price = x.Price,
                                Description = x.Description,
                                TicketSelection = x.TicketSelection,
                                Type = x.Type
                            })
                            .FirstOrDefault();


            return eventDetails;
        }

        public async Task<bool> CheckIfEventExists(int eventId)
        {
            //var even = await this._eventRepo
            //            .All<EventViewModel>()
            //            .FirstOrDefaultAsync(x => x.EventId == eventId);

            var even = await _applicationDbContext.Events
                       .FirstOrDefaultAsync(x => x.Id == eventId);

            return even != null;
        }

        public async Task<bool> CheckAvailableEvents(int eventId, DateTime date)
        {
            // return !await this.eventRepo.All<Event>().AnyAsync(e => e.Id == eventId && e.CreatedOn.Date == date.Date);
            return !await _applicationDbContext.Events.Where(e => e.Id == eventId && e.CreatedOn.Date == date.Date).AnyAsync();
        }
    }
}
