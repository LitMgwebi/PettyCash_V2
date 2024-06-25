using PettyCashPrototype.Mappers.UserMapper;

namespace PettyCashPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IAuth _auth;

        public UsersController(IUser user, IAuth auth)
        {
            _user = user;
            _auth = auth;
        }

        #region Auth

        [HttpPost, Route("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            try
            {
                User user = await _user.GetUserByEmail(loginModel.Email);

                if(await _auth.ValidateUser(loginModel.Password, user))
                {
                    UserMapper userMapper = await _user.GetMappedUserByEmail(user);
                    JWTToken jwt = await _auth.CreateToken(user);
                    return Ok(new { jwt, message = "You are logged in.", user = userMapper });
                }
                return Unauthorized("Incorrect Email or Password.");
            } catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost, Route("register")]
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                string id = await _user.Create(user, user.PasswordHash!);

                if(id != null)
                {
                    return Ok(new { message = "Your profile has been created, but awaits authorization by Admin. You will be communicated when authorized." });
                    //JWTToken token = await _auth.CreateToken(user);
                    //UserMapper userMapper = await _user.GetMappedUserByEmail(user.Email!);
                    //return Ok(new { token, message = "You are logged in.", user = userMapper });
                }
                return Problem("Could not register user to system.");
            } catch(Exception ex) { return BadRequest(new {ex}); }
        }
        #endregion
    }
}
