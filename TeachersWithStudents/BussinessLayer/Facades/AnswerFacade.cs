using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using BussinessLayer.DTO;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BussinessLayer.Facades
{
    public class AnswerFacade
    {
        public void CreateAnswer(AnswerDTO answer)
        {
            Answer newAnswer = Mapping.Mapper.Map<Answer>(answer);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Answers.Add(newAnswer);
                context.SaveChanges();
            }
        }


        public void UpdateAnswer(AnswerDTO answer)
        {
            Answer newAnswer = Mapping.Mapper.Map<Answer>(answer);

            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                context.Entry(newAnswer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void RemoveAnswer(long id)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                var result = context.Answers.Find(id);
                context.Answers.Remove(result);
                context.SaveChanges();
            }
        }


        public List<AnswerDTO> GetAllAnswers()
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Answers
                    .ToList()
                    .Select(element => Mapping.Mapper.Map<AnswerDTO>(element))
                    .ToList();
            }
        }


        public List<AnswerDTO> GetAnswersByQuestion(long question)
        {
            using (var context = new AppDbContext())
            {
                context.Database.Log = Logger.Logg;
                return context.Answers
                    .ToList()
                    .Where(element => element.Question.Id == question)
                    .Select(element => Mapping.Mapper.Map<AnswerDTO>(element))
                    .ToList();
            }
        }
    }
}
