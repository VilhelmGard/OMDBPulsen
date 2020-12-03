using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace OMDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OMDBController : ControllerBase
    {
        ////POST: api/OMDB
        [HttpPost]
        public IActionResult OMDBPost(Request req)
        {
            try
            {
                Request.Headers.TryGetValue("Accept", out StringValues values);
                string contentType = values.FirstOrDefault();

                OMDBService oMDBService = new OMDBService();
                return Ok(
                    oMDBService.GetFromOMDB(
                    req.MovieTitle.Replace(" ", "+"),
                    req.MovieYear,
                    req.MoviePlot,
                    contentType.Replace("application/", "")));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    ex.InnerException.ToString());
            }

        }
        // GET: api/OMDB/param?movieTitle={title}&movieYear={year}&moviePlot={plot}
        [HttpGet("param")]
        public IActionResult OMDBGet(string movieTitle, int movieYear, MoviePlot moviePlot)
        {
            try
            {
                Request.Headers.TryGetValue("Accept", out StringValues values);
                string contentType = values.FirstOrDefault();

                OMDBService oMDBService = new OMDBService();

                return Ok(
                    oMDBService.GetFromOMDB(
                    movieTitle,
                    movieYear,
                    moviePlot,
                    contentType.Replace("application/", "")));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    ex.InnerException.ToString());
            }

        }
    }
}

