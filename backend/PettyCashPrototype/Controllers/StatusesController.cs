﻿namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusesController : ControllerBase
    {
        private readonly IStatus _status;
        public StatusesController(IStatus status) { _status = status; }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Status>>> Index()
        {
            try
            {
                IEnumerable<Status> statuses = await _status.GetAll();
                return Ok(statuses);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("get_approved")]
        public async Task<ActionResult<IEnumerable<Status>>> IndexApproved()
        {
            try
            {
                IEnumerable<Status> statuses = await _status.GetApproved();
                return Ok(statuses);
            }
            catch (Exception ex) { return BadRequest(ex.Message); } 
        }
        
        [HttpGet, Route("get_recommended")]
        public async Task<ActionResult<IEnumerable<Status>>> IndexRecommended()
        {
            try
            {
                IEnumerable<Status> statuses = await _status.GetRecommended();
                return Ok(statuses);
            }
            catch (Exception ex) { return BadRequest(ex.Message); } 
        }

        [HttpGet, Route("get_requisition_states")]
        public async Task<ActionResult<IEnumerable<Status>>> IndexRequisitionStates()
        {
            try
            {
                IEnumerable<Status> statuses = await _status.GetRequisitionStates();
                return Ok(statuses);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        #endregion
    }
}
