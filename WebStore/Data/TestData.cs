using System;
using System.Collections.Generic;

using WebStore.Domain.Entities;
using WebStore.Models;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee{Id=1,FirstName="Климент",Surname="Рогов",Patronymic="Игоревич",
                Sex=Sex.Мужской,Age=32,
                BirthdayDate=new System.DateTime(1988,6,28),
                HiredDate=new System.DateTime(1994,4,12)},

            new Employee{Id=2,FirstName="Мария",Surname="Овчинникова",Patronymic="Дмитриевна",
                Sex=Sex.Женский,Age=42,
                BirthdayDate=new System.DateTime(1978,2,24),
                HiredDate=new System.DateTime(1994,4,12)},

            new Employee{Id=3,FirstName="Жанна",Surname="Герасимова",Patronymic="Максимовна",
                Sex=Sex.Женский,Age=22,
                BirthdayDate=new System.DateTime(1998,6,28),
                HiredDate=new System.DateTime(2016,7,7)},

            new Employee{Id=4,FirstName="Клим",Surname="Горбачев",Patronymic="Яковлевич",
                Sex=Sex.Мужской,Age=22,
                BirthdayDate=new System.DateTime(1998,7,12),
                HiredDate=new System.DateTime(2016,7,7)},

            new Employee{Id=5,FirstName="Залина",Surname="Ларионова",Patronymic="Созонова",
                Sex=Sex.Женский,Age=42,
                BirthdayDate=new System.DateTime(1978,2,14),
                HiredDate=new System.DateTime(1994,4,12)},

            new Employee{Id=6,FirstName="Жюли",Surname="Рожкова",Patronymic="Рудольфовна",
                Sex=Sex.Женский,Age=31,
                BirthdayDate=new System.DateTime(1989,6,28),
                HiredDate=new System.DateTime(1998,11,16)},

            new Employee{Id=7,FirstName="Аркадий",Surname="Евдокимов",Patronymic="Агафонович",
                Sex=Sex.Мужской,Age=52,
                BirthdayDate=new System.DateTime(1968,5,14),
                HiredDate=new System.DateTime(1994,4,12)},

            new Employee{Id=8,FirstName="Мальта",Surname="Кабанова",Patronymic="Мэлсовна",
                Sex=Sex.Женский,Age=42,
                BirthdayDate=new System.DateTime(1978,8,26),
                HiredDate=new System.DateTime(1994,4,14)},

            new Employee{Id=9,FirstName="Максим",Surname="Лебедев",Patronymic="Улебович",
                Sex=Sex.Мужской,Age=32,
                BirthdayDate=new System.DateTime(1988,6,23),
                HiredDate=new System.DateTime(1994,4,12)}
        };

        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand { Id = 1, Name = "Acne", Order = 0 },
            new Brand { Id = 2, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 3, Name = "Albiro", Order = 2 },
            new Brand { Id = 4, Name = "Ronhill", Order = 3 },
            new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };

        public static IEnumerable<Section> Sections { get; } = new[]
        {
              new Section { Id = 1, Name = "Спорт", Order = 0 },
              new Section { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
              new Section { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
              new Section { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
              new Section { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
              new Section { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
              new Section { Id = 7, Name = "Для мужчин", Order = 1 },
              new Section { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
              new Section { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
              new Section { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
              new Section { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
              new Section { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
              new Section { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
              new Section { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
              new Section { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
              new Section { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
              new Section { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
              new Section { Id = 18, Name = "Для женщин", Order = 2 },
              new Section { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
              new Section { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
              new Section { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
              new Section { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
              new Section { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
              new Section { Id = 24, Name = "Для детей", Order = 3 },
              new Section { Id = 25, Name = "Мода", Order = 4 },
              new Section { Id = 26, Name = "Для дома", Order = 5 },
              new Section { Id = 27, Name = "Интерьер", Order = 6 },
              new Section { Id = 28, Name = "Одежда", Order = 7 },
              new Section { Id = 29, Name = "Сумки", Order = 8 },
              new Section { Id = 30, Name = "Обувь", Order = 9 },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product { Id = 1, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
            new Product { Id = 2, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
            new Product { Id = 3, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
            new Product { Id = 4, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
            new Product { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
            new Product { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
            new Product { Id = 7, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
            new Product { Id = 8, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
            new Product { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
            new Product { Id = 10, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
            new Product { Id = 11, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
            new Product { Id = 12, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };
        public static IEnumerable<Account> Accounts { get; } = new[]
        {
            new Account{Id=1,FirstName="Annie",Surname="Davis",AvatarUrl="man-one.jpg"},
            new Account{Id=2,FirstName="Janis",Surname="Gallagher",AvatarUrl="man-two.jpg"},
            new Account{Id=3,FirstName="Jocombo",Surname="Tanates",AvatarUrl="man-three.jpg"},
            new Account{Id=5,FirstName="Mac",Surname="Doe",AvatarUrl="man-three.jpg"},
            new Account{Id=4,FirstName="Kenet",Surname="White",AvatarUrl="man-four.jpg"}
        };
        public static IEnumerable<BlogPost> BlogPosts { get; } = new[]
        {
            new BlogPost{
                Id=1,
                AuthorAccountId=5,
                Subject="Girls Pink T Shirt arrived in store",
                RegistrationTime=new DateTime(2013,12,5,13,33,0),
                MainImageUrl="blog-one.jpg",
                ShortDesc="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Tags=new []{ "Pink", "T-Shirt", "Girls" },
                Text=new[]
                {
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                    "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem."
                },
                Comments = new[]
                {
                    new Comment
                    {
                        Id=1,
                        AccountId=1,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                    },
                    new Comment
                    {
                        Id=2,
                        AccountId=2,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    },
                    new Comment
                    {
                        Id=3,
                        AccountId=3,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=2
                    },
                    new Comment
                    {
                        Id=4,
                        AccountId=4,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    }
                }
            },
            new BlogPost{
                Id=2,
                AuthorAccountId=3,
                Subject="Girls Pink T Shirt arrived in store",
                RegistrationTime=new DateTime(2013,12,5,13,33,0),
                MainImageUrl="blog-two.jpg",
                ShortDesc="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Tags=new []{ "Pink", "T-Shirt", "Girls" },
                Text=new[]
                {
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                    "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem."
                },
                Comments = new[]
                {
                    new Comment
                    {
                        Id=1,
                        AccountId=1,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                    },
                    new Comment
                    {
                        Id=2,
                        AccountId=2,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    },
                    new Comment
                    {
                        Id=3,
                        AccountId=3,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=2
                    },
                    new Comment
                    {
                        Id=4,
                        AccountId=4,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    }
                }
            },
            new BlogPost{
                Id=3,
                AuthorAccountId=4,
                Subject="Girls Pink T Shirt arrived in store",
                RegistrationTime=new DateTime(2013,12,5,13,33,0),
                MainImageUrl="blog-three.jpg",
                ShortDesc="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Tags=new []{ "Pink", "T-Shirt", "Girls" },
                Text=new[]
                {
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                    "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem."
                },
                Comments = new[]
                {
                    new Comment
                    {
                        Id=1,
                        AccountId=1,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                    },
                    new Comment
                    {
                        Id=2,
                        AccountId=2,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    },
                    new Comment
                    {
                        Id=3,
                        AccountId=3,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=1
                    },
                    new Comment
                    {
                        Id=4,
                        AccountId=4,
                        Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                        Time=new DateTime(2013,12,5,13,33,0),
                        ParentCommentId=3
                    }
                }
            }
        };
    }
}
