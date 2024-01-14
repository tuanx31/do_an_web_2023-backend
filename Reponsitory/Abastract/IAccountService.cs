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
        public Task<int> getCountUser();
        public Task<ApplicationUser> GetUserByEmail (string email);
        public Task<IList<string>> GetRoleAsyncbyuser (ApplicationUser user);
        public Task<string> deleteUser(string email);
        public Task<List<IdentityRole>> getAllRole ();
        public Task<string> editUser(string id, AccountEditModel acc);
    }
}
