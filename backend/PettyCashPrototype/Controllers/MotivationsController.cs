using System.Security.Claims;
using System.Security.Principal;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MotivationsController : ControllerBase
    {
        private IMotivation _motivation;
        public MotivationsController(IMotivation motivation) => _motivation = motivation;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Motivation>>> Index()
        {
            try
            {
                IEnumerable<Motivation> motivations = await _motivation.GetAll();
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

        //[HttpPost, Route("create")]
        //public async Task<ActionResult<Motivation>> Create(UploadFile uploadFile)
        //{
        //    try
        //    {
        //        var identity = (ClaimsIdentity)User.Identity!;
        //        string name = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault()!;
        //        string message = await _motivation.Upload(uploadFile.File, uploadFile.id, name);
        //        return Ok(new { message = message });
        //    }
        //    catch (Exception ex) { return BadRequest(ex.InnerException); }
        //}

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
