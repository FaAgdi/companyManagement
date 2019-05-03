using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;
using CompanyManagement.Models;

namespace CompanyManagement.BLL
{
    public class CompanyBLL
    {
        ICompanyRepository comp;

        public CompanyBLL()
        {
            comp = FactoryRepository.FactoryRepository.GetCompanies();
        }
        public List<company> GetCompanies()
        {
            return comp.GetCompanies();
        }
    }
}