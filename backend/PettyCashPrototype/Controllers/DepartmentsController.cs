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
        public async Task<ActionResult<IEnumerable<Division>>> Index()
        {
            try
            {
                IEnumerable<Division> departments = await _department.GetAll();
                return Ok(departments);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet, Route("details")]
        public async Task<ActionResult<Division>> Details(int id)
        {
            try
            {
                Division department = await _department.GetOne(id);

                return Ok(department);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region POST

        [HttpPost, Route("create")]
        public ActionResult<Division> Create(Division department)
        {
            try
            {
                _department.Create(department);

                return Ok(new {message = "The new department has been added to the system."});
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region PUT

        [HttpPut, Route("edit")]
        public ActionResult Edit(Division department)
        {
            try
            {
                _department.Edit(department);
                return Ok(new {message = $"{department.Name} has been edited." });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        #endregion

        #region DELETE

        [HttpDelete, Route("delete")]
        public ActionResult Delete(Division department)
        {
            try
            {
                _department.SoftDelete(department);

                return Ok(new { message = "Department has been deleted" });
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        #endregion
    }
}
