using Microsoft.AspNetCore.Identity;
using web_api.Data;
using web_api.Models;

namespace web_api.Reponsitory.Abastract
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync (SignUpModel model);
        public Task<Tuple<string , AccountModel>> SignInAsync (SignInModel model);
        public Task<string> getIDbyMail (string email);
        public Task<List<ApplicationUser>> GetAllAccount ();
    }
}
