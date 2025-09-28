using Employee_API_JWT.Identity;
using Employee_API_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_API_JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEmployee([FromBody]Employee employee)
        {
            if (employee == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            if(employeeInDb == null) return NotFound();
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}
