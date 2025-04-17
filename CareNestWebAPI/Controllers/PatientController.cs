using Microsoft.AspNetCore.Mvc;

namespace CareNestWebAPI.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
