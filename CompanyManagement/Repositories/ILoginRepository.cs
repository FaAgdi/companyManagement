using CompanyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repositories
{
    public interface ILoginRepository
    {
        string Login(UserViewModel model);
    }
}
