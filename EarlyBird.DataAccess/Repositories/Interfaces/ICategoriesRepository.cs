using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        CategoryEntity GetById(int id);
        CategoryEntity GetByName(string name);
        IEnumerable<CategoryEntity> GetAll();
        CategoryEntity Add(CategoryEntity categoryEntity);
        bool Delete(int id);
        bool Update(CategoryEntity categoryEntity);
    }
}
