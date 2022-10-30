namespace Wurk.Core.Models.Network
{
    using System;
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class NetworkViewModel
    {
        public string NetworkId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
