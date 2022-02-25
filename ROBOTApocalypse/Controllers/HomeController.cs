using Microsoft.AspNetCore.Mvc;
using ROBOTApocalypse.Common;
using ROBOTApocalypse.Entity;
using ROBOTApocalypse.Models;
using System.Diagnostics;

namespace ROBOTApocalypse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration iConfiguration)
        {
            this.configuration = iConfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("robotlist")]
        public IActionResult RobotCpu()
        {
            var result = WebApiCommon.CallApi<GenericResponse<List<RobotCpu>>>(this.configuration.GetSection("ApiEndPoint").Value, "listofrobots", null, httpMethod: HttpMethod.Get);
            return View(result.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}