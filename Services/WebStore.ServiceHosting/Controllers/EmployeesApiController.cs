using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<EmployeesApiController> logger;

        /// <summary>
        /// Employees Ctor
        /// </summary>
        /// <param name="employeesDataService">Employees Data Service</param>
        /// <param name="logger">Logger</param>
        public EmployeesApiController(IRepo<Employee> employeesDataService, ILogger<EmployeesApiController> logger)
        {
            employeesRepo = employeesDataService;
            this.logger = logger;
        }

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
            logger.LogInformation("Adding a new employee: [{0}]{1} {2} {3}", entity.Id, entity.Surname, entity.Firstname);

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
            logger.LogInformation("Editing employee: [{0}]{1} {2} {3}", entity.Id, entity.Surname, entity.Firstname);

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
            logger.LogInformation("Removing employee id: {0}", id);

            var success = employeesRepo.Delete(id);
            SaveChanges();
            return success;
        }

        [NonAction]
        public void SaveChanges() => employeesRepo.SaveChanges();
    }
}
