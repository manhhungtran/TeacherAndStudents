using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class SubjectFacade
    {
        public void CreateSubject(SubjectDTO subject)
        {
            Subject newSubject = Mapping.Mapper.Map<Subject>(subject);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Subjects.Add(newSubject);
                context.SaveChanges();
            }
        }


        public List<SubjectDTO> GetAllSubjects()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Subjects.ToList();
                return result
                    .Select(a => Mapping.Mapper.Map<SubjectDTO>(a))
                    .ToList();
            }
        }


        public void UpdateSubject(SubjectDTO subject)
        {
            Subject upSubjects = Mapping.Mapper.Map<Subject>(subject);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(upSubjects).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveSubject(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Subjects.Find(id);
                context.Subjects.Remove(result);
                context.SaveChanges();
            }
        }


        public List<SubjectDTO> GetSubjectsByCategory(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Subjects.ToList();
                return result
                    .Where(a => a.Category.Id == id)
                    .Select(a => Mapping.Mapper.Map<SubjectDTO>(a))
                    .ToList();
            }
        }


        public List<SubjectDTO> GetSubjectsByTeacher(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Subjects.ToList();
                return result
                    .Where(a => a.AssignedTeacher.Id == id)
                    .Select(a => Mapping.Mapper.Map<SubjectDTO>(a))
                    .ToList();
            }
        }


        public List<SubjectDTO> GetSubjectsByName(string name)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Subjects.ToList();
                return result
                    .Where(a => a.Name == name)
                    .Select(a => Mapping.Mapper.Map<SubjectDTO>(a))
                    .ToList();
            }
        }
    }
}
