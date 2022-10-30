namespace Wurk.Core.Models.Network
{
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class AllNetworkListViewModel
    {
        public IEnumerable<NetworkViewModel> AllNetworks { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Date => this.CreatedOn.ToShortDateString();

        public string UserId { get; set; }

        public string EmployerId { get; set; }
    }
}
