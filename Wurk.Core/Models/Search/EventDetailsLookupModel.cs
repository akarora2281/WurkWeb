namespace Wurk.Core.Models.Search
{
    using Wurk.Infrastructure.Data.Models.Enumeration;
    
    public class EventDetailsLookupModel 
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public string Description { get; set; }
    }
}
