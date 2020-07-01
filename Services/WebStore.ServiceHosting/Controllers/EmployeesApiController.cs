using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>
    /// Employees controller
    /// </summary>
    [Route(WebApiAddresses.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IRepo<Employee>
    {
        private readonly IRepo<Employee> employeesRepo;
        /// <summary>
        /// Employees Ctor
        /// </summary>
        /// <param name="employeesDataService">Employees Data Service</param>
        public EmployeesApiController(IRepo<Employee> employeesDataService) => employeesRepo = employeesDataService;

        /// <summary>
        /// Return all employees
        /// </summary>
        /// <returns>all employees</returns>
        [HttpGet]
        public IEnumerable<Employee> GetAll() => employeesRepo.GetAll();

        /// <summary>
        /// Return Employee by its Id
        /// </summary>
        /// <param name="id">Id of Employee record</param>
        /// <returns>Employee</returns>
        [HttpGet("{id}")]
        public Employee GetById(int id) => employeesRepo.GetById(id);

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="entity">Employee</param>
        /// <returns>must return Id of new entity</returns>
        [HttpPost]
        public int Add([FromBody] Employee entity)
        {
            var id = employeesRepo.Add(entity);
            SaveChanges();
            return id;
        }

        /// <summary>
        /// Edit Employee info
        /// </summary>
        /// <param name="entity">Employee</param>
        [HttpPut]
        public void Edit(Employee entity)
        {
            employeesRepo.Edit(entity);
            SaveChanges();
        }

        /// <summary>
        /// Delete Employee entity
        /// </summary>
        /// <param name="id">Id of Employee record</param>
        /// <returns>success of operation</returns>
        [HttpDelete]
        public bool Delete(int id)
        {
            var success = employeesRepo.Delete(id);
            SaveChanges();
            return success;
        }

        [NonAction]
        public void SaveChanges() => employeesRepo.SaveChanges();
    }
}
