namespace Wurk.Core.Contracts
{
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.Network;

    public interface INetworkService
    {
        Task<int> CreateNetworkAsync(NetworkCreateInputModel model, string user);

        Task<int> EditNetwork(NetworkEditViewModel model, int networkId);

        void Delete(int id);

        IEnumerable<NetworkViewModel> GetAll();

        int AllNetworkCount();

        IEnumerable<NetworkViewModel> GetAllNetwork();

        /*Task<IEnumerable<BlogPostViewModel>> GetAll<T>(int? sortId, int blogId);

        IEnumerable<int> GetById<T>(int blogId);

        Task<string> GetAuthorIdAsync(int blogId);

        Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId);

        Task<List<BlogPostViewModel>> GetLatestBlogAsync<T>(int blogId);

        Task<bool> BlogPostExists(int blogId);*/
    }
}
