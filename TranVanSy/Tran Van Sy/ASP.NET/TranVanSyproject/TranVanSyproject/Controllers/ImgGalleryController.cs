using JamesTranproject.Interface;
using JamesTranproject.Models;
using JamesTranproject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgGalleryController : ControllerBase
    {
        private readonly IImgGallery _iImgGallery;
        public ImgGalleryController(IImgGallery imgGallery)
        {
            _iImgGallery = imgGallery;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iImgGallery.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageGallery>> GetItem(int id)
        {
            try
            {
                var result = await _iImgGallery.GetItem(id);

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
        public async Task<ActionResult<ImageGallery>> Update(int id, ImageGallery image)
        {
            try
            {
                if (id != image.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iImgGallery.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iImgGallery.Update(image);
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
        public async Task<ActionResult<List<ImageGallery>>> Add(ImageGallery imageGallery)
        {
            try
            {
                return Ok(await _iImgGallery.Add(imageGallery));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ImageGallery>>> Delete(int id)
        {
            try
            {
                var result = await _iImgGallery.Delete(id);
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
        public async Task<string> Upload([FromForm] imgImg obj)
        {
            return await _iImgGallery.Upload(obj);
        }
    }
}
