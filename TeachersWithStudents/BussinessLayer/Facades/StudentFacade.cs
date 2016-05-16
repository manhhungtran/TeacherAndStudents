using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class StudentFacade
    {
        public void CreateStudent(StudentDTO teacher)
        {
            Student newTeacher = Mapping.Mapper.Map<Student>(teacher);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Students.Add(newTeacher);
                context.SaveChanges();
            }
        }


        public List<StudentDTO> GetAllStudents()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Students.ToList();
                return result
                    .Select(a => Mapping.Mapper.Map<StudentDTO>(a))
                    .ToList();
            }
        }


        public void UpdateStudent(StudentDTO student)
        {
            Student upStudent = Mapping.Mapper.Map<Student>(student);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(upStudent).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveStudent(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Students.Find(id);
                context.Students.Remove(result);
                context.SaveChanges();
            }
        }

        public List<StudentDTO> GetStudentByCategory(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Students.ToList();
                return result
                    .Where(element => element.Category.Id == id)
                    .Select(a => Mapping.Mapper.Map<StudentDTO>(a))
                    .ToList();
            }
        }

        public StudentDTO GetStudentByID(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Students.ToList();
                return result
                    .Where(element => element.Id == id)
                    .Select(a => Mapping.Mapper.Map<StudentDTO>(a))
                    .First();
            }
        }

        public StudentDTO GetStudentByLogin(string login)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Students.ToList();
                return result
                    .Select(a => Mapping.Mapper.Map<StudentDTO>(a))
                    .ToList()
                    .First(element => element.Login == login);
            }
        }
    }
}
