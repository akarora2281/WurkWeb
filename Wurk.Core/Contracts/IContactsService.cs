namespace Wurk.Core.Contracts
{
    using Wurk.Core.Models.Contacts;

    public interface IContactsService
    {
        Task<IEnumerable<T>> GetAllUserEmailsAsync<T>();

        Task ConatctAdmin(ContactFormViewModel model);

        Task ContactUser(SendContactInputViewModel model);
    }
}
