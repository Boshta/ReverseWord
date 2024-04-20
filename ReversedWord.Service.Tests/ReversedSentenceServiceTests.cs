using Moq;
using ReversedWord.Repository;
using ReverseWord.domain;

namespace ReversedWord.Service.Tests
{
    public class Tests
    {
        private Mock<IReversedSentenceRepository> ReversedSentenceRepositoryMoq;

        [SetUp]
        public void Setup()
        {
            ReversedSentenceRepositoryMoq = new Mock<IReversedSentenceRepository>();
            ReversedSentenceRepositoryMoq.Setup(x => x.AddReversedSentenceCache(It.IsAny<ReversedSentenceCache>())).ReturnsAsync(true);
        }

        [Test]
        public async Task GetRversedSentence_AddRecordToCache()
        {
            var request = "Hi I am a sentence";
            var response = "iH I ma a ecnetnes";
            ReversedSentenceCache nullreversedSentenceCache = null;

            ReversedSentenceRepositoryMoq.Setup(x => x.GetReversedSentenceCache(request)).ReturnsAsync(nullreversedSentenceCache);
            //ReversedSentenceRepositoryMoq.Setup(x => x.AddReversedSentenceCache(It.IsAny<ReversedSentenceCache>())).ReturnsAsync(true);
            var service = new ReversedSentenceService(ReversedSentenceRepositoryMoq.Object);

            var result = await service.GetRversedSentence(request);
            ReversedSentenceRepositoryMoq.Verify(x => x.AddReversedSentenceCache(It.IsAny<ReversedSentenceCache>()), Times.Once);
            

            Assert.AreEqual(response, result);
        }

        [Test]
        public async Task GetRversedSentence_GetRecordToCache()
        {
            var request = "Hi I am a sentence";
            var response = "iH I ma a ecnetnes";
            ReversedSentenceCache nullreversedSentenceCache = new ReversedSentenceCache{
                Id= 1,
                OriginalSentence = request,
                ReversedSentence = response
            };

            ReversedSentenceRepositoryMoq.Setup(x => x.GetReversedSentenceCache(request)).ReturnsAsync(nullreversedSentenceCache);
            
            var service = new ReversedSentenceService(ReversedSentenceRepositoryMoq.Object);

            var result = await service.GetRversedSentence(request);
            ReversedSentenceRepositoryMoq.Verify(x => x.AddReversedSentenceCache(It.IsAny<ReversedSentenceCache>()), Times.Never);


            Assert.AreEqual(response, result);
        }
    }
}