using AutoMapper;
using Domain.Models;

namespace Application.Models
{
    public class TranslatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }
    }

    public class TranslatorProfile : Profile
    {
        public TranslatorProfile()
        {
            CreateMap<TranslatorDto, Translator>()
                .ReverseMap();
        }
    }
}
