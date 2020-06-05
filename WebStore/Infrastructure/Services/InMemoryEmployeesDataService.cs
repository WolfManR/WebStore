using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryEmployeesDataService : IEmployeesDataService
    {
        private readonly List<Employee> Employees = TestData.Employees;

        public IEnumerable<Employee> GetAll() => Employees;

        public Employee GetById(int id) => Employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee employee)
        {
            _ = employee ?? throw new ArgumentNullException(nameof(employee));

            if (Employees.Contains(employee)) return employee.Id;

            employee.Id = Employees.Count == 0 ? 1 : Employees.Max(e => e.Id) + 1;
            Employees.Add(employee);
            return employee.Id;
        }

        public void Edit(Employee employee)
        {
            _ = employee ?? throw new ArgumentNullException(nameof(employee));

            if (Employees.Contains(employee)) return;

            var db_item = GetById(employee.Id);

            db_item.FirstName = employee.FirstName;
            db_item.Surname = employee.Surname;
            db_item.Patronymic = employee.Patronymic;
            db_item.Age = employee.Age;
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
