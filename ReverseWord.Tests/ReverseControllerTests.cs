using Microsoft.AspNetCore.Mvc;
using Moq;
using ReversedWord.Service;
using ReverseWord.Controllers;

namespace ReverseWord.Tests
{
    public class Tests
    {
        private Mock<IReversedSentenceService> ReverseSentenceMoq;
        [SetUp]
        public void Setup()
        {
            ReverseSentenceMoq = new Mock<IReversedSentenceService>();
        }

        [Test]
        public async Task ReverseSentence_WithEmptyRequest_returnsBadRequestAsync()
        {
            var request = string.Empty;
            var controller = new ReverseController(ReverseSentenceMoq.Object);

            var result = await controller.ReverseSentence(request);
            var badRequestResult = result as BadRequestResult;

            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public async Task ReverseSentence_returnsCorrectAnswer()
        {
            var request = "Hi I am a sentence";
            var response = "iH I ma a ecnetnes";

            ReverseSentenceMoq.Setup(x => x.GetRversedSentence(request)).ReturnsAsync(response);

            var controller = new ReverseController(ReverseSentenceMoq.Object);

            var result = await controller.ReverseSentence(request);
            var OkObjectResult = result as OkObjectResult;

            Assert.IsNotNull(OkObjectResult);
            Assert.AreEqual(response, OkObjectResult.Value);
        }
    }
}