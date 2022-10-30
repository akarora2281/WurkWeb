namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class Profile_DoGood : BaseDeletableModel<int>
    {
        [Required]
        public string People { get; set; }

        [Required]
        public string Planet { get; set; }

        [Required]
        public string Prosperity { get; set; }
    }
}
