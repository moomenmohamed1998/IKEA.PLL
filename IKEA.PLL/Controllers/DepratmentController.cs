using IKEA.BLL.DTO_s.Department;
using IKEA.BLL.Services.DepartmentsServices;
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
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)

                return View(departmentDto);
            var Message = string.Empty;
            try
            {

                var result = departmentsServices.CreateDepartment(departmentDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else
                {
                    Message = "Department is not Created";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);
                }

            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);

                if (environment.IsDevelopment())
                {
                    Message = ex.Message;
                    return View(departmentDto);
                }
                else
                {
                    Message = "An Error Effect at The creatiion Opertor";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);
                }

            }
            //return View();           
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
            var MappedDepartment = new UpdatedDepartmentDto()
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
        public IActionResult Edit(UpdatedDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return View(departmentDto);
            var Message = string.Empty;
            try
            {
                var result = departmentsServices.UpdateDepartment(departmentDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Department is not Updated";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Update the Department";
                
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(departmentDto);
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
