namespace Domain.Models
{
    public class TranslationJob : IEntity
    {
        public int Id { get; set; }
        public int? TranslatorId { get; set; }
        public Translator Translator { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
        public double Price { get; set; }
    }
}