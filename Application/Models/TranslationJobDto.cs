using Application.Contracts;
using AutoMapper;
using Domain.Models;

namespace Application.Models
{
    public class TranslationJobDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public JobStatus Status { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
        public double Price { get; set; }
    }

    public class TranslationJobProfile : Profile
    {
        public TranslationJobProfile()
        {
            CreateMap<TranslationJobDto, TranslationJob>()
                 .ReverseMap();
        }
    }
}
