using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public CategoryEntity Add(CategoryEntity categoryEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(CategoryEntity categoryEntity)
        {
            throw new NotImplementedException();
        }
    }
}
