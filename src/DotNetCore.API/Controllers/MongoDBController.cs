using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBUtility.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MongoDBController : Controller
    {
        private readonly IMongoDBUtilityContext _context;
        protected IMongoCollection<Temperatures> _dbTemperatureCollection;

        public MongoDBController(IMongoDBUtilityContext context)
        {
            _context = context;
            _dbTemperatureCollection = _context.GetCollection<Temperatures>("listingsAndReviews");
        }

        /// <summary>
        /// Authorization token not required.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the temperature list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        [Route("GetTemperatures")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Book>>> GetTemperatures()
        {
            var all = await _dbTemperatureCollection.FindAsync(Builders<Temperatures>.Filter.Empty);
            return Ok(all.ToList());
        }
    }
}
