using Application.Contracts;
using AutoMapper;
using Domain.Models;
using System.Text.Json.Serialization;

namespace Application.Models
{
    public class TranslatorDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public TranslatorStatus Status { get; set; }
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
