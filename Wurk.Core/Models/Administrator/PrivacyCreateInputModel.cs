namespace Wurk.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static Wurk.Common.GlobalConstants.DisplayNames;
    using static Wurk.Common.GlobalConstants.Privacy;
    using static Wurk.Common.MessageConstants;

    public class PrivacyCreateInputModel 
    {
        [Display(Name = PageContentDisplayName)]
        [Required(ErrorMessage = EmptyField)]
        [MinLength(PageContentMinLength)]
        [MaxLength(PageContentMaxLength, ErrorMessage = PageContentLength)]

        public string PageConetent { get; set; }
    }
}
