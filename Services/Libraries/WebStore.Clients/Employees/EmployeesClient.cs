using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Net.Http;

using WebStore.Clients.Base;
using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IRepo<Employee>
    {
        public EmployeesClient(IConfiguration configuration) : base(configuration, WebApiAddresses.Employees) { }


        public IEnumerable<Employee> GetAll() => Get<IEnumerable<Employee>>(ServiceAddress);

        public Employee GetById(int id) => Get<Employee>($"{ServiceAddress}/{id}");


        public int Add(Employee employee) => Post(ServiceAddress, employee).Content.ReadAsAsync<int>().Result;

        public void Edit(Employee employee) => Put(ServiceAddress, employee);

        public bool Delete(int id) => Delete($"{ServiceAddress}/{id}").IsSuccessStatusCode;

        public void SaveChanges() { }
    }
}