namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly IDivision _division;
        public DivisionsController(IDivision division) => _division = division;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Division>>> Index()
        {
            try
            {
                IEnumerable<Division> divisions = await _division.GetAll();
                return Ok(divisions);
            }
            catch (Exception ex) { return BadRequest(new {ex}); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Division>> Details(int id)
        {
            try
            {
                Division division = await _division.GetOne(id);

                return Ok(division);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Division> Create(Division division)
        {
            try
            {
                _division.Create(division);

                return Ok(new {message = "The new department has been added to the system."});
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Division division)
        {
            try
            {
                _division.Edit(division);
                return Ok(new {message = $"{division.Name} has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Division division)
        {
            try
            {
                _division.SoftDelete(division);

                return Ok(new { message = "Department has been deleted" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        #endregion
    }
}
