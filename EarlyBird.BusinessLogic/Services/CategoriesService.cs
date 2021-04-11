using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;
using EarlyBird.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EarlyBird.BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }
        public IEnumerable<ViewCategoryDto> GetAll()
        {
            return categoriesRepository.GetAll().Select(x => x.ToViewCategoryDto());
        }

        public ViewCategoryDto GetById(int id)
        {
            return categoriesRepository.GetById(id)?.ToViewCategoryDto();
        }
        public ViewCategoryDto GetByName(string name)
        {
            return categoriesRepository.GetByName(name)?.ToViewCategoryDto();
        }
        public bool Delete(int id)
        {
            var category = categoriesRepository.GetById(id);
            if (category == null)
                throw new CategoryNotFoundException();
            return categoriesRepository.Delete(category);
        }
        public ViewCategoryDto Add(AddCategoryDto addCategoryDto)
        {
            var existingCategory = categoriesRepository.GetByName(addCategoryDto.Name);
            if (existingCategory != null)
                throw new CategoryAlreadyExistingException();

            var newCategory = new CategoryEntity
            {
                Name = addCategoryDto.Name
            };
            newCategory = categoriesRepository.Add(newCategory);
            return newCategory.ToViewCategoryDto();
        }

        public bool Update(int id, AddCategoryDto addCategoryDto)
        {
            var category = categoriesRepository.GetById(id);
            if (category == null)
                throw new CategoryNotFoundException();
            var updatedCategory = new CategoryEntity
            {
                Name = addCategoryDto.Name
            };
            return categoriesRepository.Update(id, updatedCategory);
        }

        #region exceptions       

        [System.Serializable]
        public class CategoryAlreadyExistingException : System.Exception
        {
            public CategoryAlreadyExistingException()
            {
            }

            public CategoryAlreadyExistingException(string message) : base(message)
            {
            }

        }

        [Serializable]
        public class CategoryNotFoundException : Exception
        {
            public CategoryNotFoundException()
            {
            }

            public CategoryNotFoundException(string message) : base(message)
            {
            }
        }

        #endregion
    }
}
