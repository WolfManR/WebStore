using System;
using System.Collections.Generic;

using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.Data
{
    public static class TestData
    {
        public static IEnumerable<Employee> Employees { get; } = new[]
        {
            new Employee{Id=1,Firstname="Annie",Surname="Davis",AvatarUrl="man-one.jpg",Sex=Sex.Male,Age=32, BirthdayDate=new DateTime(1988,6,2)},
            new Employee{Id=2,Firstname="Janis",Surname="Gallagher",AvatarUrl="man-two.jpg",Sex=Sex.Male,Age=35, BirthdayDate=new DateTime(1985,2,4)},
            new Employee{Id=3,Firstname="Jocombo",Surname="Tanates",AvatarUrl="man-three.jpg",Sex=Sex.Female,Age=25, BirthdayDate=new DateTime(1995,4,7)},
            new Employee{Id=4,Firstname="Kenet",Surname="White",AvatarUrl="man-four.jpg",Sex=Sex.Male,Age=48, BirthdayDate=new DateTime(1971,7,22)},
            new Employee{Id=5,Firstname="Mac",Surname="Doe",AvatarUrl="man-three.jpg",Sex=Sex.Male,Age=28, BirthdayDate=new DateTime(1991,8,16)},
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
        public static IEnumerable<User> Accounts { get; } = new[]
        {
            new User{Id=1,Firstname="Annie",Surname="Davis",AvatarUrl="man-one.jpg",Sex=Sex.Male,Age=32, BirthdayDate=new DateTime(1988,6,2)},
            new User{Id=2,Firstname="Janis",Surname="Gallagher",AvatarUrl="man-two.jpg",Sex=Sex.Male,Age=35, BirthdayDate=new DateTime(1985,2,4)},
            new User{Id=3,Firstname="Jocombo",Surname="Tanates",AvatarUrl="man-three.jpg",Sex=Sex.Female,Age=25, BirthdayDate=new DateTime(1995,4,7)},
            new User{Id=4,Firstname="Kenet",Surname="White",AvatarUrl="man-four.jpg",Sex=Sex.Male,Age=48, BirthdayDate=new DateTime(1971,7,22)},
            new User{Id=5,Firstname="Mac",Surname="Doe",AvatarUrl="man-three.jpg",Sex=Sex.Male,Age=28, BirthdayDate=new DateTime(1991,8,16)},
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
