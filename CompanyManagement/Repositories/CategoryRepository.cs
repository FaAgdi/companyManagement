using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CompanyManagementEntities _db = new CompanyManagementEntities();
        public List<category> GetCategories()
        {
            List<category> Catlist = new List<category>();

            Catlist = (from u in _db.category select u).ToList();

            return Catlist;
        }
    }
}