using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class TeacherFacade
    {   
        public void CreateTeacher(TeacherDTO teacher)
        {
            Teacher newTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }


        public List<TeacherDTO> GetAllTeachers()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Teachers.ToList();
                return result
                    .Select(a => Mapping.Mapper.Map<TeacherDTO>(a))
                    .ToList();
            }
        }


        public void UpdateTeacher(TeacherDTO teacher)
        {
            var upTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(upTeacher).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveTeacher(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Teachers.Find(id);
                context.Teachers.Remove(result);
                context.SaveChanges();
            }
        }
    }
}

