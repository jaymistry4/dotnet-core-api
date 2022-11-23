using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBUtility.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCore.API.Controllers
{
    [ApiController]
    [Route("api/v1/book")]
    public class MongoDBBookController : Controller
    {
        private readonly IMongoDBUtilityContext _context;
        protected IMongoCollection<Book> _dbCollection;

        public MongoDBBookController(IMongoDBUtilityContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Book>("TestMongoCollectionDB");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<Book>.Filter.Empty);
            return Ok(all.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Input object is null");
            }
            var objectId = new ObjectId(id);
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("_id", objectId);
            var result = await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
