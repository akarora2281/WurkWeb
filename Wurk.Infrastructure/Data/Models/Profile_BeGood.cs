namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class Profile_BeGood : BaseDeletableModel<int>
    {
        [Required]
        public string Action { get; set; }

        [Required]
        public string Passions { get; set; }

        [Required]
        public string Knowledge { get; set; }
    }
}
