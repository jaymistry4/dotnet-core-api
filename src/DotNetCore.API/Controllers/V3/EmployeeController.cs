using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("getAllEmployees")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<EmployeeForRateLimit> GetAllEmployees()
        {
            return GetEmployeesDeatils();
        }

        [HttpGet("getEmployeeById/{id}")]
        [Produces("application/json")]
        public EmployeeForRateLimit GetEmployeeById(int id)
        {
            return GetEmployeesDeatils().Find(e => e.Id == id);
        }

        private List<EmployeeForRateLimit> GetEmployeesDeatils()
        {
            return new List<EmployeeForRateLimit>()
            {
                new EmployeeForRateLimit()
                {
                    Id = 1,
                    FirstName= "Test",
                    LastName = "Name",
                    EmailId ="Test.Name@gmail.com"
                },
                new EmployeeForRateLimit()
                {
                    Id = 2,
                    FirstName= "Test",
                    LastName = "Name1",
                    EmailId ="Test.Name1@gmail.com"
                }
            };
        }
    }
}
