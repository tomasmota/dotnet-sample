using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace dotnet_sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly string configVar;

        public ConfigController(IConfiguration Configuration)
        {
            configVar = Configuration["ConfigVar"];
        }

        [HttpGet]
        public string GetConfig()
        {

            Log.Information("Got a call for configuration var");
            return configVar;
        }
    }
}
