namespace Wurk.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;
    using static Wurk.Common.GlobalConstants.BlogPost;
    using static Wurk.Common.GlobalConstants.DisplayNames;
    using static Wurk.Common.MessageConstants;

    public class NetworkCreateInputModel
    {

        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(ContentMaxLength)]
        public string Tags { get; set; }

        public int EmployeeId { get; set; }
    }
}
