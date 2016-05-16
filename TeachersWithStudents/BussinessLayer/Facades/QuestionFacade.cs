using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class QuestionFacade
    {
        public List<QuestionDTO> GetAllQuestions()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Questions
                    .ToList()
                    .Select(element => Mapping.Mapper.Map<QuestionDTO>(element))
                    .ToList();
            }
        }


        public void CreateQuestion(QuestionDTO question)
        {
            Question newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Questions.Add(newQuestion);
                context.SaveChanges();
            }
        }


        public void UpdateQuestion(QuestionDTO question)
        {
            Question newQuestion = Mapping.Mapper.Map<Question>(question);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(newQuestion).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveQuestion(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Questions.Find(id);
                context.Questions.Remove(result);
                context.SaveChanges();
            }
        }


        public List<QuestionDTO> GetQuestionsByCategory(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Questions
                    .ToList()
                    .Where(element => element.Category.Id == id)
                    .Select(element => Mapping.Mapper.Map<QuestionDTO>(element))
                    .ToList();
            }
        }
    }
}
