namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransaction _transaction;
        public TransactionsController(ITransaction transaction) => _transaction = transaction;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Transaction>>> Index()
        {
            try
            {
                IEnumerable<Transaction> transactions = await _transaction.GetAll();
                return Ok(transactions);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet, Route("details")]
        public async Task<ActionResult<Transaction>> Details(int id)
        {
            try
            {
                Transaction transactions = await _transaction.GetOne(id);
                return Ok(transactions);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion
    }
}
