using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
            return configVar;
        }
    }
}
