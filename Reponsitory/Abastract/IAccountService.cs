using Microsoft.AspNetCore.Identity;
using web_api.Models;

namespace web_api.Reponsitory.Abastract
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync (SignUpModel model);
        public Task<string> SignInAsync (SignInModel model);
    }
}
