using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryEmployeesDataService : IEmployeesData
    {
        private readonly List<Employee> Employees = TestData.Employees;

        public IEnumerable<Employee> GetAll() => Employees;

        public Employee GetById(int id) => Employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee Employee)
        {
            _ = Employee ?? throw new ArgumentNullException(nameof(Employee));

            if (Employees.Contains(Employee)) return Employee.Id;

            Employee.Id = Employees.Count == 0 ? 1 : Employees.Max(e => e.Id) + 1;
            Employees.Add(Employee);
            return Employee.Id;
        }

        public void Edit(Employee Employee)
        {
            _ = Employee ?? throw new ArgumentNullException(nameof(Employee));

            if (Employees.Contains(Employee)) return;

            var db_item = GetById(Employee.Id);

            db_item.FirstName = Employee.FirstName;
            db_item.Surname = Employee.Surname;
            db_item.Patronymic = Employee.Patronymic;
            db_item.Age = Employee.Age;
        }

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;

            return Employees.Remove(db_item);
        }

        public void SaveChanges() { }
    }
}
