using PettyCashPrototype.Services.RequisitionService.EditHandler;
using System.Security.Claims;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RequisitionsController : ControllerBase
    {
        private IRequisition _requisition;
        public RequisitionsController(IRequisition requisition) 
        { 
            _requisition = requisition; 
            
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> Index(string command)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var divisionId = identity.Claims.Where(c => c.Type == "Division").Select(c => c.Value).FirstOrDefault()!;
                var jobTitleId = identity.Claims.Where(c => c.Type == "JobTitle").Select(c => c.Value).FirstOrDefault()!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                IEnumerable<Requisition> requisitions = await _requisition.GetAll(command, int.Parse(divisionId), int.Parse(jobTitleId), userId);

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
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
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

                requisition.Stage = "Requisiton has been sent to your Line Manager, currently awaiting manager approval";
                requisition.ApplicantId = userId;
                requisition.StartDate = DateTime.UtcNow;
                await _requisition.Create(requisition);
                return Ok(new { message = "The new Requisition has been added to the system" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(RequisitionModelForEdit requisitionModel)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;
                string messageResponse = "";

                EditRequisitionHandler editRequisition = new EditRequisitionHandler();

                if (requisitionModel.command == "manager")
                {
                    editRequisition.setState(new ManagerRecommendationState());
                    messageResponse = editRequisition.request(_requisition, requisitionModel.Requisition, userId);
                }
                else if (requisitionModel.command == "finance")
                {
                    editRequisition.setState(new FinanceApprovalState());
                    messageResponse = editRequisition.request(_requisition, requisitionModel.Requisition, userId);
                }
                else if (requisitionModel.command == "edit")
                {
                    editRequisition.setState(new WholeRequisitionState());
                    messageResponse = editRequisition.request(_requisition, requisitionModel.Requisition);
                }
                return Ok(new { message = messageResponse });
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
