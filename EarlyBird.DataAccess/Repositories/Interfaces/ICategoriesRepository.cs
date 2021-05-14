using EarlyBird.DataAccess.Entities;
using System.Collections.Generic;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        CategoryEntity GetById(int id);
        CategoryEntity GetByName(string name);
        IEnumerable<CategoryEntity> GetAll();
        CategoryEntity Add(CategoryEntity categoryEntity);
        bool Delete(CategoryEntity categoryEntity);
        bool Update(int id, CategoryEntity categoryEntity);
        public bool CategoriesExist(IEnumerable<int> ids);

    }
}
