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
        private readonly EarlyBirdContext context;
        public CategoriesRepository(EarlyBirdContext context) 
        {
            this.context = context;
        }
        public CategoryEntity Add(CategoryEntity categoryEntity)
        {
            context.Categories.Add(categoryEntity);
            context.SaveChanges();
            return categoryEntity;
        }

        public bool Delete(CategoryEntity categoryEntity)
        {
            context.Remove(categoryEntity);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return context.Categories.ToList();
        }

        public CategoryEntity GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public CategoryEntity GetByName(string name)
        {
            return context.Categories.FirstOrDefault(c => c.Name == name);
        }

        public bool Update(int id, CategoryEntity categoryEntity)
        {
            var oldCategory = GetById(id);
            oldCategory.Name = categoryEntity.Name;
            return context.SaveChanges() > 0; 
        }

        public bool CategoryExists(int id)
        {
            return context.Categories.Any(x => x.Id == id);
        }

    }
}
