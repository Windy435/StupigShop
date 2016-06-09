namespace StupigShop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StupigShop.Data.StupigShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StupigShopDbContext context)
        {
            //CreateUserManager(Context);
            //CreateProductCategorySample(context);
            //createFooterSample(context);
            //createSlide(context);
        }

        private void CreateUserManager(StupigShopDbContext dbContext)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new StupigShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new StupigShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "Stupig",
                Email = "stupig.shop@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Stupig Online Shop"
            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("stupig.shop@gmail.com");
        }

        private void CreateProductCategorySample(StupigShopDbContext dbContext)
        {
            if (dbContext.ProductCategorys.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() {Name ="Điện lạnh", Alias = "dien-lanh",Status=true},
                    new ProductCategory() {Name ="Viễn thông", Alias = "vien-thong",Status=true},
                    new ProductCategory() {Name ="Đồ gia dụng", Alias = "do-gia-dung",Status=true},
                    new ProductCategory() {Name ="Mỹ phẩm", Alias = "my-pham",Status=true}
                };
                dbContext.ProductCategorys.AddRange(listProductCategory);
                dbContext.SaveChanges();
            }
        }

        private void createFooterSample(StupigShopDbContext dbContext)
        {
            if (dbContext.Footers.Count(x => x.ID == CommonConstants.DefaultFooterID) == 0)
            {
                StreamReader readContent = File.OpenText("E:\\Newbie\\StupigShop-ASP.NET_WebAPI_AngularJS\\Source\\Git\\StupigShop\\StupigShop.Data\\Migrations\\FooterContent.txt");
                string content = readContent.ReadToEnd();

                dbContext.Footers.Add(new Footer() { ID = CommonConstants.DefaultFooterID, Content = content });
                dbContext.SaveChanges();
            }
        }

        private void createSlide(StupigShopDbContext dbContext)
        {
            if (dbContext.Slides.Count() == 0)
            {
                List<Slide> listSilde = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder = 1,
                        Status =true,
                        URL ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
                                       <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                       <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                       <span class=""on-get"">GET NOW</spa"
                    },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder = 2,
                        Status = true,
                        URL = "#",
                        Image = "/Assets/client/images/bag1.jpg",
                        Content = @"<h2>FLAT 50% 0FF</h2>
                                        <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                        <span class=""on-get"">GET NOW</span>"
                    }
                };
                dbContext.Slides.AddRange(listSilde);
                dbContext.SaveChanges();
            }
        }
    }
}