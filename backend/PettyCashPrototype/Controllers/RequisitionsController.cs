namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionsController : ControllerBase
    {
        private IRequisition _requisition;
        public RequisitionsController(IRequisition requisition) { _requisition = requisition; }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> Index()
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _requisition.GetAll();

                return Ok(requisitions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Requisition>> Details(int id)
        {
            try
            {
                Requisition requisition = await _requisition.GetOne(id);
                return Ok(requisition);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Requisition> Create(Requisition requisition)
        {
            try
            {
                _requisition.Create(requisition);
                return Ok(new { message = "The new Requisition has been added to the system" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Requisition requisition)
        {
            try
            {
                _requisition.Edit(requisition);
                return Ok(new { message = $"The requisition has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Requisition requisition)
        {
            try
            {
                _requisition.SoftDelete(requisition);
                return Ok(new { messsage = $"Requisition number: {requisition.RequisitionId} has been deleted. " });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
