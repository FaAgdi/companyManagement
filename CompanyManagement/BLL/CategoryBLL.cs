using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;
using CompanyManagement.Models;

namespace CompanyManagement.BLL
{
    public class CategoryBLL
    {
        ICategoryRepository cat;

        public CategoryBLL()
        {
            cat = FactoryRepository.FactoryRepository.GetCategories();
        }
        public List<category> GetCategories()
        {
            return cat.GetCategories();
        }
    }
}