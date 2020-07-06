using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
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
        private readonly ILogger<EmployeesClient> logger;
        public EmployeesClient(IConfiguration configuration, ILogger<EmployeesClient> logger) : base(configuration, WebApiAddresses.Employees) => this.logger = logger;


        public IEnumerable<Employee> GetAll() => Get<IEnumerable<Employee>>(ServiceAddress);

        public Employee GetById(int id) => Get<Employee>($"{ServiceAddress}/{id}");


        public int Add(Employee employee)
        {
            try
            {
                logger.LogInformation("Request to {0} to edit employee id: {1}", ServiceAddress, employee.Id);
                return Post(ServiceAddress, employee).Content.ReadAsAsync<int>().Result;
            }
            catch (Exception ex)
            {
                logger.LogError("An error occurred while executing a request to {0} for editing an employee {1}: {2}", ServiceAddress, employee.Id, ex);
                throw new InvalidOperationException($"Error executing request to {ServiceAddress} to edit employee {employee.Id}", ex); ;
            }
            
        }

        public void Edit(Employee employee) => Put(ServiceAddress, employee);

        public bool Delete(int id) => Delete($"{ServiceAddress}/{id}").IsSuccessStatusCode;

        public void SaveChanges() { }
    }
}