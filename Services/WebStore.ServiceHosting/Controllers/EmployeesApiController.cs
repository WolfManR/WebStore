using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using WebStore.Domain.Entities;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebApiAddresses.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IRepo<Employee>
    {
        private readonly IRepo<Employee> employeesRepo;

        public EmployeesApiController(IRepo<Employee> employeesDataService) => employeesRepo = employeesDataService;

        [HttpGet]
        public IEnumerable<Employee> GetAll() => employeesRepo.GetAll();

        [HttpGet("{id}")]
        public Employee GetById(int id) => employeesRepo.GetById(id);


        [HttpPost]
        public int Add([FromBody] Employee entity)
        {
            var id = employeesRepo.Add(entity);
            SaveChanges();
            return id;
        }

        [HttpPut]
        public void Edit(Employee entity)
        {
            employeesRepo.Edit(entity);
            SaveChanges();
        }

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
