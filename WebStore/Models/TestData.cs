using System.Collections.Generic;

namespace WebStore.Models
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
    }
}
