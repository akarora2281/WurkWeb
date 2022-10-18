namespace Wurk.Core.Contracts
{
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.BlogPosts;

    public interface IBlogPostService
    {
        Task<int> CreateBlogPostAsync(BlogPostCreateInputModel model, string user);

        Task<int> EditBlog(BlogPostEditViewModel model, int blogId);

        void Delete(int id);

        IEnumerable<BlogPostViewModel> GetAll();

        int AllBlogsCount();

        IEnumerable<BlogPostViewModel> GetAllBlogs();

        Task<IEnumerable<BlogPostViewModel>> GetAll<T>(int? sortId, int blogId);

        IEnumerable<int> GetById<T>(int blogId);

        Task<string> GetAuthorIdAsync(int blogId);

        Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId);

        Task<List<BlogPostViewModel>> GetLatestBlogAsync<T>(int blogId);

        Task<bool> BlogPostExists(int blogId);
    }
}
