using System.Security.Claims;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequisitionsController : ControllerBase
    {
        private IRequisition _requisition;
        public RequisitionsController(IRequisition requisition)
        {
            _requisition = requisition;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> Index([FromQuery] string command, int statusId, string issuedState = "")
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var divisionId = identity.Claims.Where(c => c.Type == "Division").Select(c => c.Value).FirstOrDefault()!;
                var role = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).FirstOrDefault()!;
                var jobTitleId = identity.Claims.Where(c => c.Type == "JobTitle").Select(c => c.Value).FirstOrDefault()!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                IEnumerable<Requisition> requisitions = await _requisition.GetAll(command, int.Parse(divisionId), int.Parse(jobTitleId), userId, role, statusId, issuedState);

                return Ok(requisitions);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpGet, Route("details")]
        public async Task<ActionResult<Requisition>> Details(int id)
        {
            try
            {
                Requisition requisition = await _requisition.GetOne(id);
                return Ok(requisition);
            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public async Task<ActionResult<Requisition>> Create(Requisition requisition)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                string message = await _requisition.Create(requisition, userId);
                return Ok(new { message = message });
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public async Task<ActionResult> Edit(RequisitionModelForEdit modelForEdit)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                string message = await _requisition.Edit(modelForEdit.Requisition!, modelForEdit.command!, userId, modelForEdit.attemptCode);
                return Ok(new { message = message });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        #endregion

        #region DELETE

        [HttpPut, Route("delete")]
        public async Task<ActionResult> Delete([FromBody]int requisitionId)
        {
            try
            {
                Requisition requisition = await _requisition.GetOne(requisitionId);
                await _requisition.SoftDelete(requisition);
                return Ok(new { messsage = $"Requisition number: {requisition.RequisitionId} has been deleted. " });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
