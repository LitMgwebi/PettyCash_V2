namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAccountsController : ControllerBase
    {
        private readonly IMainAccount _mainAccount;
        public MainAccountsController(IMainAccount mainAccount)
        {
            _mainAccount = mainAccount;
        }

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<MainAccount>>> Index()
        {
            try
            {
                IEnumerable<MainAccount> mainAccounts = await _mainAccount.GetAll();
                return Ok(mainAccounts);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<MainAccount>> Details(int id)
        {
            try
            {
                MainAccount mainAccount = await _mainAccount.GetOne(id);
                return Ok(mainAccount);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<MainAccount> Create(MainAccount mainAccount)
        {
            try
            {
                _mainAccount.Create(mainAccount);

                return Ok(new { message = "The new main account has been added to the system." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(MainAccount mainAccount)
        {
            try
            {
                _mainAccount.Edit(mainAccount);           

                return Ok(new { message = $"{mainAccount.Name} has been edited." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(MainAccount mainAccount)
        {
            try
            {
                _mainAccount.SoftDelete(mainAccount);

                return Ok(new { message = "Main Account has been deleted." });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
