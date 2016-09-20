using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Yucca.Models.Common;
using Yucca.Models.IdentityModels;
using Yucca.Models.Products;
using Yucca.Utility.Security;

namespace Yucca.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.DbContext;

    internal sealed class Configuration 
        : DbMigrationsConfiguration<Yucca.Data.DbContext.YuccaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Yucca.Data.DbContext.YuccaDbContext context)
        {
            InitializeUserAndRoleIdentityForEf(context);
            InitializeCategoryIdentityForEf(context);
            InitializeCategorySlideIdentityForEf(context);
            InitializeProductIdentityForEf(context);
            InitializePictureIdentityForEf(context);
            InitializeSettingIdentityForEf(context);
            base.Seed(context);
        }

        private void InitializeCategorySlideIdentityForEf(YuccaDbContext context)
        {
            var slides = new List<CategorySlide>
            {
                new CategorySlide
                {
                    Id = 1,
                    CategoryId =5,
                    Title = "",
                    ImagePath = "Content/Slides/golhaye-apartemani/Orchid-Flower-30.jpg"
                },
                new CategorySlide
                {
                    Id = 2,
                    CategoryId =5,
                    Title = "",
                    ImagePath ="Content/Slides/golhaye-apartemani/Orchid-Flower-30.jpg"
                },
                new CategorySlide
                {
                    Id = 3,
                    CategoryId =5,
                    Title = "",
                    ImagePath ="Content/Slides/golhaye-apartemani/Orchid-Flower-30.jpg"
                },
                new CategorySlide
                {
                    Id = 4,
                    CategoryId =5,
                    Title = "",
                    ImagePath = "Content/Slides/golhaye-apartemani/Orchid-Flower-30.jpg"
                },
                new CategorySlide
                {
                    Id = 5,
                    CategoryId =6,
                    Title = "",
                    ImagePath ="Content/Slides/kaktoos/kaktuskbh_shop.jpg"
                },
                new CategorySlide
                {
                    Id = 6,
                    CategoryId =6,
                    Title = "",
                    ImagePath ="Content/Slides/kaktoos/Cactus-Meaning.jpg"
                },
                new CategorySlide
                {
                    Id = 7,
                    CategoryId =6,
                    Title = "",
                    ImagePath ="Content/Slides/kaktoos/Cactus-Flower-14.jpg"
                },
                new CategorySlide
                {
                    Id = 8,
                    CategoryId =6,
                    Title = "",
                    ImagePath ="Content/Slides/kaktoos/61667.jpg"
                },
                new CategorySlide
                {
                    Id = 9,
                    CategoryId =7,
                    Title = "",
                    ImagePath ="Content/Slides/sakolent/108202.jpg"
                },
                new CategorySlide
                {
                    Id = 10,
                    CategoryId =7,
                    Title = "",
                    ImagePath ="Content/Slides/sakolent/Frithia-Pulchra1.jpg"
                },
                new CategorySlide
                {
                    Id = 11,
                    CategoryId =8,
                    Title = "",
                    ImagePath ="Content/Slides/daratche/blossoms_twigs_spring_nature.jpg"
                },
                new CategorySlide
                {
                    Id = 12,
                    CategoryId =8,
                    Title = "",
                    ImagePath ="Content/Slides/daratche/red-bougainvilleas.jpg"
                },
                new CategorySlide
                {
                    Id = 13,
                    CategoryId =8,
                    Title = "",
                    ImagePath ="Content/Slides/daratche/roses_shrub_wall_flowering_green_needles.jpg"
                },
                new CategorySlide
                {
                    Id = 14,
                    CategoryId =9,
                    Title = "",
                    ImagePath ="Content/Slides/bonsai/Bonsai-Wallpaper-11.jpg"
                },
                new CategorySlide
                {
                    Id = 15,
                    CategoryId =9,
                    Title = "",
                    ImagePath ="Content/Slides/bonsai/cherry-bonsai-tree.jpg"
                },
                new CategorySlide
                {
                    Id = 16,
                    CategoryId =9,
                    Title = "",
                    ImagePath ="Content/Slides/bonsai/tree_bonsai_black_background.jpg"
                },
                new CategorySlide
                {
                    Id = 17,
                    CategoryId =10,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/planting-seeds.jpg"
                },
                new CategorySlide
                {
                    Id = 18,
                    CategoryId =10,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/planting-the-seeds-of-our-dreams-1.jpg"
                },
                new CategorySlide
                {
                    Id = 19,
                    CategoryId =10,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/Seeds-You-Can-Eat.jpg"
                },
                new CategorySlide
                {
                    Id = 20,
                    CategoryId =11,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/planting-seeds.jpg"
                },
                new CategorySlide
                {
                    Id = 21,
                    CategoryId =11,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/planting-the-seeds-of-our-dreams-1.jpg"
                },
                new CategorySlide
                {
                    Id = 22,
                    CategoryId =11,
                    Title = "",
                    ImagePath ="Content/Slides/bazra/Seeds-You-Can-Eat.jpg"
                }

            };
            context.CategorySlides.AddRange(slides);
        }

        private void InitializeSettingIdentityForEf(YuccaDbContext context)
        {
            context.Settings.AddRange(new List<YuccaSetting>
            {
                new YuccaSetting
                {
                    Id = 1,
                    Name = "StoreName",
                    Value = "Yucca",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 2,
                    Name = "StoreKeyWords",
                    Value = "Yucca یوکا",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 3,
                    Name = "StoreDescription",
                    Value = "فروشگاه اینترنتی گل وگیاه",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 4,
                    Name = "Tel1",
                    Value = "09136861439",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 5,
                    Name = "Tel2",
                    Value = "09136861439",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 6,
                    Name = "Address",
                    Value = "تهران خیابان اول ساختمان یوکا",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 7,
                    Name = "PhoneNumber1",
                    Value = "09136861439",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                },
                new YuccaSetting
                {
                    Id = 8,
                    Name = "PhoneNumber2",
                    Value = "09136861439",
                    ModifiedBy = "Salman",
                    ModifiedOn = DateTime.Now,
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now
                }
            }
                );
        }

        private void InitializePictureIdentityForEf(YuccaDbContext context)
        {
            var pictures = new List<ProductPicture>
            {
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/golhaye-apartemani/barg-angiri-500x500.png",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 1
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/golhaye-apartemani/barg-ghashoooghi-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 2
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/golhaye-apartemani/fit1-(4)-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 3
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/golhaye-apartemani/mosa-gahvare-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 4
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/derakhtche-ha/1-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 5
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/derakhtche-ha/FORSYTHIA-SPRING-GLORY-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 6
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/derakhtche-ha/gol-kaghazi-(2)-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 7
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/derakhtche-ha/LAGERSTROEMIA-INDICA-(6)-500x500.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 8
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/sakolent/d-1339-600x600.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 9
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/sakolent/d-1347-600x600.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 10
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/sakolent/d1-5735-600x600.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 11
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/sakolent/photostudio_1451668789526-600x600.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 12
                }

            };
            context.ProductPictures.AddRange(pictures);
            context.SaveAllChanges();
        }

        private void InitializeProductIdentityForEf(YuccaDbContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    CategoryId = 5,
                    Description = "",
                    Name = "گل برگ انجیری",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 30000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 5,
                    Description = "",
                    Name = "گل برگ قاشقی",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 35000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 5,
                    Description = "",
                    Name = "گل فیتونیا",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 40000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 5,
                    Description = "",
                    Name = "گل گهواره موسی",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 45000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 8,
                    Description = "",
                    Name = "درختچه گل کاملیا",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 30000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 8,
                    Description = "",
                    Name = "درختچه گل یاس زرد",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 35000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 8,
                    Description = "",
                    Name = "درختچه گل کاغذی",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 40000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 8,
                    CategoryId = 8,
                    Description = "",
                    Name = "درختچه گل توری",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 45000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 7,
                    Description = "",
                    Name = "آلوئه",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 30000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 10,
                    CategoryId = 7,
                    Description = "",
                    Name = "سانسوریا",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 35000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 11,
                    CategoryId = 7,
                    Description = "",
                    Name = "هاورتیا گورخری",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 40000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Product
                {
                    Id = 12,
                    CategoryId = 7,
                    Description = "",
                    Name = "گاستریا",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 45000,
                    MetaDescription = "",
                    MetaKeyWords = "",
                    Deleted = false,
                    CreatedBy = "Salman",
                    ModifiedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void InitializeCategoryIdentityForEf(YuccaDbContext context)
        {
            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "گل ها",
                    Description = "گل های زینتی متنوع",
                    DisplayOrder = 1,
                    KeyWords = "فروش گل زینتی",
                    IsDeleted = false,
                    ParentId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "بذر های گیاهی",
                    Description = "بذر های انواع گیاهان و گل ها",
                    DisplayOrder = 2,
                    KeyWords = "فروش بذر کشاورزی",
                    IsDeleted = false,
                    ParentId = null
                },
                new Category
                {
                    Id = 3,
                    Name = "خاک و کود",
                    Description = "خاک و کود متناسب با انواع گیاهان و گل ها",
                    DisplayOrder = 3,
                    KeyWords = "فروش خاک و کود های طبیعی و شیمیایی",
                    IsDeleted = false,
                    ParentId = null
                },
                new Category
                {
                    Id = 4,
                    Name = "آموزش ها",
                    Description = "آموزش های مربوط به گل داری و گیاه داری",
                    DisplayOrder = 4,
                    KeyWords = "آموزش گلداری گیاهداری",
                    IsDeleted = false,
                    ParentId = null
                },
                new Category
                {
                    Id = 5,
                    Name = "گل های آپارتمانی",
                    Description = "انواع گل های آپارتمانی",
                    DisplayOrder = 1,
                    KeyWords = "آپارتمانی درختچه گل",
                    IsDeleted = false,
                    ParentId = 1
                },
                new Category
                {
                    Id = 6,
                    Name = "کاکتوس",
                    Description = "انواع گل های کاکتوس",
                    DisplayOrder = 2,
                    KeyWords = "کاکتوس زبون خارسو گل",
                    IsDeleted = false,
                    ParentId = 1
                },
                new Category
                {
                    Id = 7,
                    Name = "سایکولنت",
                    Description = "انواع گل های سایکلونت",
                    DisplayOrder = 3,
                    KeyWords = "سایکولنت درختچه گل",
                    IsDeleted = false,
                    ParentId = 1
                },
                new Category
                {
                    Id = 8,
                    Name = "درختچه های زینتی",
                    Description = "انواع درختچه های زینتی",
                    DisplayOrder = 4,
                    KeyWords = " زینتی درخت درختچه گل",
                    IsDeleted = false,
                    ParentId = 1
                },
                new Category
                {
                    Id = 9,
                    Name = "بن سای",
                    Description = "انواع گل های بن سای",
                    DisplayOrder = 5,
                    KeyWords = "بن سای درختچه گل",
                    IsDeleted = false,
                    ParentId = 1
                },
                new Category
                {
                    Id = 10,
                    Name = "بذر گل",
                    Description = "انواع بذر های گل ",
                    DisplayOrder = 1,
                    KeyWords = "بذر دانه گل",
                    IsDeleted = false,
                    ParentId = 2
                },
                new Category
                {
                    Id = 11,
                    Name = "بذر گیاه",
                    Description = "انواع بذر های گیاه",
                    DisplayOrder = 2,
                    KeyWords = "بذر درختچه گل گیاه",
                    IsDeleted = false,
                    ParentId = 2
                },
                new Category
                {
                    Id = 12,
                    Name = " خاک و کود طبیعی",
                    Description = "انواع خاک و کود های طبیعی",
                    DisplayOrder = 1,
                    KeyWords = "خاک کود طبیعی",
                    IsDeleted = false,
                    ParentId = 3
                },
                new Category
                {
                    Id = 13,
                    Name = " خاک و کود شیمیایی",
                    Description = "انواع خاک و کود های شیمیایی",
                    DisplayOrder = 2,
                    KeyWords = "خاک کود شیمیایی فسفات کودکشاورزی",
                    IsDeleted = false,
                    ParentId = 3
                },
                new Category
                {
                    Id = 14,
                    Name = "آموزش پیوند",
                    Description = "آموزش پیوند گل ها و درختان و گیاهان",
                    DisplayOrder = 1,
                    KeyWords = "پیوندگل پیونددرخت",
                    IsDeleted = false,
                    ParentId = 4
                },
                new Category
                {
                    Id = 15,
                    Name = "تعویض خاک",
                    Description = "آموزش تعویض خاک گل ها و درختان و گیاهان",
                    DisplayOrder = 1,
                    KeyWords = "خاک گل درخت",
                    IsDeleted = false,
                    ParentId = 4
                }
            };
            context.Categories.AddRange(categoryList);
            context.SaveAllChanges();
        }

        private static void InitializeUserAndRoleIdentityForEf(YuccaDbContext context)
        {
            const string firstName = "Salman";
            const string lastName = "Maroufi";
            const string email = "salman.maroufi@gmail.com";
            const string password = "Salman@09136861439";

            #region Create All Roles
            const string adminRoleName = "Admin";
            const string operatorRoleName = "Operator";
            const string customerRoleName = "Customer";

            var adminRole = context.Roles.FirstOrDefault(a => a.Name == adminRoleName);
            var operatorRole = context.Roles.FirstOrDefault(a => a.Name == operatorRoleName);
            var customerRole = context.Roles.FirstOrDefault(a => a.Name == customerRoleName);
            if (adminRole == null)
            {
                adminRole = new YuccaRole(adminRoleName);
                context.Roles.Add(adminRole);
            }

            if (operatorRole == null)
            {
                operatorRole = new YuccaRole(operatorRoleName);
                context.Roles.Add(operatorRole);

            }
            if (customerRole == null)
            {
                customerRole = new YuccaRole(customerRoleName);
                context.Roles.Add(customerRole);
            }
            #endregion
            var user = context.Users.FirstOrDefault(a => a.UserName == email);
            if (user == null)
            {
                user = new YuccaUser
                {
                    UserName = email,
                    Email = email,
                    AccessFailedCount = 0,
                    PasswordHash = Encryption.HashPassword(password),
                    EmailConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = "09136861439"
                };
                context.Users.Add(user);
            }
            var firstOrDefault = context.Users.FirstOrDefault(a => a.Id == user.Id);
            if (firstOrDefault != null)
            {
                var rolesForUser = firstOrDefault.Roles.ToList();
                if (rolesForUser.First().RoleId!=adminRole.Id)
                {
                    var userRole = new YuccaUserRole {UserId = user.Id, RoleId = adminRole.Id};
                    context.Users.Find(user.Id).Roles.Add(userRole);
                }
            }
            context.SaveChanges();
        }
    }
}
