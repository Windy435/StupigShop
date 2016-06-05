namespace StupigShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StupigShop.Data.StupigShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StupigShopDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new StupigShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new StupigShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "Stupig",
            //    Email = "stupig.shop@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Stupig Online Shop"
            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("stupig.shop@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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
    }
}