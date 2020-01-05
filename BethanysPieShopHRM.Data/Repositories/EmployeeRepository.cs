using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _appDbContext.Employees
                .Include(x => x.Address)
                .Include(x => x.Contact)
                .Include(x => x.JobCategory)
                .FirstOrDefault(c => c.EmployeeId == employeeId);
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.BirthDate = employee.BirthDate;
                foundEmployee.Smoker = employee.Smoker;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.Comment = employee.Comment;
                foundEmployee.ExitDate = employee.ExitDate;
                foundEmployee.JoinedDate = employee.JoinedDate;
                foundEmployee.Gender = employee.Gender;

                // Address
                foundEmployee.Address.City = employee.Address.City;
                foundEmployee.Address.Street = employee.Address.Street;
                foundEmployee.Address.Zip = employee.Address.Zip;
                foundEmployee.Address.Country = employee.Address.Country;
                foundEmployee.Address.Latitude = employee.Address.Latitude;
                foundEmployee.Address.Longitude = employee.Address.Longitude;
                
                // Contact
                foundEmployee.Contact.PhoneNumber = employee.Contact.PhoneNumber;
                foundEmployee.Contact.EmergencyName = employee.Contact.EmergencyName;
                foundEmployee.Contact.EmergencyPhoneNumber = employee.Contact.EmergencyPhoneNumber;
                foundEmployee.Contact.Email = employee.Contact.Email;

                _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
