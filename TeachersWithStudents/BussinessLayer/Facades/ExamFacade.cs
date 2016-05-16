using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class ExamFacade
    {
        public List<ExamDTO> GetExamsByCategory(long category)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Exams
                    .ToList()
                    .Where(element => element.Category.Id == category)
                    .Select(element => Mapping.Mapper.Map<ExamDTO>(element))
                    .ToList();
            }
        }


        public void CreateExam(ExamDTO exam)
        {
            Exam newExam = Mapping.Mapper.Map<Exam>(exam);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Exams.Add(newExam);
                context.SaveChanges();
            }
        }


        public void UpdateExam(Exam exam)
        {
            Exam newExam = Mapping.Mapper.Map<Exam>(exam);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(newExam).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveExam(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Exams.Find(id);
                context.Exams.Remove(result);
                context.SaveChanges();
            }
        }


        public List<ExamDTO> GetExamsBySubject(long subject)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Exams
                    .ToList()
                    .Where(element => element.Subject.Id == subject)
                    .Select(element => Mapping.Mapper.Map<ExamDTO>(element))
                    .ToList();
            }
        }


        public List<ExamDTO> GetExamsByName(string name)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Exams
                    .ToList()
                    .Where(element => element.Name == name)
                    .Select(element => Mapping.Mapper.Map<ExamDTO>(element))
                    .ToList();
            }
        }


        public List<ExamDTO> GetAllExams()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Exams
                    .ToList()
                    .Select(element => Mapping.Mapper.Map<ExamDTO>(element))
                    .ToList();
            }
        }


        public List<ExamDTO> GetActiveExams()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Exams
                    .ToList()
                    .Where(element => element.Start > DateTime.Today && element.End < DateTime.Today)
                    .Select(element => Mapping.Mapper.Map<ExamDTO>(element))
                    .ToList();
            }
        }
    }
}
