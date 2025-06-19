using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class NamedHttpClientController : ControllerBase
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        public NamedHttpClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100); // Simulate some random operation
            var client = _httpClientFactory.CreateClient("NamedClient");
            var response = await client.GetAsync($"/todos/{randomNumber}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from named client.");
            }
        }

        [HttpGet("EmailApiTestingAsync")]
        public async Task<IActionResult> EmailApiTestingAsync()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100); // Simulate some random operation
            var client = _httpClientFactory.CreateClient("EmailApiNamedClient");
            var response = await client.GetAsync($"/test");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from named client.");
            }
        }
    }
}