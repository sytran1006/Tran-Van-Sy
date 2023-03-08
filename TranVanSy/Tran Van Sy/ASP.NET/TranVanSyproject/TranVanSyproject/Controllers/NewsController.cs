using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesTranproject.Models;
using JamesTranproject.Interface;

namespace JamesTranproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _iNewService;
        public NewsController (INewsService iNewService)
        {
            _iNewService = iNewService;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _iNewService.GetAll1());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetItem(int id)
        {
            try
            {
                var result = await _iNewService.GetItem(id);

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
        public async Task<ActionResult<News>> Update(int id, News anew)
        {
            try
            {
                if (id != anew.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var result = await _iNewService.GetItem(id);

                if (result == null)
                    return NotFound($"Employee with Id = {id} not found");
                return await _iNewService.Update(anew);
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
        public async Task<ActionResult<List<News>>> Add(News anew)
        {
            try
            {
                return Ok(await _iNewService.Add(anew));
            }   
            catch (Exception)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPost]
        [Route("upload")]
        public async Task<string> Upload([FromForm] imgNew obj)
        {
            return await _iNewService.Upload(obj);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<News>>> Delete(int id)
        {
            try
            {
                var result = await _iNewService.Delete(id);
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
    }
}
