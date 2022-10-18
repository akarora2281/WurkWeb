namespace Wurk.Core.Models.ArtStore
{
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class ArtOrderViewModel
    {
        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
