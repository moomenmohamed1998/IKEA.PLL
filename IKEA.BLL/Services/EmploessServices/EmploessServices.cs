using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.DTO_s.Employees;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Repositories.Emplyess;

namespace IKEA.BLL.Services.EmploessServices
{
    public class EmploessServices:IEmploteeservices
    {
        private readonly IEmployeeRepository repository;
        public EmploessServices(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetAllEmpoyees()
        {
            return  repository.GetAll().Where(e => e.IsDeleted == false).Select(e=>new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                IsActive = e.IsActive,
                Email = e.Email,
                Gender=nameof(e.Gender),
                EmployeeType = nameof(e.EmployeeType),
            }).ToList();
        }
       
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = repository.GetById(id);
                if (employee is not null)
            {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    Email = employee.Email,
                    PhoneNumper = employee.PhoneNumper,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    HiringDate = employee.HiringDate,
                    CreatedOn = employee.CreatedOn,
                    LastModifiedBy = employee.LastModifiedBy,
                    LastModifiedon = employee.LastModifiedon
                };
                
            }
            return null;
        }

        public int createEmployee(CreatedEmployeeDto employeeDto)
        {
            
            var Employee = new Employee()


            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                HiringDate = employeeDto.HiringDate,
                PhoneNumper = employeeDto.PhoneNumper,
                CreatedOn = DateTime.Now,
                LastModifiedBy = 1,
                LastModifiedon = DateTime.Now,              
            };
            return repository.Add(Employee);
        }

        public int UpdateDepartment(UpdatedEmployeeDto employeeDto)
        {
            var Employee = new Employee()


            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                HiringDate = employeeDto.HiringDate,
                PhoneNumper = employeeDto.PhoneNumper,
                LastModifiedBy = 1,
                LastModifiedon = DateTime.Now,
            };
            return repository.update(Employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = repository.GetById(id);
            //int result=0;
            if (employee is not null)

                //DeleteDepartment.IsDeleted = true;
                return repository.Delete(employee) > 0;
            else
                return false;
        }




      
    }
}
