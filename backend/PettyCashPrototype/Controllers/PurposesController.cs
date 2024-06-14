using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurposesController : ControllerBase
    {
        private readonly IPurpose _purpose;
        public PurposesController(IPurpose purpose)
        {
            _purpose = purpose;
        }


        // GET: api/<PurposesController>
        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Purpose>>> Index()
        {
            try
            {
                IEnumerable<Purpose> purposes = await _purpose.GetAll();
                return Ok(purposes);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PurposesController>/5
        [HttpGet, Route("details")]
        public async Task<ActionResult<Purpose>> Details(int id)
        {
            try
            {
                Purpose purpose = await _purpose.GetOne(id);

                return Ok(purpose);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PurposesController>/5
        [HttpDelete, Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                int result = await _purpose.Delete(id);

                if (result == 0)
                    return UnprocessableEntity("System was unable to delete the selected purpose");

                return Ok(new { message = "Purpose has been deleted" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
