using System;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        public Sex Sex { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
