namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubAccountsController : ControllerBase
    {
        private readonly ISubAccount _subAccount;
        public SubAccountsController(ISubAccount subAccount)
        {
            _subAccount = subAccount;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<SubAccount>>> Index()
        {
            try
            {
                IEnumerable<SubAccount> subAccounts = await _subAccount.GetAll();
                return Ok(subAccounts);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<SubAccount>> Details(int id)
        {
            try
            {
                SubAccount subAccount = await _subAccount.GetOne(id);
                return Ok(subAccount);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public async Task<ActionResult<SubAccount>> Create(SubAccount subAccount)
        {
            try
            {
                await _subAccount.Create(subAccount);

                return Ok(new {message = "The new sub account has been added to the system."});
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(SubAccount subAccount)
        {
            try
            {
                _subAccount.Edit(subAccount);

                return Ok(new {message = $"{subAccount.Name} has been edited." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete (SubAccount subAccount)
        {
            try
            {
                _subAccount.SoftDelete(subAccount);

                return Ok(new {message = "Sub Account has been deleted."});
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
