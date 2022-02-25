using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROBOTApocalypse.Common;
using ROBOTApocalypse.DB;
using ROBOTApocalypse.Entity;
using ROBOTApocalypse.Entity.ViewModel;
using ROBOTApocalypse.IServices;

namespace ROBOTApocalypse.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ROBOTApocalypseController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IROBOTApocalypseService iROBOTApocalypseService;

        public ROBOTApocalypseController(IConfiguration iConfiguration, IROBOTApocalypseService iROBOTApocalypseService)
        {
            this.configuration = iConfiguration;
            this.iROBOTApocalypseService = iROBOTApocalypseService;

        }

        [HttpPost("savesurvivors")]
        public IActionResult savesurvivors(SurvivorsViewModel survivorsViewModel)
        {
            survivorsViewModel = this.iROBOTApocalypseService.SaveSurvivors(survivorsViewModel);
            return Ok(survivorsViewModel);
        }

        [HttpPost("flagsurvivorasinfected")]
        public IActionResult FlagSurvivorAsInfected(Survivors Survivors)
        {
            Survivors = this.iROBOTApocalypseService.UpdateSurvivorsStatus(Survivors);
            return Ok(Survivors);
        }

        [HttpPost("updatesurvivorlocation")]
        public IActionResult UpdateSurvivorLocation(SurvivorLocation survivorLocation)
        {
            survivorLocation = this.iROBOTApocalypseService.UpdateSurvivorsLocation(survivorLocation);
            return Ok(survivorLocation);
        }

        [HttpGet("listofrobots")]
        public IActionResult ListOfRobots()
        {
            var result = WebApiCommon.CallApi<List<RobotCpu>>(this.configuration.GetSection("RobotCpuEndPoint").Value, "robotcpu", null, httpMethod: HttpMethod.Get);
            return Ok(new GenericResponse<List<RobotCpu>>(true, "Success", System.Net.HttpStatusCode.OK, result));
        }
    }
}