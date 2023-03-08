using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesTranproject.Models;
using JamesTranproject.Interface;
using JamesTranproject.Service;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnouncementsController : ControllerBase
    {
        private readonly IAnouncementService _iAnouncementService;
        private static IWebHostEnvironment _webHostEnvironment;
        public AnouncementsController(IAnouncementService iAnouncementService, IWebHostEnvironment webHostEnvironment)
        {
            _iAnouncementService = iAnouncementService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iAnouncementService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anouncement>> GetItem(int id)
        {
            try
            {
                var result = await _iAnouncementService.GetItem(id);

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
        public async Task<ActionResult<Anouncement>> Update(int id, Anouncement anouncement)
        {
            try
            {
                if (id != anouncement.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iAnouncementService.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iAnouncementService.Update(anouncement);
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
        public async Task<ActionResult<List<Anouncement>>> Add(Anouncement anouncement)
        {
            try
            {
                return Ok(await _iAnouncementService.Add(anouncement));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Anouncement>>> Delete(int id)
        {
            try
            {
                var result = await _iAnouncementService.Delete(id);
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
        [Route("upload1")]
        //public async Task<string> Upload([FromForm] imgAnouncement obj)
        //{
        //    return await _iAnouncementService.Upload(obj);
        //}
        public  JsonResult Upload()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile= httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath + "/Photo/" + fileName;
                using (var stream= new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);

                }
                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        
        }

    }
}
