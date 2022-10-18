using Wurk.Core.Contracts;
using Wurk.Core.Models.ArtStore;
using Wurk.Core.Services;
using Wurk.Infrastructure.Data;
using Wurk.Infrastructure.Data.Repositories;
using Wurk.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Wurk.Tests
{
    public class ArtStoreServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IArtStoreService> _artStoreService;
        private ApplicationDbContext _context;
        public ArtStoreServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _artStoreService = new Mock<IArtStoreService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "ArtStoreDb")
         .Options);

        }

        [Fact]
        public void CreateArtAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetArtStoreCreateInputModelObject()));
            _artStoreService.Setup(x => x.CreateArtAsync(ObjectGenerator.GetArtStoreCreateInputModelObject()));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.CreateArtAsync(ObjectGenerator.GetArtStoreCreateInputModelObject()), Times.Never);
        }


        [Fact]
        public void UpdateArtStore_Test()
        {
            // Assert
            _repo.Setup(x => x.Update(ObjectGenerator.GetArtStoreViewModelObject()));
            _artStoreService.Setup(x => x.UpdateArtStore(ObjectGenerator.GetArtStoreViewModelObject()));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.UpdateArtStore(ObjectGenerator.GetArtStoreViewModelObject()), Times.Never);
        }

        [Fact]
        public void DeleteAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.Delete(ObjectGenerator.GetArtStoreViewModelObject()));
            _artStoreService.Setup(x => x.DeleteAsync(1));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.DeleteAsync(1), Times.Never);
        }

        [Fact]
        public void GetAll_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtStoreViewModel>()).Returns(new List<ArtStoreViewModel> {
             ObjectGenerator.GetArtStoreViewModelObject()
            }.AsQueryable());

            _artStoreService.Setup(x => x.GetAll());

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.GetAll(), Times.Never);
        }

        [Fact]
        public void GetById_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtStoreViewModel>()).Returns(new List<ArtStoreViewModel> {
             ObjectGenerator.GetArtStoreViewModelObject()
            }.AsQueryable());
            _repo.Setup(x => x.GetByIdAsync<ArtStoreViewModel>(1));

            _artStoreService.Setup(x => x.GetById<ArtStoreViewModel>(1));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.GetById<ArtStoreViewModel>(1), Times.Never);
        }


        [Fact]
        public void Details_Test()
        {
            // Assert
            _repo.Setup(x => x.AllReadonly<ArtDetailsViewModel>());

            _artStoreService.Setup(x => x.Details(1));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.Details(1), Times.Never);
        }

        [Fact]
        public void CheckIfArtExists_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtStoreViewModel>());

            _artStoreService.Setup(x => x.CheckIfArtExists(1));

            // Act
            var service = new ArtStoreService(_repo.Object);

            // Verify
            _artStoreService.Verify(x => x.CheckIfArtExists(1), Times.Never);
        }
    }
}
