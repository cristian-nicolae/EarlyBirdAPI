using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
        public interface ICategoriesService
        {
            IEnumerable<ViewCategoryDto> GetAll();
            ViewCategoryDto GetById(int id);
            ViewCategoryDto GetByName(string name);
            bool Delete (int id);
            ViewCategoryDto Add(AddCategoryDto addCategoryDto);
            bool Update(int id, AddCategoryDto addCategoryDto);
        }

}