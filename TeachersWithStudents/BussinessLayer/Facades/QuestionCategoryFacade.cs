using System;
using System.Collections.Generic;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class QuestionCategoryFacade
    {
        public void CreateCategory(QuestionCategoryDTO category)
        {
            QuestionCategory newCategory = Mapping.Mapper.Map<QuestionCategory>(category);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.QuestionCategories.Add(newCategory);
                context.SaveChanges();
            }
        }

        public List<QuestionCategoryDTO> GetAllCategories()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var categories = context.QuestionCategories.ToList();
                return categories
                    .Select(element => Mapping.Mapper.Map<QuestionCategoryDTO>(element))
                    .ToList();
            }
        }

        public void DeleteCategory(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var cat = context.StudentCategories.Find(id);
                context.StudentCategories.Remove(cat);
                context.SaveChanges();
            }
        }
    }
}
