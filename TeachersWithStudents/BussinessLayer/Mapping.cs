using AutoMapper;
using BussinessLayer.DTO;
using DataAccessLayer.Entities;

namespace BussinessLayer
{
    public static class Mapping
    {
        public static IMapper Mapper { get; }

        static Mapping()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentCategory, StudentCategoryDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name));
                
                c.CreateMap<QuestionCategory, QuestionCategoryDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name));

                c.CreateMap<Answer, AnswerDTO>()
                    .ForMember(dest => dest.Question,
                        opts => opts.MapFrom(
                            src => src.Question.Id))
                    .ForMember(dest => dest.Correct,
                        opts => opts.MapFrom(
                            src => src.Correct));

                c.CreateMap<Exam, ExamDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name))
                    .ForMember(dest => dest.Category,
                        opts => opts.MapFrom(
                            src => src.Category.Id))
                    .ForMember(dest => dest.Duration,
                        opts => opts.MapFrom(
                            src => src.Duration))
                    .ForMember(dest => dest.End,
                        opts => opts.MapFrom(
                            src => src.End))
                    .ForMember(dest => dest.Start,
                        opts => opts.MapFrom(
                            src => src.Start))
                    .ForMember(dest => dest.Subject,
                        opts => opts.MapFrom(
                            src => src.Subject.Id));

                c.CreateMap<Question, QuestionDTO>()
                    .ForMember(dest => dest.Category,
                        opts => opts.MapFrom(
                            src => src.Category.Id))
                    .ForMember(dest => dest.Points,
                        opts => opts.MapFrom(
                            src => src.Points))
                    .ForMember(dest => dest.Task,
                        opts => opts.MapFrom(
                            src => src.Task));

                c.CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name))
                    .ForMember(dest => dest.Category,
                        opts => opts.MapFrom(
                            src => src.Category.Id))
                    .ForMember(dest => dest.Login,
                        opts => opts.MapFrom(
                            src => src.Login))
                    .ForMember(dest => dest.Password,
                        opts => opts.MapFrom(
                            src => src.Password));

                c.CreateMap<Teacher, TeacherDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name))
                    .ForMember(dest => dest.Login,
                        opts => opts.MapFrom(
                            src => src.Login))
                    .ForMember(dest => dest.Password,
                        opts => opts.MapFrom(
                            src => src.Password));

                c.CreateMap<Subject, SubjectDTO>()
                    .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(
                            src => src.Name))
                    .ForMember(dest => dest.Category,
                        opts => opts.MapFrom(
                            src => src.Category.Id))
                    .ForMember(dest => dest.AssignedTeacher,
                        opts => opts.MapFrom(
                            src => src.AssignedTeacher.Id));


            });
            Mapper = config.CreateMapper();
        }
    }
}
 