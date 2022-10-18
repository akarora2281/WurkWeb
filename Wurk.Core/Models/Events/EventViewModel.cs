
namespace Wurk.Core.Models.Events
{
    using Wurk.Core.Mapping.Contracts;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class EventViewModel : IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public string Description { get; set; }
    }
}
