namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartment _department;
        public DepartmentsController(IDepartment department) => _department = department;

        #region GET

        [HttpGet, Route("index")]
        public async Task<ActionResult<IEnumerable<Department>>> Index()
        {
            try
            {
                IEnumerable<Department> departments = await _department.GetAll();
                return Ok(departments);
            } catch (Exception ex) { return BadRequest(ex.Message);}
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Department>> Details(int id)
        {
            try
            {
                Department department = await _department.GetOne(id);
                return Ok(department);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        #endregion
    }
}
