using System.Diagnostics;
using LucideIconsDotNet.TestSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace LucideIconsDotNet.TestSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(
            ILogger<HomeController> logger, 
            IWebHostEnvironment env
            )
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var files = _env.WebRootFileProvider.GetDirectoryContents("/lucide-icons");

            var vm = new HomeViewModel();

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.Name);

                if (!extension.Equals(".svg"))
                    continue;

                vm.Icons.Add(new IconViewModel()
                {
                    Name = file.Name.Substring(0,file.Name.Length - 4)
                });
                
            }

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
