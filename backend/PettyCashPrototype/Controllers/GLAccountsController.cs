namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GLAccountsController : ControllerBase
    {
        private readonly IGLAccount _glAccount;
        public GLAccountsController(IGLAccount glAccount)
        {
            _glAccount = glAccount;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Glaccount>>> Index()
        {
            try
            {
                IEnumerable<Glaccount> glaccounts = await _glAccount.GetAll();
                return Ok(glaccounts);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Glaccount>> Details(int id)
        {
            try
            {
                Glaccount glAccount = await _glAccount.GetOne(id);
                return Ok(glAccount);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Glaccount> Create(Glaccount glAccount)
        {
            try
            {
                _glAccount.Create(glAccount);
                return Ok(new {message = "The new GL Account has been added to the system."});
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Glaccount glAccount)
        {
            try
            {
                _glAccount.Edit(glAccount);
                return Ok(new { message = $"{glAccount.Name} has been edited" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Glaccount glAccount)
        {
            try
            {
                _glAccount.SoftDelete(glAccount);
                return Ok(new { message = "GL Account has been deleted" });
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
