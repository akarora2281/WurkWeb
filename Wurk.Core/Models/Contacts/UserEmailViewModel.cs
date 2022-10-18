namespace Wurk.Core.Models.Contacts
{
    using Wurk.Core.Mapping.Contracts;
    using Wurk.Infrastructure.Data.Models;
    public class UserEmailViewModel : IMapFrom<ContactForm>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
