using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitle _jobTitle;
        public JobTitlesController(IJobTitle jobTitle) => _jobTitle = jobTitle;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<JobTitle>>> Index()
        {
            try
            {
                IEnumerable<JobTitle> jobTitles = await _jobTitle.GetAll();
                return Ok(jobTitles);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<JobTitle>> Details(int id)
        {
            try
            {
                JobTitle jobTitle = await _jobTitle.GetOne(id);
                return Ok(jobTitle);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
