using Microsoft.AspNetCore.Mvc;
using VetryCuts.Data;
using VetryCuts.Models;

namespace VetriCuts.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly VetriCutsDbContext _context;

        public AppointmentController(VetriCutsDbContext context)
        {
            _context = context;
            bool a = _context.Database.CanConnect();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointments()
        {
            ViewBag.Appointments = _context.Appointments;
            ViewBag.Barbers = _context.Users.Where(u => u.Role == "barber");
            ViewBag.Services = _context.Services;

            return View();
        }

    }
}
