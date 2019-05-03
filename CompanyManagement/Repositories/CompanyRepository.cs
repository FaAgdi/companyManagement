using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private CompanyManagementEntities _db = new CompanyManagementEntities();
        public List<company> GetCompanies()
        {
            List<company> Complist = new List<company>();

            Complist = (from u in _db.company select u).ToList();

            return Complist;
        }
    }
}