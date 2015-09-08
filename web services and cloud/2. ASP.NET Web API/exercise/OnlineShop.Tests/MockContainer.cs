using Moq;
using OnlineShop.Data.Repository;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineShop.Tests
{
    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeAds();
            this.SetupFakeAdTypes();
            this.SetupFakeUsers();
            this.SetupCategories();
        }

        private void SetupFakeAds()
        {
            var adTypes = new List<AdType>()
            {
                new AdType() { Name = "Normal", Index = 100 },
                new AdType() { Name = "Premium", Index = 200 }
            };

            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 5,
                    Name = "Audi A6",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now.AddDays(-6),
                    Owner = new ApplicationUser() { Id = "123", UserName = "Gosho"  },
                    Price = 4600
                },
                new Ad()
                {
                    Id = 7,
                    Name = "Opel Astra",
                    Type = adTypes[1],
                    PostedOn = DateTime.Now.AddDays(-10),
                    Owner = new ApplicationUser() { Id = "256", UserName = "Mincho"  },
                    Price = 1100
                },
                new Ad()
                {
                    Id = 9,
                    Name = "BMW M3",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now.AddDays(-9),
                    Owner = new ApplicationUser() { Id = "341", UserName = "Kiro"  },
                    Price = 25700
                }
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeAds.FirstOrDefault(a => a.Id == id);
                });
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType() { Name = "Normal", Index = 100 },
                new AdType() { Name = "Premium", Index = 200 }
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());

            this.AdTypeRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeAdTypes.FirstOrDefault(a => a.Id == id);
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser() { Id = "12", UserName = "Gosho" },
                new ApplicationUser() { Id = "123", UserName = "Tosho" },
                new ApplicationUser() { Id = "1234", UserName = "Pesho" }
            };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<string>()))
                .Returns((string id) =>
                {
                    return fakeUsers.FirstOrDefault(u => u.Id == id);
                });
        }

        private void SetupCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Bikes" },
                new Category() { Id = 2, Name = "Cars" },
                new Category() { Id = 3, Name = "Computers" },
                new Category() { Id = 4, Name = "Electronics" }
            };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(r => r.All())
                .Returns(fakeCategories.AsQueryable());

            this.CategoryRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeCategories.FirstOrDefault(c => c.Id == id);
                });
        }
    }
}