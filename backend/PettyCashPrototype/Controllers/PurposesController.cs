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

        #region GET

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

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Purpose> Create(Purpose purpose)
        {
            try
            {
                _purpose.Create(purpose);

                return Ok(new { message = "The new purpose has been added to the system." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Purpose purpose)
        {
            try
            {
                _purpose.Edit(purpose);

                return Ok(new { message = $"{purpose.Name} has been edited." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region DELETE

        // DELETE api/<PurposesController>/5
        [HttpDelete, Route("delete")]
        public ActionResult Delete(Purpose purpose)
        {
            try
            {
                 _purpose.SoftDelete(purpose);

                return Ok(new { message = "Purpose has been deleted." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
