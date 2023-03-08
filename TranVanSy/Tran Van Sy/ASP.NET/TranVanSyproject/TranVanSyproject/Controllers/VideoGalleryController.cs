using JamesTranproject.Interface;
using JamesTranproject.Models;
using JamesTranproject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGalleryController : ControllerBase
    {
        private readonly IVideoGallery _iVideoGallery;
        public VideoGalleryController(IVideoGallery videoGallery)
        {
            _iVideoGallery = videoGallery;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iVideoGallery.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGallery>> GetItem(int id)
        {
            try
            {
                var result = await _iVideoGallery.GetItem(id);

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
        public async Task<ActionResult<VideoGallery>> Update(int id, VideoGallery videoGallery)
        {
            try
            {
                if (id != videoGallery.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iVideoGallery.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iVideoGallery.Update(videoGallery);
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
        public async Task<ActionResult<List<VideoGallery>>> Add(VideoGallery videoGallery)
        {
            try
            {
                return Ok(await _iVideoGallery.Add(videoGallery));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VideoGallery>>> Delete(int id)
        {
            try
            {
                var result = await _iVideoGallery.Delete(id);
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
        public async Task<string> Upload([FromForm] imgVideo obj)
        {
            return await _iVideoGallery.Upload(obj);
        }
    }
}
