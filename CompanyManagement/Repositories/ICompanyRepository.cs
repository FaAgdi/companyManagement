using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.Repositories
{
    public interface ICompanyRepository
    {
        List<company> GetCompanies();
    }
}
