namespace Wurk.Core.Models.Profile
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;
    using Wurk.Infrastructure.Data.Models;

    public class ProfileCreateInputModel
    {
        [Required]
        public Profile_FeelGood feelGood { get; set; }

        [Required]
        public Profile_DoGood doGood { get; set; }

        [Required]
        public Profile_BeGood beGood { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
