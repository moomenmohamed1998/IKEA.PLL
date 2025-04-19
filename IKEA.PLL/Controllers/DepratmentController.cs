using IKEA.BLL.DTO_s.Department;
using IKEA.BLL.Services.DepartmentsServices;
using IKEA.PLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PLL.Controllers
{
    public class DepratmentController : Controller
    {
        #region Services

        private readonly IDepartmentsServices departmentsServices;
        private readonly ILogger<DepratmentController> logger;
        private readonly IWebHostEnvironment environment;

        public DepratmentController(IDepartmentsServices _departmentsServices, ILogger<DepratmentController> _logger, IWebHostEnvironment environment)
        {
            departmentsServices = _departmentsServices;
            logger = _logger;
            this.environment = environment;
        } 
        #endregion

        #region Index


        [HttpGet]
        public IActionResult Index()
        {
            var Departments = departmentsServices.GetALLDepartments();
            return View(Departments);

        }

        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id is null)

                return BadRequest();
            var department = departmentsServices.GetALLDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);

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
        public IActionResult Create(DepartmentVM departmentVM)
        {
            if (!ModelState.IsValid)

                return View(departmentVM);
            var Message = string.Empty;
            try
            {
                var DepartmentDto = new CreateDepartmentDto()
                {
                    Name = departmentVM.Name,
                    Code = departmentVM.Code,
                    CreationDate = departmentVM.CreationDate,
                    Description = departmentVM.Description,
                };
                var result = departmentsServices.CreateDepartment(DepartmentDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else

                    Message = "Department is not Created";



            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);

                if (environment.IsDevelopment())
                {
                    Message = ex.Message;
                }
                else

                    Message = "An Error Effect at The creatiion Opertor";


            }
            ModelState.AddModelError(string.Empty, Message);
            return View(departmentVM);
                }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id is null)
                return BadRequest();
            var department = departmentsServices.GetALLDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            var MappedDepartment = new DepartmentVM()
            {
                id = department.id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate
            };
            return View(MappedDepartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentVM departmentVM)
        {
            if (!ModelState.IsValid)
                return View(departmentVM);
            var Message = string.Empty;
            try
            {
                var DepartmentDto = new UpdatedDepartmentDto()
                {
                    id=departmentVM.id,
                    Name = departmentVM.Name,
                    Code = departmentVM.Code,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate,
                };

                var result = departmentsServices.UpdateDepartment(DepartmentDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Department is not Updated";
                   
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Update the Department";
                
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(departmentVM);
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = departmentsServices.GetALLDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int DeptId)
        {
            var Message = string.Empty;

            try
            {
                var IsDeleted = departmentsServices.DeleteDepartment(DeptId);
                if (IsDeleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Department is not Deleted";
                    //ModelState.AddModelError(string.Empty, Message);
                    //return View();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Delete the Department";
            }
            ModelState.AddModelError(string.Empty, Message);
            return RedirectToAction(nameof(Delete),new {id=DeptId});
        }
        #endregion

    }
}
