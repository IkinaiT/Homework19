using Homework19.Models;
using Homework19.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework19.Controllers
{
    public class HomeController(IDatabaseService databaseService, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IDatabaseService _databaseService = databaseService;

        public IActionResult Index()
        {
            return View(_databaseService.GetContacts());
        }

        [HttpGet ("ErrorPage")]
        public IActionResult ErrorPage()
        {
            object result = "Непредвиденная ошибка! Вернитесь на главную страницу и повторите попытку!";
            return View(result);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet ("Details/{id}")]
        public IActionResult Details([FromRoute] int id)
        {
            return View(_databaseService.GetContact(id));
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _databaseService.DeleteContact(id);
            if (result)
                return Redirect("/");

            return Redirect("~/ErrorPage");
        }

        [HttpPost("Add")]
        public IActionResult Add(Contact contact)
        {
            var result = _databaseService.AddContact(contact);
            if (result)
                return Redirect("/");

            return Redirect("~/ErrorPage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
