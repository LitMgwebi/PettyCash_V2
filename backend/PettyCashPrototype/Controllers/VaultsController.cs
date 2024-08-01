namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<Vault>> Details(int id)
        {
            try
            {
                Vault vault = await _vault.GetOne(id);
                return Ok(vault);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
