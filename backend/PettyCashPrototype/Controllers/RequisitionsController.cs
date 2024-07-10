using PettyCashPrototype.Models;
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
        public async Task<ActionResult<IEnumerable<Requisition>>> Index()
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _requisition.GetAll();

                return Ok(requisitions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("manager_index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> IndexForManager()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var divisionId = identity.Claims.Where(c => c.Type == "Division").Select(c => c.Value).FirstOrDefault()!;
                IEnumerable<Requisition> requisitions = await _requisition.GetAllForManagerApproval(int.Parse(divisionId));

                return Ok(requisitions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("finance_index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> IndexForFinance()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;

                var divisionId = identity.Claims.Where(c => c.Type == "Division").Select(c => c.Value).FirstOrDefault()!;
                var jobTitleId = identity.Claims.Where(c => c.Type == "JobTitle").Select(c => c.Value).FirstOrDefault()!;
                IEnumerable<Requisition> requisitions = await _requisition.GetAllForFinanceApproval(int.Parse(divisionId), int.Parse(jobTitleId));

                return Ok(requisitions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("applicant_index")]
        public async Task<ActionResult<IEnumerable<Requisition>>> ApplicantForms()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;
                IEnumerable<Requisition> requisitions = await _requisition.GetByApplicant(userId);

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
        public ActionResult Edit(Requisition requisition)
        {
            try
            {
                _requisition.Edit(requisition);
                return Ok(new { message = $"The requisition has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut, Route("manager_recommendation")]
        public ActionResult ManagerRecommendation(Requisition requisition)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                requisition.ManagerId = userId;
                requisition.ManagerRecommendationDate = DateTime.UtcNow;

                if (requisition.ManagerRecommendationId == 4)
                    requisition.Stage = "Line manager has not recommended this requisition.";
                else if (requisition.ManagerRecommendationId == 3)
                    requisition.Stage = "Line manager has recommended this requisition. Awaiting Finance Approval.";

                _requisition.Edit(requisition);
                return Ok(new { message = $"Your recommendation has been added to the system." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut, Route("finance_approval")]
        public ActionResult FinanceApproval(Requisition requisition)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;

                requisition.FinanceOfficerId = userId;
                requisition.FinanceApprovalDate = DateTime.UtcNow;

                if (requisition.ManagerRecommendationId == 1)
                    requisition.Stage = "Finance has approved of this requisition.";
                else if (requisition.ManagerRecommendationId == 2)
                    requisition.Stage = "Finance has declined of this requisition";

                _requisition.Edit(requisition);
                return Ok(new { message = $"Your approval has been recorded by the system." });
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
