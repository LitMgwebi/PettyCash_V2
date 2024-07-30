using System.Security.Claims;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MotivationsController : ControllerBase
    {
        private IMotivation _motivation;
        private IRequisition _requisition;
        public MotivationsController(IMotivation motivation, IRequisition requisition)
        { 
            _motivation = motivation;
            _requisition = requisition;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Motivation>>> Index(int requisitionId = 0)
        {
            try
            {
                IEnumerable<Motivation> motivations = await _motivation.GetAll(requisitionId);
                return Ok(motivations);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Motivation>> Details(int id)
        {
            try
            {
                Motivation motivation = await _motivation.GetOne(id);
                return Ok(motivation);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public async Task<ActionResult<Motivation>> Create(UploadFile uploadFile)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                string name = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault()!;
                string message = await _motivation.Upload(uploadFile.File, uploadFile.RequisitionId, name);

                Requisition requisition = await _requisition.GetOne(uploadFile.RequisitionId);
                string messageFromRequisition = await _requisition.Edit(requisition, "addMotivation");

                return Ok(new { message = message });
            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Motivation motivation)
        {
            try
            {
                _motivation.Edit(motivation);
                return Ok(new { message = $"{motivation.FileName} has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Motivation motivation)
        {
            try
            {
                _motivation.SoftDelete(motivation);

                return Ok(new { message = "Motivation has been deleted" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
