using System.Collections.Generic;

namespace WebStore.Models
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee{Id=1,FirstName="Климент",Surname="Рогов",Patronymic="Игоревич",
                Sex=Sex.Male,Age=32, BirthdayDate=new System.DateTime(28,6,1988),HiredDate=new System.DateTime(12,4,1994)},

            new Employee{Id=2,FirstName="Мария",Surname="Овчинникова",Patronymic="Дмитриевна",
                Sex=Sex.Female,Age=42, BirthdayDate=new System.DateTime(24,2,1978),HiredDate=new System.DateTime(12,4,1994)},

            new Employee{Id=3,FirstName="Жанна",Surname="Герасимова",Patronymic="Максимовна",
                Sex=Sex.Female,Age=22, BirthdayDate=new System.DateTime(28,6,1998),HiredDate=new System.DateTime(7,7,2016)},

            new Employee{Id=4,FirstName="Клим",Surname="Горбачев",Patronymic="Яковлевич",
                Sex=Sex.Male,Age=22, BirthdayDate=new System.DateTime(12,7,1998),HiredDate=new System.DateTime(7,7,2016)},

            new Employee{Id=5,FirstName="Залина",Surname="Ларионова",Patronymic="Созонова",
                Sex=Sex.Female,Age=42, BirthdayDate=new System.DateTime(14,2,1978),HiredDate=new System.DateTime(12,4,1994)},

            new Employee{Id=6,FirstName="Жюли",Surname="Рожкова",Patronymic="Рудольфовна",
                Sex=Sex.Female,Age=31, BirthdayDate=new System.DateTime(28,6,1989),HiredDate=new System.DateTime(16,11,1998)},

            new Employee{Id=7,FirstName="Аркадий",Surname="Евдокимов",Patronymic="Агафонович",
                Sex=Sex.Male,Age=52, BirthdayDate=new System.DateTime(14,5,1968),HiredDate=new System.DateTime(12,4,1994)},

            new Employee{Id=8,FirstName="Мальта",Surname="Кабанова",Patronymic="Мэлсовна",
                Sex=Sex.Female,Age=42, BirthdayDate=new System.DateTime(26,8,1978),HiredDate=new System.DateTime(14,4,1994)},

            new Employee{Id=9,FirstName="Максим",Surname="Лебедев",Patronymic="Улебович",
                Sex=Sex.Male,Age=32, BirthdayDate=new System.DateTime(23,6,1988),HiredDate=new System.DateTime(12,4,1994)}
        };
    }
}
