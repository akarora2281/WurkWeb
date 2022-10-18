namespace Wurk.Core.Models.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using static Wurk.Common.GlobalConstants.ArtGalleryUser;
    using static Wurk.Common.GlobalConstants.DisplayNames;

    public class UserEditViewModel 
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        [Display(Name = FirstNameDisplayName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        [Display(Name = LastNameDisplayName)]
        public string LastName { get; set; }
    }
}
