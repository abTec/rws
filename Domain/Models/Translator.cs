﻿using System.Collections.Generic;

namespace Domain.Models
{
    public class Translator : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<TranslationJob> Jobs { get; set; } = new List<TranslationJob>();
    }
}
