using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace Application
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write new category name:");
            string str = Console.ReadLine();
            StudentCategory category = 
                new StudentCategory
                {
                    Name = str
                };
             
            using (var context = new AppDbContext())
            {
                context.StudentCategories.Add(category);
                context.SaveChanges();
                var result = context.Database.SqlQuery<StudentCategory>("SELECT * FROM dbo.StudentCategories");
                Console.WriteLine("SUCCESS! You've just added: ");
                Console.WriteLine(result.Where(x => x.Name == category.Name).Select(x => x.Name).First());
            }
            
        }
    }
}
