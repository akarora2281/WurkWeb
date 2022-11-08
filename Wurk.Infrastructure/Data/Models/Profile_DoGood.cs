namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class Profile_DoGood : BaseDeletableModel<int>
    {
        public string People { get; set; }

        public string Planet { get; set; }

        public string Prosperity { get; set; }
    }
}
