using JamesTranproject.Interface;
using JamesTranproject.Models;
using JamesTranproject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickLinkController : ControllerBase
    {
        private readonly IQuickLink _iQuickLink;
        public QuickLinkController(IQuickLink quickLink)
        {
            _iQuickLink = quickLink;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iQuickLink.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuickLink>> GetItem(int id)
        {
            try
            {
                var result = await _iQuickLink.GetItem(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<QuickLink>> Update(int id, QuickLink quickLink)
        {
            try
            {
                if (id != quickLink.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iQuickLink.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iQuickLink.Update(quickLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<QuickLink>>> Add(QuickLink quickLink)
        {
            try
            {
                return Ok(await _iQuickLink.Add(quickLink));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<QuickLink>>> Delete(int id)
        {
            try
            {
                var result = await _iQuickLink.Delete(id);
                if (result == null)
                    return BadRequest("Announ not found.");
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpPost]
        [Route("upload")]
        public async Task<string> Upload([FromForm] imgQuickLink obj)
        {
            return await _iQuickLink.Upload(obj);
        }
    }
}
