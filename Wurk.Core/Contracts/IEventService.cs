namespace Wurk.Core.Contracts
{
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.Events;
    using Wurk.Core.Models.Home;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEventService
    {

        Task<bool> CreateEventAsync(string name, decimal price, string date,
            string type, string ticketSelection, string description);

        Task<bool> UpdateEventAsync(EventEditViewModel model);

        void Delete(int id);

        int AllEventsCount();

        IEnumerable<EventViewModel> GetAllEvents(int eventId);

        IEnumerable<int> GetByIdAsync(int eventId);

        Task<IEnumerable<UpcomingEventViewModel>> GetUpcomingByIdAsync<T>(int eventId);

        Task AddAsync(EventCreateInputViewModel model);

        Task<EventViewModel> GetEventDetailsByIdAsync<T>(int eventId);

        Task<bool> CheckIfEventExists(int eventId);

        Task<bool> CheckAvailableEvents(int eventId, DateTime date);
    }
}
