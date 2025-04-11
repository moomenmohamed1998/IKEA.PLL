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
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
