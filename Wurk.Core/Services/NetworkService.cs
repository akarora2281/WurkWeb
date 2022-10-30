namespace Wurk.Core.Services
{
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.BlogPosts;
    using Wurk.Core.Models.Home;
    using Wurk.Infrastructure.Data;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.EntityFrameworkCore;
    using static Wurk.Common.MessageConstants;
    using Wurk.Core.Models.Network;

    public class NetworkService : INetworkService
    {
        private readonly IAppRepository _networkRepo;
        private readonly ICloudinaryService _cloudinary;
        private readonly ApplicationDbContext _applicationDbContext;

        public NetworkService(IAppRepository networkRepo, ICloudinaryService cloudinary
            , ApplicationDbContext applicationDbContext)
        {
            this._networkRepo = networkRepo;
            this._cloudinary = cloudinary;
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<int> CreateNetworkAsync(NetworkCreateInputModel model, string user)
        {
            //var coverImage = this._cloudinary.UploadImageAsync(model.CoverImage, model.Title);
            var network = new Network
            {
                UserId = Guid.NewGuid().ToString(),
                Title = model.Title,
                //UrlImage = coverImage,
                Description = model.Description,
                Tags = model.Tags,
                EmployerId = model.EmployeeId
            };

            bool isPostExist = this._networkRepo.All<Network>().Any(x => x.Title == model.Title);

            if (isPostExist)
            {
                throw new ArgumentException(string.Format(NetworkAlreadyExists, model.Title));
            }

            await this._networkRepo.AddAsync(network);
            await this._networkRepo.SaveChangesAsync();
            return network.Id;
        }

        public async Task<int> EditNetwork(NetworkEditViewModel model, int networkId)
        {
            var network = this._networkRepo.All<Network>()
                        .FirstOrDefault(b => b.Id == networkId);

            if (network == null)
            {
                throw new ArgumentNullException(string.Format(NonExistingPost, $"{networkId}"));
            }

            network.Title = model.Title;
            network.Description = model.Description;
            //blog.UserId = model.us;

            this._networkRepo.Update(network);
            await this._networkRepo.SaveChangesAsync();

            return network.Id;
        }

        public void Delete(int id)
        {
            var blogPost = this._networkRepo
                .All<NetworkViewModel>()
                .Where(x => x.NetworkId.Equals(id))
                .FirstOrDefault();

            if (blogPost == null)
            {
                throw new ArgumentNullException(string.Format(NonExistingPost, $"{id}"));
            }

            this._networkRepo.Delete(blogPost);
            this._networkRepo.SaveChanges();
        }

        public int AllNetworkCount()
        {
            return this._networkRepo
                   .All<Network>()
                   .Count();
        }

        public IEnumerable<NetworkViewModel> GetAllNetwork()
        {
            return this._networkRepo
                .All<Network>()
                .To<NetworkViewModel>()
                .ToList();
        }

        public IEnumerable<NetworkViewModel> GetAll()
        {
            // Code changes by behaviour.    
            //var blogList = blogRepo.All<BlogPostViewModel>()
            //     .OrderByDescending(b => b.CreatedOn)
            //     .ToList();

            var networkList = _networkRepo.All<Network>().Select(x => new NetworkViewModel
            {
                UserId = x.UserId,
                NetworkId = x.Id.ToString(),
                Description = x.Description,
                CreatedOn = x.CreatedOn,
                Title = x.Title,
                //UrlImageStr = x.UrlImage,
            })
            .ToList();

            return networkList;
        }

        /*public async Task<IEnumerable<BlogPostViewModel>> GetAll<T>(int? sortId, int blogId)
        {
            // Code changes by behaviour.    
            //  var blog = this.blogRepo.All<BlogPostViewModel>().OrderByDescending(x => x.CreatedOn);
            var blogList = _applicationDbContext.BlogPosts.Select(x => new BlogPostViewModel
            {
                Author = x.Author,
                BlogId = x.Id,
                Content = x.Content,
                CreatedOn = x.CreatedOn,
                Title = x.Title,
                UrlImageStr = x.UrlImage,
                UserReaction = x.UserReaction,
            })
            .OrderByDescending(x => x.CreatedOn).ToList();

            if (sortId != null)
            {
                //   blogList = (IOrderedQueryable<BlogPostViewModel>)blogList.Where(x => x.BlogId == sortId);
                blogList = blogList.Where(x => x.BlogId == sortId).Skip(blogId - 1).ToList();
            }

            // return await blogList.Skip(blogId - 1).To<T>().ToListAsync();
            return blogList;
        }

        public IEnumerable<int> GetById<T>(int blogId)
        {
            // Code changes by behaviour.   
            //var blogPost = this.blogRepo
            //        .All<BlogPostViewModel>()
            //        .Where(x => x.BlogId == blogId)
            //        .FirstOrDefault();
            var blogPost = this._applicationDbContext
                   .BlogPosts
                   .Where(x => x.Id == blogId)
                   .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }

        public async Task<string> GetAuthorIdAsync(int blogId)
        {
            var posts = this._networkRepo
                .All<BlogPostViewModel>()
                .SingleOrDefault(p => p.BlogId == blogId);

            return posts.Author;
        }

        public async Task<List<BlogPostViewModel>> GetLatestBlogAsync<T>(int blogId)
        {
            // Code changes by behaviour.   
            //return await this.blogRepo.All<BlogPost>()
            //               .Where(b => b.Id == blogId &&
            //                    b.CreatedOn > DateTime.UtcNow.Date)
            //               .OrderByDescending(b => b.CreatedOn)
            //               .To<BlogPostViewModel>()
            //               .Take(2)
            //               .ToListAsync();

            return await _applicationDbContext.BlogPosts
                // .Where(b => b.Id == blogId && b.CreatedOn > DateTime.UtcNow.Date)
                .Where(b => b.CreatedOn <= DateTime.UtcNow.Date)
                .Select(x => new BlogPostViewModel
                {
                    Author = x.Author,
                    BlogId = x.Id,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    Title = x.Title,
                    UrlImageStr = x.UrlImage,
                    UserReaction = x.UserReaction,
                })
                .OrderByDescending(b => b.CreatedOn)
                .Take(2)
                .ToListAsync();

        }

        public async Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId)
        {
            var blogPost = this._networkRepo
                            .All<BlogPostViewModel>()
                            .Where(b => b.BlogId == blogId)
                            .To<T>()
                            .FirstOrDefault();

            return blogPost;
        }

        public async Task<bool> BlogPostExists(int blogId) => this._networkRepo
                                .All<BlogPostViewModel>()
                                .Any(b => b.BlogId == blogId);*/
    }
}

