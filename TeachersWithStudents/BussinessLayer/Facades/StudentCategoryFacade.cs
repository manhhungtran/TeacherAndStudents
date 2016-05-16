using System;
using System.Collections.Generic;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class StudentCategoryFacade
    {
        public void CreateCategory(StudentCategoryDTO category)
        {
            StudentCategory newCategory = Mapping.Mapper.Map<StudentCategory>(category);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.StudentCategories.Add(newCategory);
                context.SaveChanges();
            }
        }


        public List<StudentCategoryDTO> GetAllCategories()
        {
            using (var context = new AppDbContext())
            {
                var categories = context.StudentCategories.ToList();
                return categories
                    .Select(element => Mapping.Mapper.Map<StudentCategoryDTO>(element))
                    .ToList();
            }
        }


        public void DeleteCategory(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var cat = context.StudentCategories.Find(id);
                context.StudentCategories.Remove(cat);
                context.SaveChanges();
            }
        }
    }
}
