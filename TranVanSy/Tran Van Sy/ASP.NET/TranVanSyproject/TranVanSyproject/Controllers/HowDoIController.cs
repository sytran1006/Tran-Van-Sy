using JamesTranproject.Interface;
using JamesTranproject.Models;
using JamesTranproject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HowDoIController : ControllerBase
    {
        private readonly IHowDoI _iHowDoI;
        public HowDoIController(IHowDoI iHowDoI)
        {
            _iHowDoI = iHowDoI;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iHowDoI.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HowDoI>> GetItem(int id)
        {
            try
            {
                var result = await _iHowDoI.GetItem(id);

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
        public async Task<ActionResult<HowDoI>> Update(int id, HowDoI howDoI)
        {
            try
            {
                if (id != howDoI.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iHowDoI.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iHowDoI.Update(howDoI);
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
        public async Task<ActionResult<List<HowDoI>>> Add(HowDoI howDoI)
        {
            try
            {
                return Ok(await _iHowDoI.Add(howDoI));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HowDoI>>> Delete(int id)
        {
            try
            {
                var result = await _iHowDoI.Delete(id);
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
        public async Task<string> Upload([FromForm] imgHowDoI obj)
        {
            return await _iHowDoI.Upload(obj);
        }
    }
}
