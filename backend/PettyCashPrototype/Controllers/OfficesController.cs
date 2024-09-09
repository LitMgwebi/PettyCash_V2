namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficesController : ControllerBase
    {
        private readonly IOffice _office;
        public OfficesController (IOffice office) => _office = office;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Office>>> Index()
        {
            try
            {
                IEnumerable<Office> offices = await _office.GetAll();
                return Ok(offices);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Office>> Details(int id)
        {
            try
            {
                Office office = await _office.GetOne(id);

                return Ok(office);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Office> Create(Office office)
        {
            try
            {
                _office.Create(office);
                return Ok(new {message = "The new office has been added to the system."});
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Office office)
        {
            try
            {
                _office.Edit(office);

                return Ok(new { message = $"{office.Name} has been edited" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Office office)
        {
            try
            {
                _office.SoftDelete(office);

                return Ok(new { message = "Office has been deleted." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        #endregion
    }
}
