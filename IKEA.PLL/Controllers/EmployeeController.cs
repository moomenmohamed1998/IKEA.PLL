using IKEA.BLL.DTO_s.Department;
using IKEA.BLL.DTO_s.Employees;
using IKEA.BLL.Services.DepartmentsServices;
using IKEA.BLL.Services.EmploessServices;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PLL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Sevices - DI
        private readonly IEmploteeservices emploteeservices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmploteeservices emploteeservices, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {
            this.emploteeservices = emploteeservices;
            this.logger = logger;
            this.environment = environment;
        }
        #endregion
        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var Employees = emploteeservices.GetAllEmpoyees();
            return View(Employees);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id is null)

                return BadRequest();
            var employee = emploteeservices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);

        }


        #endregion

        #region create
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedEmployeeDto EmployeeDto)
        {
            if (!ModelState.IsValid)

                return View(EmployeeDto);

            var Message = string.Empty;
            try
            {

                var result = emploteeservices.createEmployee(EmployeeDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else
                {
                    Message = "Empoloyee is not Created";

                }

            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);

                if (environment.IsDevelopment())
                    Message = ex.Message;
                else
                    Message = "An Error Effect at The creatiion Opertor";


            }
            ModelState.AddModelError(string.Empty, Message);
            return View(EmployeeDto);
            //return View();           
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id is null)
                return BadRequest();
            var Employee = emploteeservices.GetEmployeeById(id.Value);
            if (Employee is null)
                return NotFound();
            var MappedEmployee = new UpdatedEmployeeDto()
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                Address = Employee.Address,
                HiringDate = Employee.HiringDate,
                PhoneNumper = Employee.PhoneNumper,
                Email = Employee.Email,
                Salary = Employee.Salary,
                Gender = Employee.Gender,
                EmployeeType = Employee.EmployeeType,
                IsActive = Employee.IsActive,
            };
            return View(MappedEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return View(employeeDto);
            var Message = string.Empty;
            try
            {
                var result = emploteeservices.UpdateEmployee(employeeDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "employee is not Updated";

                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Update the Employee";

            }
            ModelState.AddModelError(string.Empty, Message);
            return View(employeeDto);
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = emploteeservices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int EmpId)
        {
            var Message = string.Empty;

            try
            {
                var IsDeleted = emploteeservices.DeleteEmployee(EmpId);
                if (IsDeleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Employee is not Deleted";
                   
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Delete the Department";
            }
            ModelState.AddModelError(string.Empty, Message);
            return RedirectToAction(nameof(Delete), new { id = EmpId });
        }
        #endregion
    }
}
