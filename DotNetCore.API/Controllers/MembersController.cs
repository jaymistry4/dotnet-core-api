using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DotNetCore.API.Models;

namespace DotNetCore.API.Controllers
{
#pragma warning disable CS1591
    [ApiController]
    [Route("api/v2/[controller]")]
    public class MembersController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly WideWorldImportersDbContext DbContext;

        public MembersController(ILogger<MembersController> logger, WideWorldImportersDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }
#pragma warning restore CS1591

        // GET
        // api/v1/Members/Member

        /// <summary>
        /// Get members
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="lastEditedBy">Last edit by (user id)</param>
        /// <param name="colorID">Color id</param>
        /// <param name="outerPackageID">Outer package id</param>
        /// <param name="supplierID">Supplier id</param>
        /// <param name="unitPackageID">Unit package id</param>
        /// <returns>A response with stock items list</returns>
        /// <response code="200">Returns the stock items list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("Member")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMembersAsync(int pageSize = 10, int pageNumber = 1, int? lastEditedBy = null, int? colorID = null, int? outerPackageID = null, int? supplierID = null, int? unitPackageID = null)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetMembersAsync));

            var response = new PagedResponse<Member>();

            try
            {
                // Get the "proposed" query from repository
                var query = DbContext.GetMembers();

                // Set paging values
                response.PageSize = pageSize;
                response.PageNumber = pageNumber;

                // Get the total rows
                response.ItemsCount = await query.CountAsync();

                // Get the specific page from database
                response.Model = await query.Paging(pageSize, pageNumber).ToListAsync();

                response.Message = $"Page {pageNumber} of {response.PageCount}, Total of products: {response.ItemsCount}.";

                Logger?.LogInformation("The stock items have been retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetMembersAsync), ex);
            }

            return response.ToHttpResponse();
        }

        // GET
        // api/v1/Members/Member/5

        /// <summary>
        /// Retrieves a stock item by ID
        /// </summary>
        /// <param name="id">Stock item id</param>
        /// <returns>A response with stock item</returns>
        /// <response code="200">Returns the stock items list</response>
        /// <response code="404">If stock item is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("Member/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMemberAsync(int id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetMemberAsync));

            var response = new SingleResponse<Member>();

            try
            {
                // Get the stock item by id
                response.Model = await DbContext.GetMembersAsync(new Member(id));
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetMemberAsync), ex);
            }

            return response.ToHttpResponse();
        }

        // POST
        // api/v1/Members/Member/

        /// <summary>
        /// Creates a new stock item
        /// </summary>
        /// <param name="request">Request model</param>
        /// <returns>A response with new stock item</returns>
        /// <response code="201">A response as creation of stock item</response>
        /// <response code="400">For bad request</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost("Member")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostMemberAsync([FromBody]PostMembersRequest request)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostMemberAsync));

            var response = new SingleResponse<Member>();

            try
            {
                var existingEntity = await DbContext
                    .GetMemberNameAsync(new Member { FirstName = request.FirstName });

                if (existingEntity != null)
                    ModelState.AddModelError("MemberName", "Stock item name already exists");

                if (!ModelState.IsValid)
                    return BadRequest();

                // Create entity from request model
                var entity = request.ToEntity();

                // Add entity to repository
                DbContext.Add(entity);

                // Save entity in database
                await DbContext.SaveChangesAsync();

                // Set the entity to response model
                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = $"There was an internal error, please contact to technical support. {ex.InnerException?.Message}";

                Logger?.LogCritical($"There was an error on '{nameof(PostMemberAsync)}' invocation: {ex}");
            }

            return response.ToHttpCreatedResponse();
        }

        // PUT
        // api/v1/Members/Member/5

        /// <summary>
        /// Updates an existing stock item
        /// </summary>
        /// <param name="id">Stock item ID</param>
        /// <param name="request">Request model</param>
        /// <returns>A response as update stock item result</returns>
        /// <response code="200">If stock item was updated successfully</response>
        /// <response code="400">For bad request</response>
        /// <response code="404">If stock item is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPut("Member/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutMemberAsync(int id, [FromBody]PutMembersRequest request)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PutMemberAsync));

            var response = new Response();

            try
            {
                // Get stock item by id
                var entity = await DbContext.GetMembersAsync(new Member(id));

                // Validate if entity exists
                if (entity == null)
                    return NotFound();

                // Set changes to entity
                entity.FirstName = request.FirstName;

                // Update entity in repository
                DbContext.Update(entity);

                // Save entity in database
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(PutMemberAsync), ex);
            }

            return response.ToHttpResponse();
        }

        // DELETE
        // api/v1/Members/Member/5

        /// <summary>
        /// Deletes an existing stock item
        /// </summary>
        /// <param name="id">Stock item ID</param>
        /// <returns>A response as delete stock item result</returns>
        /// <response code="200">If stock item was deleted successfully</response>
        /// <response code="404">If stock item is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpDelete("Member/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteMemberAsync(int id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(DeleteMemberAsync));

            var response = new Response();

            try
            {
                // Get stock item by id
                var entity = await DbContext.GetMembersAsync(new Member(id));

                // Validate if entity exists
                if (entity == null)
                    return NotFound();

                // Remove entity from repository
                DbContext.Remove(entity);

                // Delete entity in database
                await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(DeleteMemberAsync), ex);
            }

            return response.ToHttpResponse();
        }
    }
}
