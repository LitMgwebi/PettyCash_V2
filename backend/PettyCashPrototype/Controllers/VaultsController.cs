namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Finance_Admin, ICT_Admin")]
    public class VaultsController : ControllerBase
    {
        private readonly IVault _vault;
        public VaultsController(IVault vault) => _vault = vault;
         
        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Vault>>> Index()
        {
            try
            {
                IEnumerable<Vault> vaults = await _vault.GetAll();
                return Ok(vaults);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Vault>> Details()
        {
            try
            {
                Vault vault = await _vault.GetOne(1);
                return Ok(vault);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
