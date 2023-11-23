using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
