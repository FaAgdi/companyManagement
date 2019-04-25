using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.ViewModel;
using CompanyManagement.Models;

namespace CompanyManagement.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private CompanyManagementEntities _db = new CompanyManagementEntities();

        public string Login(UserViewModel model)
        {
            string un = model.email;
            string Password = model.password;
            var user = _db.user.Where(u => u.email == un).FirstOrDefault();
            if (user != null && Password != null)
            {
                if (Password == user.password)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "-1";
            }
        }
    }
}