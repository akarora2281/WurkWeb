namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class Profile_BeGood : BaseDeletableModel<int>
    {
        public string Action { get; set; }

        public string Passions { get; set; }

        public string Knowledge { get; set; }
    }
}
