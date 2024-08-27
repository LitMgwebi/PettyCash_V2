using System.Security.Claims;

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
        public async Task<ActionResult<IEnumerable<Transaction>>> Index(string type)
        {
            try
            {
                IEnumerable<Transaction> transactions = await _transaction.GetAll(type);
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

        #region POST

        [HttpPost, Route("create")]
        public async Task<ActionResult<Transaction>> Create(Transaction transaction)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity!;
                var userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault()!;
                string message = await _transaction.Create(transaction.Amount, typesOfTransaction.Deposit, note: "Reimbursing Vault", userId: userId);
                return Ok(new {message = message});
            } catch (Exception ex) { return BadRequest(ex); }
        }

        #endregion
    }
}
