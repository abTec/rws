using Application.Contracts;
using Domain.Models;
using Moq;
using System.Collections.Generic;

namespace TranslationManagement.Tests.Mocks
{
    public static class MockTranslatorRepository
    {
        public static Mock<ITranslatorRepository> GetTranslatorRepository()
        {
            var translators = new List<Translator>
            {
                new Translator
                {
                    Id = 1,
                    CreditCardNumber = "666",
                    HourlyRate = "100",
                    Name = "Andrew Tate",
                    Status = TranslatorStatus.Applicant.ToString(),
                },
                new Translator
                {
                    Id = 2,
                    CreditCardNumber = "777",
                    HourlyRate = "1000",
                    Name = "Hasbulla Magomedov",
                    Status = TranslatorStatus.Certified.ToString(),
                },
            };

            var repo = new Mock<ITranslatorRepository>();

            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(translators);

            repo.Setup(r => r.CreateAsync(It.IsAny<Translator>())).ReturnsAsync((Translator trans) =>
            {
                translators.Add(trans);
                return true;
            });

            return repo;
        }

    }
}
