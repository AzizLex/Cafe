using Cafe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cafe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<About> About { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuSubCat> MenuSubCats { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueImage> VenueImages { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ExtraService> ExtraServices { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<BookingForm> BookingForms { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e452e-3b0e-446f-86af-483d56fd7210",
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                });

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e973922-a44d-4543-a6c6-9814d048cdb9",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    UserName = "admin",
                    Email = "e@mail.com",
                    NormalizedEmail = "E@MAIL.COM",
                    NormalizedUserName = "ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "password"),
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e452e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e973922-a44d-4543-a6c6-9814d048cdb9"
                });

            modelBuilder.Entity<Option>().HasData(
                new Option { Id = 1, Key = "_address", Value = "Street, Zip, City" },
                new Option { Id = 2, Key = "_phone", Value = "Phone" },
                new Option { Id = 3, Key = "_email", Value = "e@mail.com" },
                new Option { Id = 4, Key = "_opening1", Value = "Sön-Tor: 17:00-01:00" },
                new Option { Id = 5, Key = "_opening2", Value = "Fre-Lör: 17:00-02:00" },
                new Option { Id = 6, Key = "homeSlide", Value = "https://picsum.photos/id/100/2500/1656.jpg" },
                new Option { Id = 7, Key = "homeSlide", Value = "https://picsum.photos/id/1002/4312/2868.jpg" },
                new Option { Id = 8, Key = "homeSlide", Value = "https://picsum.photos/id/1016/3844/2563.jpg" },
                new Option { Id = 9, Key = "homeSlide", Value = "https://picsum.photos/id/102/4320/3240.jpg" },
                new Option { Id = 10, Key = "homeSlide", Value = "https://picsum.photos/id/1020/4288/2848.jpg" },
                new Option { Id = 11, Key = "venueSlide", Value = "https://picsum.photos/id/1022/6000/3376.jpg" },
                new Option { Id = 12, Key = "venueSlide", Value = "https://picsum.photos/id/1021/2048/1206.jpg" },
                new Option { Id = 13, Key = "venueSlide", Value = "https://picsum.photos/id/1031/5446/3063.jpg" },
                new Option { Id = 14, Key = "venueSlide", Value = "https://picsum.photos/id/1029/4887/2759.jpg" },
                new Option { Id = 15, Key = "venueSlide", Value = "https://picsum.photos/id/1033/2048/1365.jpg" }
                );

            modelBuilder.Entity<MenuCategory>().HasData(
                new MenuCategory { Id = 1, Name = "Förrätter" },
                new MenuCategory { Id = 2, Name = "Huvudrätter" },
                new MenuCategory { Id = 3, Name = "Drycker" },
                new MenuCategory { Id = 4, Name = "Efterrätter" }
                );

            modelBuilder.Entity<MenuSubCat>().HasData(
                new MenuSubCat { Id = 1, MenuCategoryId = 1, Name = "Varm meza", URL = "/image/menu/VarmMeza.jpg" },
                new MenuSubCat { Id = 2, MenuCategoryId = 1, Name = "Kall meza", URL = "/image/menu/KallMeza.jpg" },
                new MenuSubCat { Id = 3, MenuCategoryId = 2, Name = "Sallad och kyckling", URL = "/image/menu/SalladOchKyckling.jpg" },
                new MenuSubCat { Id = 4, MenuCategoryId = 2, Name = "Burgare och pizza", URL = "/image/menu/BurgareOchPizza.jpg" },
                new MenuSubCat { Id = 5, MenuCategoryId = 3, Name = "Färsk juice", URL = "/image/menu/FreshJuice.jpg" },
                new MenuSubCat { Id = 6, MenuCategoryId = 3, Name = "Kalla drycker", URL = "/image/menu/KallaDrycker.jpg" },
                new MenuSubCat { Id = 7, MenuCategoryId = 3, Name = "Varma drycker", URL = "/image/menu/VarmaDrycker.jpg" },
                new MenuSubCat { Id = 8, MenuCategoryId = 4, Name = "Tårtor", URL = "/image/menu/Tartor.jpg" }
                );

            modelBuilder.Entity<MenuItem>().HasData(
                //Varm meza
                new MenuItem { Id = 101, MenuSubCatId = 1, Name = "Kycklingvingar", Description = "Kycklingkryddor och salt.", Price = 45, URL = "/image/menu/kycklingvingar.jpg" },
                new MenuItem { Id = 102, MenuSubCatId = 1, Name = "Kubba Tarabulsi", Description = "Bulgur, köttfärs, röd paprika, blandade kryddor, salt, lök, morot, persilja.", Price = 65, URL = "/image/menu/kibbeh.jpg" },
                new MenuItem { Id = 103, MenuSubCatId = 1, Name = "Mozzarella chips", Description = "Mozzarella.", Price = 73, URL = "/image/menu/mozzarella-sticks.jpg" },
                new MenuItem { Id = 104, MenuSubCatId = 1, Name = "Chili cheese", Description = "Chili cheese 6st.", Price = 73, URL = "/image/menu/chili-cheese.jpg" },
                new MenuItem { Id = 105, MenuSubCatId = 1, Name = "Pommes", Description = "Pommes.", Price = 73, URL = "/image/menu/french-fries.jpg" },
                new MenuItem { Id = 106, MenuSubCatId = 1, Name = "Kycklinglever (Sauda Djaj)", Description = "Kycklinglever (Sauda Djaj).", Price = 73, URL = "/image/menu/chicken-liver.jpg" },
                new MenuItem { Id = 107, MenuSubCatId = 1, Name = "Lökringar", Description = "Lökringar 8st.", Price = 73, URL = "/image/menu/lokringar.jpg" },
                new MenuItem { Id = 108, MenuSubCatId = 1, Name = "Ostrullar", Description = "Ostrullar 6st.", Price = 73, URL = "/image/menu/ostrullar.jpg" },
                //Kall meza
                new MenuItem { Id = 201, MenuSubCatId = 2, Name = "Tabouleh", Description = "Persilja, färska tomater, lök, olivolja, bulgurvete, pressad citron och kryddor.", Price = 45, URL = "/image/menu/tabbouleh-salad.jpg" },
                new MenuItem { Id = 202, MenuSubCatId = 2, Name = "Fatoush", Description = "Gurka, tomater, rödlök, rädisor, persilja, mynta, olivolja, citron, sumak, salt.", Price = 65, URL = "/image/menu/fatoush.jpg" },
                new MenuItem { Id = 203, MenuSubCatId = 2, Name = "Muhammara", Description = "Valnötter, paprika, ströbröd, vitlök, spiskummin, chili, granatäppelsirap, olivolja, citronsaft, kryddor.", Price = 73, URL = "/image/menu/muhammara.jpg" },
                new MenuItem { Id = 204, MenuSubCatId = 2, Name = "Baba ghanoush (Matbal)", Description = "Aubergin, tahini, vitlök, citronjuice, salt.", Price = 73, URL = "/image/menu/baba-ghanoush.jpg" },
                new MenuItem { Id = 205, MenuSubCatId = 2, Name = "Tzatziki", Description = "Gurka, yoghurt, vitlök, salt, svartpeppar.", Price = 73, URL = "/image/menu/tzatziki.jpg" },
                new MenuItem { Id = 206, MenuSubCatId = 2, Name = "Grekisk sallad", Description = "Gurka, rödlök, tomater, vitost, oregano, oliver, olivolja, rödvinsvinäger, svartpeppar.", Price = 73, URL = "/image/menu/grekisk-sallad.jpg" },
                new MenuItem { Id = 207, MenuSubCatId = 2, Name = "Chips", Description = "Chips.", Price = 73, URL = "/image/menu/chips.jpg" },
                new MenuItem { Id = 208, MenuSubCatId = 2, Name = "Nötter", Description = "Nötter.", Price = 73, URL = "/image/menu/nuts.jpg" },
                new MenuItem { Id = 209, MenuSubCatId = 2, Name = "Hummus Beiruti", Description = "Kikärtor, tahini, citronjuice, vitlök, olivolja, kummin, persilja, peppar, chili, salt.", Price = 73, URL = "/image/menu/hummus.jpg" },
                new MenuItem { Id = 210, MenuSubCatId = 2, Name = "Sallad Olivier", Description = "Kyckling, potatis, saltgurka, gröna ärtor, lök, majonnäs, ägg, oliver, persilja.", Price = 73, URL = "/image/menu/olivier-sallad.jpg" },
                new MenuItem { Id = 211, MenuSubCatId = 2, Name = "Labneh", Description = "Labneh.", Price = 73, URL = "/image/menu/labneh.jpg" },
                new MenuItem { Id = 212, MenuSubCatId = 2, Name = "Fetaost", Description = "Fetaost.", Price = 73, URL = "/image/menu/feta.jpg" },
                //Sallad och kyckling
                new MenuItem { Id = 301, MenuSubCatId = 3, Name = "Pastasallad", Description = "Pasta, olivolja, mozzarella, soltorkade tomater, paprika, rödlök, rucola, salt, svartpeppar.", Price = 120, URL = "/image/menu/pastasallad.jpg" },
                new MenuItem { Id = 302, MenuSubCatId = 3, Name = "Kycklingspett", Description = "Kycklingfilé, olivolja, soja, vinäger, tomatpuré, vitlök.", Price = 135, URL = "/image/menu/kycklingspett.jpg" },
                new MenuItem { Id = 303, MenuSubCatId = 3, Name = "Kyckling Crispy", Description = "Kyckling Crispy (med pommes).", Price = 255, URL = "/image/menu/kyckling-crispy.jpg" },
                new MenuItem { Id = 304, MenuSubCatId = 3, Name = "Kyckling Shawarma", Description = "Kyckling Shawarma (med pommes eller ris).", Price = 255, URL = "/image/menu/shawarma.jpg" },
                new MenuItem { Id = 305, MenuSubCatId = 3, Name = "Halv kyckling", Description = "Halv kyckling (med pommes eller ris).", Price = 255, URL = "/image/menu/halv-kyckling.jpg" },
                //Burgare och pizza
                new MenuItem { Id = 401, MenuSubCatId = 4, Name = "Hamburgare", Description = "Hamburgare 150gr (med pommes).", Price = 120, URL = "/image/menu/burgare-pommes.jpg" },
                new MenuItem { Id = 402, MenuSubCatId = 4, Name = "Quzy med ris", Description = "Quzy med ris.", Price = 135, URL = "/image/menu/quzy.jpg" },
                new MenuItem { Id = 403, MenuSubCatId = 4, Name = "Falafeltallrik", Description = "Falafeltallrik.", Price = 255, URL = "/image/menu/falafel.jpg" },
                new MenuItem { Id = 404, MenuSubCatId = 4, Name = "Kebabpizza", Description = "Kebabpizza.", Price = 255, URL = "/image/menu/kebab-pizza.jpg" },
                new MenuItem { Id = 405, MenuSubCatId = 4, Name = "Kycklingpizza", Description = "Kycklingpizza.", Price = 255, URL = "/image/menu/kyckling-pizza.jpg" },
                new MenuItem { Id = 406, MenuSubCatId = 4, Name = "Havanapizza", Description = "Havanapizza.", Price = 255, URL = "/image/menu/havana-pizza.jpg" },
                new MenuItem { Id = 407, MenuSubCatId = 4, Name = "Kebabtallrik", Description = "Kebabtallrik (med pommes).", Price = 255, URL = "/image/menu/kebab-fries4.jpg" },
                //Fresh juice
                new MenuItem { Id = 501, MenuSubCatId = 5, Name = "Mango", Description = "Mango.", Price = 120, URL = "/image/menu/Mango2.jpg" },
                new MenuItem { Id = 502, MenuSubCatId = 5, Name = "Banan", Description = "Banan.", Price = 135, URL = "/image/menu/banana.jpg" },
                new MenuItem { Id = 503, MenuSubCatId = 5, Name = "Hallon", Description = "Hallon.", Price = 255, URL = "/image/menu/hallon.jpg" },
                new MenuItem { Id = 504, MenuSubCatId = 5, Name = "Jordgubb", Description = "Jordgubb.", Price = 120, URL = "/image/menu/jordgubb.jpg" },
                new MenuItem { Id = 505, MenuSubCatId = 5, Name = "Apelsin", Description = "Apelsin.", Price = 135, URL = "/image/menu/apelsin.jpg" },
                new MenuItem { Id = 506, MenuSubCatId = 5, Name = "Havana (cocktail)", Description = "Havana (cocktail).", Price = 255, URL = "/image/menu/havana.jpg" },
                //Kalla drycker
                new MenuItem { Id = 601, MenuSubCatId = 6, Name = "Pepsi", Description = "Pepsi.", Price = 120, URL = "/image/menu/pepsi.jpg" },
                new MenuItem { Id = 602, MenuSubCatId = 6, Name = "Fanta", Description = "Fanta.", Price = 135, URL = "/image/menu/fanta.jpg" },
                new MenuItem { Id = 603, MenuSubCatId = 6, Name = "Powerking", Description = "Powerking.", Price = 255, URL = "/image/menu/powerking.jpg" },
                new MenuItem { Id = 604, MenuSubCatId = 6, Name = "Lemon", Description = "Lemon.", Price = 135, URL = "/image/menu/lemon.jpg" },
                new MenuItem { Id = 605, MenuSubCatId = 6, Name = "Ayran", Description = "Ayran.", Price = 255, URL = "/image/menu/ayran.jpg" },
                //Varma drycker
                new MenuItem { Id = 701, MenuSubCatId = 7, Name = "Tea", Description = "Tea.", Price = 120, URL = "/image/menu/Tea.jpg" },
                new MenuItem { Id = 702, MenuSubCatId = 7, Name = "Kaffe", Description = "Kaffe.", Price = 135, URL = "/image/menu/Kaffe.jpg" },
                new MenuItem { Id = 703, MenuSubCatId = 7, Name = "Cappuccino", Description = "Cappuccino.", Price = 255, URL = "/image/menu/Cappuccino.jpg" },
                //Tårtor
                new MenuItem { Id = 801, MenuSubCatId = 8, Name = "Kunafa", Description = "Kunafa.", Price = 120, URL = "/image/menu/Kunafa.jpg" },
                new MenuItem { Id = 802, MenuSubCatId = 8, Name = "Chokladtårta", Description = "Chokladtårta.", Price = 135, URL = "/image/menu/chokladtarta.jpg" },
                new MenuItem { Id = 803, MenuSubCatId = 8, Name = "Daimtårta", Description = "Daimtårta.", Price = 255, URL = "/image/menu/daimtarta.jpg" }
                );

            modelBuilder.Entity<Venue>().HasData(
                new Venue { Id = 1, Name = "Sal 1", Area = "Area", Guests = "Gäster", Table = "Bord", Equipment = "Utrustning", Other = "Övrigt", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan.", Price = 0 },
                new Venue { Id = 2, Name = "Sal 2", Area = "Area", Guests = "Gäster", Table = "Bord", Equipment = "Utrustning", Other = "Övrigt", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan.", Price = 0 }
                );

            modelBuilder.Entity<VenueImage>().HasData(
                new VenueImage { Id = 1, VenueId = 1, URL = "https://picsum.photos/id/1060/5598/3732.jpg" },
                new VenueImage { Id = 2, VenueId = 1, URL = "https://picsum.photos/id/1059/7360/4912.jpg" },
                new VenueImage { Id = 3, VenueId = 1, URL = "https://picsum.photos/id/1068/7117/4090.jpg" },
                new VenueImage { Id = 4, VenueId = 1, URL = "https://picsum.photos/id/113/4168/2464.jpg" },
                new VenueImage { Id = 5, VenueId = 2, URL = "https://picsum.photos/id/117/1544/1024.jpg" },
                new VenueImage { Id = 6, VenueId = 2, URL = "https://picsum.photos/id/119/3264/2176.jpg" }
                );

            modelBuilder.Entity<ExtraService>().HasData(
                new ExtraService { Id = 1, Name = "Dekoration", Price = 0 },
                new ExtraService { Id = 2, Name = "Städning", Price = 0 },
                new ExtraService { Id = 3, Name = "Utkörning", Price = 0 }
                );

            modelBuilder.Entity<Gallery>().HasData(
                new Gallery { Id = 1, Name = "Galleri1", Description = "" },
                new Gallery { Id = 2, Name = "Galleri2", Description = "" }
                );

            modelBuilder.Entity<GalleryImage>().HasData(

                new GalleryImage { Id = 1, GalleryId = 1, TimeStamp = Convert.ToDateTime("2022-09-19 00:00:00"), URL = "https://picsum.photos/id/1060/5598/3732.jpg", Description = "" },
                new GalleryImage { Id = 2, GalleryId = 1, TimeStamp = Convert.ToDateTime("2022-09-19 00:00:00"), URL = "https://picsum.photos/id/1059/7360/4912.jpg", Description = "" },
                new GalleryImage { Id = 3, GalleryId = 1, TimeStamp = Convert.ToDateTime("2022-09-19 00:00:00"), URL = "https://picsum.photos/id/1068/7117/4090.jpg", Description = "" },
                new GalleryImage { Id = 4, GalleryId = 2, TimeStamp = Convert.ToDateTime("2022-09-06 00:00:00"), URL = "https://picsum.photos/id/113/4168/2464.jpg", Description = "" },
                new GalleryImage { Id = 5, GalleryId = 2, TimeStamp = Convert.ToDateTime("2022-09-06 00:00:00"), URL = "https://picsum.photos/id/117/1544/1024.jpg", Description = "" }

                );

            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    Name = "Om  Café",
                    Motto = "Motto",
                    URL = "https://picsum.photos/id/1060/5598/3732.jpg",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan. Vivamus purus dui, porta eget blandit consequat, semper sed nulla. Morbi suscipit dolor sem, placerat congue sem fermentum eu. Nam mi nulla, ullamcorper et enim non, maximus cursus nunc. Nunc suscipit gravida varius. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Quisque metus dui, malesuada vitae libero sit amet, ullamcorper blandit risus. Nam vitae est tincidunt, luctus risus sed, lobortis turpis. Sed in dictum orci. Nullam sed neque nec lacus ultrices fringilla quis eu nibh. Duis tempor mauris eu sem egestas lobortis. Vivamus pellentesque sapien non orci facilisis, in accumsan lorem porttitor. Aliquam erat volutpat. In a scelerisque eros. Ut sit amet ante massa. Nulla turpis metus, tincidunt eget tortor sit amet, euismod venenatis lorem. Duis libero ipsum, mattis vel quam eget, porta iaculis justo. Proin nulla lacus, mollis vitae malesuada quis, pulvinar eget risus. Curabitur euismod elit tristique, commodo enim at, facilisis est.

Integer tincidunt dapibus lorem, nec varius lorem sodales quis. Curabitur nec nulla tempor, molestie augue a, dignissim nunc. Aenean pretium volutpat urna, id varius mi laoreet sit amet. Donec mi lacus, mollis et turpis ac, fringilla cursus orci. Mauris vestibulum lectus consequat ligula ultrices, eu elementum turpis imperdiet. Mauris sed condimentum ligula, non ornare quam. Curabitur laoreet nunc non odio euismod, eu ultrices quam laoreet. Morbi at faucibus neque"
                });

            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    Id = 1,
                    Name = "Integritetspolicy",
                    Lead = "Lead",
                    CreateDate = Convert.ToDateTime("2022-09-01"),
                    EditDate = Convert.ToDateTime("2022-09-01"),
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mi tellus, volutpat sit amet efficitur id, venenatis et metus. Mauris laoreet eros eget est consequat, ut rhoncus tortor accumsan. Vivamus purus dui, porta eget blandit consequat, semper sed nulla. Morbi suscipit dolor sem, placerat congue sem fermentum eu. Nam mi nulla, ullamcorper et enim non, maximus cursus nunc. Nunc suscipit gravida varius. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Quisque metus dui, malesuada vitae libero sit amet, ullamcorper blandit risus. Nam vitae est tincidunt, luctus risus sed, lobortis turpis. Sed in dictum orci. Nullam sed neque nec lacus ultrices fringilla quis eu nibh. Duis tempor mauris eu sem egestas lobortis. Vivamus pellentesque sapien non orci facilisis, in accumsan lorem porttitor. Aliquam erat volutpat. In a scelerisque eros. Ut sit amet ante massa. Nulla turpis metus, tincidunt eget tortor sit amet, euismod venenatis lorem. Duis libero ipsum, mattis vel quam eget, porta iaculis justo. Proin nulla lacus, mollis vitae malesuada quis, pulvinar eget risus. Curabitur euismod elit tristique, commodo enim at, facilisis est.

Integer tincidunt dapibus lorem, nec varius lorem sodales quis. Curabitur nec nulla tempor, molestie augue a, dignissim nunc. Aenean pretium volutpat urna, id varius mi laoreet sit amet. Donec mi lacus, mollis et turpis ac, fringilla cursus orci. Mauris vestibulum lectus consequat ligula ultrices, eu elementum turpis imperdiet. Mauris sed condimentum ligula, non ornare quam. Curabitur laoreet nunc non odio euismod, eu ultrices quam laoreet. Morbi at faucibus neque"
                });

        }
    }
}