using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Threading.Tasks;

namespace CDR.DataHolder.Public.API.Controllers
{
    [ApiController]
	[Route("cds-au")]
    public class DiscoveryController : ControllerBase
    {
        private readonly ILogger<DiscoveryController> _logger;

        public DiscoveryController(ILogger<DiscoveryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("v1/discovery/status")]
        [ApiVersion("1")]
        [HttpGet]
        public async Task GetStatus()
        {
            using (LogContext.PushProperty("MethodName", ControllerContext.RouteData.Values["action"].ToString()))
            {
                _logger.LogInformation($"Received request to {ControllerContext.RouteData.Values["action"]}");
            }

            // var json = await System.IO.File.ReadAllTextAsync("data/status.json");
            var json = await System.IO.File.ReadAllTextAsync("Data/status.json");

            // Return the raw JSON response.
            Response.ContentType = "application/json";
            await Response.BodyWriter.WriteAsync(System.Text.UTF8Encoding.UTF8.GetBytes(json));
        }

        [HttpGet("v1/discovery/outages")]
        [ApiVersion("1")]
        [HttpGet]
        public async Task GetOutages()
        {
            using (LogContext.PushProperty("MethodName", ControllerContext.RouteData.Values["action"].ToString()))
            {
                _logger.LogInformation($"Received request to {ControllerContext.RouteData.Values["action"]}");
            }

            // var json = await System.IO.File.ReadAllTextAsync("data/outages.json");
            var json = await System.IO.File.ReadAllTextAsync("Data/outages.json");

            // Return the raw JSON response.
            Response.ContentType = "application/json";
            await Response.BodyWriter.WriteAsync(System.Text.UTF8Encoding.UTF8.GetBytes(json));
        }
    }
}
