using Application.Contracts;
using Application.CQRS.CommandHandlers;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.CQRS.QueryHandlers;
using Application.Models;
using AutoMapper;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using TranslationManagement.Tests.Mocks;
using Xunit;

namespace TranslationManagement.Tests
{
    public class TranslatorsHandlersTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITranslatorRepository> _repository;

        public TranslatorsHandlersTests()
        {
            _repository = MockTranslatorRepository.GetTranslatorRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TranslatorProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllTranslatorsHandler_Should_ReturnArray()
        {
            // Arrange
            var handler = new GetAllTranslatorsHandler(_mapper, _repository.Object);

            // Act
            var result = await handler.Handle(new GetAllTranslators(), CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();

            result.ShouldBeOfType<TranslatorDto[]>();

            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task CreateTranslatorHandler_Should_AddTranslator()
        {
            // Arrange
            var handler = new CreateTranslatorHandler(_mapper, _repository.Object);

            // Act
            var before = await _repository.Object.GetAllAsync();
            before.Count.ShouldBe(2);

            var result = await handler.Handle(new CreateTranslator
            {
                Translator = new TranslatorDto
                {
                    CreditCardNumber = "555",
                    HourlyRate = "1000",
                    Name = "John Rambo",
                    Status = TranslatorStatus.Applicant
                }
            }, CancellationToken.None);

            // Assert
            result.ShouldBeTrue();

            var getAll = await _repository.Object.GetAllAsync();

            getAll.Count.ShouldBe(3);
        }
    }
}