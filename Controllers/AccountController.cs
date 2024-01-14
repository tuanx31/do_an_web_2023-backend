using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Models;
using web_api.Reponsitory.Abastract;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountRepo;

        public AccountController(IAccountService  repo) {
        accountRepo = repo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            var result = await accountRepo.GetAllAccount();
            if (result == null)
            {
                return new List<ApplicationUser>();
            }
            return result;
        }


        [HttpPost("signUp")]
        public async Task<IActionResult> signUp(SignUpModel model)
        {
            var result = await accountRepo.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else
            {   
            return Unauthorized();
            }
        }
        [HttpPost("signIn")]
        public async Task<IActionResult> signIn(SignInModel model)
        {
            var result = await accountRepo.SignInAsync(model);
            if (string.IsNullOrEmpty(result.Item1))
            {
                return Unauthorized();
            }
            return Ok(result);
        }


        [HttpGet("getCountUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getCountUser()
        {
            var result = await accountRepo.getCountUser();
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpGet("getUser/{email}")]

        public async Task<IActionResult> getUser(string email)
        {
            var user = await accountRepo.GetUserByEmail(email);
            var role = await accountRepo.GetRoleAsyncbyuser(user);
            if (user != null && role!=null) {
            return Ok(new { user, role });
            }
            return Unauthorized();
        }

        [HttpDelete("{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deleteUSer(string email)
        {
            try
            {
                var result= await accountRepo.deleteUser(email);
                return Ok(new {ms=result});
            }catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet("getAllRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> getAllRole()
        {
            var result = await accountRepo.getAllRole();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> editUser(string id ,AccountEditModel model)
        {
            var result = await accountRepo.editUser(id, model);
            return Ok(result);
        }
        //[HttpPost("getId")]
        //public async Task<IActionResult> getIdbyEmail (string id)
        //{
        //    var result = await accountRepo.getIDbyMail(id);
        //    return Ok(result);
        //}

    }
}
