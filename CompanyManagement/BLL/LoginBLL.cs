using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;

namespace CompanyManagement.BLL
{
    public class LoginBLL
    {
        ILoginRepository lg;

        public LoginBLL()
        {
            lg = FactoryRepository.FactoryRepository.loginRep();
        }
        public string Login(UserViewModel model)
        {
            return lg.Login(model);
        }
    }
}