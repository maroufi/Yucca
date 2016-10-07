using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/kaktoos/ashoria.JPG",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 13
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/kaktoos/havertia.JPG",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 14
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/kaktoos/kerasola.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 15
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/kaktoos/doorestia.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 16
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/bonsay/fikoose-anjiri.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 17
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/bonsay/sagersia.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 18
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/bonsay/sizigiom.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 19
                },
                new ProductPicture
                {
                    Description = "",
                    ImageAltText = "",
                    ImagePath = "Content/mahsoolat/bonsay/afra-zhaponi.jpg",
                    IsMainPicture = true,
                    Title = "",
                    ProductId = 20
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
                    Description =
                        "برگهای این گیاه پهن و دارای بریدگی‌های عمیق می‌باشد. هوای گرم و مرطوب ، ایده آل آنهاست. تغییرات درجه حرارت را به راحتی می‌پذیرند. ریشه‌های هوایی آنها احتیاج به تغذیه و تکیه گاه خزه‌دار دارند. نزدیک پنجره با نور غیر مستقیم ، نور دلخواه این گیاه است.سطح خاک در فاصله دو آبیاری باید خشک شود. در تابستان هفته‌ای یکبار و در زمستان هر دو هفته یکبار احتیاج به آبیاری دارد.",
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
                    Description =
                        "سايه آپارتمان ها را به خوبي تحمل مي كند . این گیاه اگرچه رشد سریعی ندارد، ولی در هر شرایطی در آپارتمان پرورش می یابد. مناطق پرنور يا نيمه سايه اطاق که دور از تابش مستقيم خورشيد باشد، مناسب است. اين گياه نياز چنداني به آب ندارد. هميشه مقدار زيادي آب در برگ هاي آن وجود دارد و سطح خاک گلدان بين دو آبياري بايد کاملاً خشک شود، ولي نبايد آبياري آنقدر به تعويق بيفتد که برگ ها پژمرده شوند.",
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
                    Description =
                        "این گیاه به نور متوسط، حرارت زیاد، آبیاری معمولی تا زیاد، رطوبت هوای ۷۰ تا ۹۰ درصد وخاک قلیایی احتیاج دارد.   ",
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
                    Description =
                        "دارای آرایش مارپیچی، به طول ۱۵-۳۰ cm و پهنای ۲. ۵-۸ cm که از ساقه‌ای تنه شکل به ارتفاع ۲۰ cm رشد می‌کنند. ساقه ستبر، کوتاه و غیر منشعب که به تقریب توسط پایه برگ‌ها پنهان شده است. برگ‌ها، مومی به رنگ سبز تیره یا سبز با نوار‌هایی به رنگ زرد کمرنگ در سطح بالایی بوده و در سطح زیرین به رنگ بنفش گمرنگ می‌باشند. گیاه، توده‌ای از پا جوش‌ها که از پایه گوشتی خود بیرون آمده را تشکیل می‌دهد.",
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
                    Description =
                        "کاملیا به نور متوسط ، حرارت معمولی، آبیاری متوسط تا زیاد، رطوبت 70 تا 90درصد و خاک اسیدی احتیاج دارد. مخلوطی از سه قسمت خاک جنگلی و یک قسمت ماسه برای پرورش کاملیا مناسب است. کود مورد نیاز این گیاه را می توان به مقدار 2 گرم سولفات آمونیوم و 2 گرم کود معمولی در یک لیتر، هر دوهفته یکبار از بهمن تا مرداد، مورد استفاده قرار داد. ",
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
                    Description =
                        "شرایط مطلوب محیط برای گیاه یاس زرد عبارتند از: نور: متوسط با سایه ی نسبی    رطوبت: متوسط      دما: 14 درجه سانتیگراد     خاک: مخلوط شن و رس و به خوبی زهکشی شده  این گیاه نسبتا مقاوم و سازگار شونده است و معمولا آفت اختصاصی شایع و یا بیماری خاصی متوجه آن نیست.",
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
                    Description =
                        "در نقاط سردسیر باید گلدانهای کاغذی را از اواخر مهرماه به داخل گلخانه برد .  چون در مقابل سرما مقاومت ندارد .  همچنین باید توجه داشت که اگر زمستان به این درختچه آب زیاد بدهند ریشه اش می پوسد . زمستانها باید کمی به بوته های گل کاغذی استراحت داد ، باین ترتیب که اگر گلدانها در منزل است محل نسبتا خنکی را برای آن انتخاب کنند و خیلی کم به آن آب بدهند .خاک مناسب برای گل کاغذی مخلوطی از دو پنجم خاک مرغوب باغچه ، دو قسمت کود پوسیده دامی و یک قسمت ماسه می باشد ",
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
                    Description =
                        "درختچه توری به نور کافی آفتاب نیاز دارد و محیط های نسبتاً مرطوب را ترجیح میدهد. بهترین خاک برای کاشت توری، مخلوطی از خاک تازه باغچه و خاک برگ به میزان مساوی است. باید در پائیز هرسال مقداری خاک مناسب، در پای بوته اضافه کرد این عمل باعث می شود که ریشه های سطحی کاملاً پوشیده شده و در زمستان از خطرسرمازدگی محفوظ بماند",
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
                    Description =
                        "معمولا این گیاه در اطاقهای کم رطوبت به خوبی رشد می کند . لبه برگهای آن دندانه دارد است و گلهایی به رنگ نارنجی روشن، به شکل گل آذین و به طول ۳۰ سانتیمتر دارد، این گلها در اوائل بهار ظاهر می شوند. در مقابل نور مستقیم خورشید قرار بگیرد و نیز نباید قطرات آب روی برگهای آن ریخته شود زیرا باعث پوسیدگی گیاه می شود. همچنین نیاز آب دادن زیاد در زمستان باید خودداری کرد.",
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
                    Description =
                        "نور کامل بهترین شرایط نوری این گیاه است ولی در سایه هم قادر به ادامه زندگی است ، تابش مستقیم آفتاب را تحمل نمی کند . در زمستان هر 3 هفته یکبار و در تابستان یکبار در هفته آبیاری کافی است به دلیل ساقه گوشتی گیاه که سرشار از آب است از آبیاری زیاد از اندازه پرهیز نمایید چون باعث پوسیدگی گیاه می گردد . در بین دو آبیاری اجازه دهید تا سطح خاک خشک شود.",
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
                    Description =
                        "به آب زیاد احتیاج ندارد، اجازه بدهید خاک خشک شود بعد از خشک شدن کامل خاک به آن آب بدهید. روشنایی را بسیار دوست دارد. اگر خانه¬ی شما کم نور است در فصول گرم حداقل برای مدت دو هفته گیاه را به خارج از ساختمان ببرید تا از نور کافی بهره¬مند شود سپس آن را به جای خود بازگردانید.",
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
                    Description =
                        "این جنس دارای 70 گونه مختلف از گیاهان چندساله گلخانه ای می باشد. گیاهان این جنس گوشتی و نسبتاً کوچک و تقریباً بدون ساقه می باشن .دز بهار تا پاییز به آبیاری بیشتری نیاز دارند ولی خاک آنها در فواصل آبیاری باید خشکی معتدلی داشت باشد.",
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
                },
                new Product
                {
                    Id = 13,
                    CategoryId = 6,
                    Description =
                        "نگهداری و پرورش این گیاهان آسان است و چندان نیاز به مراقبت ندارند، آنها باید در خارج از منزل و هوا آزاد قرار گیرند.هنگام آبیاری باید دقت شود، طوری که آب به مرکز روزت گیاه ریخته نشود زیرا ممکن است باعث پوسیدگی آن شود. اشورياهم در زمستان و هم در تابستان نیاز به مکانی با نور کافی دارد.این گیاهان حتی در تابستان به آب کم نیاز دارند. آب بیش از حد سبب گندیدگی این گیاه می شود.",
                    Name = "آشوریا",
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
                    Id = 14,
                    CategoryId = 6,
                    Description =
                        "به آب زیاد احتیاج ندارد، اجازه بدهید خاک خشک شود بعد از خشک شدن کامل خاک به آن آب بدهید. روشنایی را بسیار دوست دارد. اگر خانه¬ی شما کم نور است در فصول گرم حداقل برای مدت دو هفته گیاه را به خارج از ساختمان ببرید تا از نور کافی بهره¬مند شود سپس آن را به جای خود بازگردانید.",
                    Name = "هاورتیا",
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
                    Id = 15,
                    CategoryId = 6,
                    Description =
                        "کاکتوس به نور فراوان نیاز دارند و قرار دادن آنها در داخل اتاق و پشت پنجره های جنوبی بسیار مناسب است. در صورت ناکافی بودن نور طبیعی، نور مصنوعی نیز میتواند به عنوان مکمل، به کار رود. طی فصل رشد فعال کاکتوس باید بیش از دوران استراحت آبیاری شود. برنامه خاص و تعریف شده ای برای آبیاری کاکتوس وجود ندارد و برنامه آن به گلدان، خاک، آب و هوا و عوامل مشابه بستگی دارد. آبیاری بیش از حد موجب پوسیدگی ساقه و ریشه گیاه میشود و متاسفانه هنگامی که ریشه کاکتوس بپوسد یا حتی پوسیدگی در آن آغاز شود، دیگر نمیتوان گیاه را نجات داد.",
                    Name = "کراسولا",
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
                    Id = 16,
                    CategoryId = 6,
                    Description =
                        "کاکتوس به نور فراوان نیاز دارند و قرار دادن آنها در داخل اتاق و پشت پنجره های جنوبی بسیار مناسب است. در صورت ناکافی بودن نور طبیعی، نور مصنوعی نیز میتواند به عنوان مکمل، به کار رود. طی فصل رشد فعال کاکتوس باید بیش از دوران استراحت آبیاری شود. برنامه خاص و تعریف شده ای برای آبیاری کاکتوس وجود ندارد و برنامه آن به گلدان، خاک، آب و هوا و عوامل مشابه بستگی دارد. آبیاری بیش از حد موجب پوسیدگی ساقه و ریشه گیاه میشود و متاسفانه هنگامی که ریشه کاکتوس بپوسد یا حتی پوسیدگی در آن آغاز شود، دیگر نمیتوان گیاه را نجات داد.",
                    Name = "دورستیا",
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
                    Id = 17,
                    CategoryId = 9,
                    Description ="بن سای فوق یکی از با ارزشترین گیاهان کلکسیونی موجود در ایران میباشد که دارای مقاومت بسیار خوبی در برابر خشکی آب و هوای تهران دارد ، این درخت در حال حاضر کهن ترین در خت این مجموعه می باشد.",
                    Name = "فیکوس انجیری",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 1200000,
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
                    Id = 18,
                    CategoryId = 9,
                    Description ="بن سای های مجموعه ای دارای زیبایی منحصر به فردی میباشند که علاوه برا آن محاسن خوبی برای نگهداری دارا میباشند. این بنسای نیاز به نور متوسط و آبیاری متداوم در طول هفته دارد.",
                    Name = "ساگرسیا",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 2000000,
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
                    Id = 19,
                    CategoryId = 9,
                    Description ="بن سای فوق دارای قدمت بسیار زیادی میباشد و طراحی آن توسط یک استاد مجرب انجام گرفته است.",
                    Name = "سیزیجیوم",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 9000000,
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
                    Id = 20,
                    CategoryId = 9,
                    Description ="بن سای فوق از لحاظ بصری دارای منحصر به فرد ترین و زیباترین نوع برگ در درختان بن سای میباشد ، همچنین سازگاری مناسبی با هوای ایران دارد",
                    Name = "افرا ژاپنی قرمز",
                    IsFreeShipping = true,
                    NotificationStockMinimum = 3,
                    ViewCount = 0,
                    Stock = 10,
                    SellCount = 0,
                    Price = 500000,
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


            var userStore = new UserStore<YuccaUser,YuccaRole,long,YuccaUserLogin,YuccaUserRole,YuccaUserClaim>(context);
            using (var userManager = new UserManager<YuccaUser, long>(userStore))
            {
                var user = userManager.FindByName(email);
                if (user == null)
                {
                    user = new YuccaUser { UserName = email, Email = email, FirstName = firstName, LastName = lastName };
                    userManager.Create(user, password);
                    userManager.SetLockoutEnabled(user.Id, false);
                }

                var rolesForUser = userManager.GetRoles(user.Id);
                if (!rolesForUser.Contains(adminRoleName))
                {
                    userManager.AddToRole(user.Id, adminRoleName);
                }
            }

        }
    }
}
