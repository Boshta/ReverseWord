using ReversedWord.Repository;
using ReverseWord.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedWord.Service
{
    public class ReversedSentenceService : IReversedSentenceService
    {
        private readonly IReversedSentenceRepository _reversedSentenceRepository;

        public ReversedSentenceService(IReversedSentenceRepository reversedSentenceRepository)
        {
            _reversedSentenceRepository = reversedSentenceRepository;
        }

        public async Task<string> GetRversedSentence(string Sentence)
        {
            var reversedSentence = await GetReversedSentenceFromCache(Sentence);
            if (string.IsNullOrEmpty(reversedSentence))
            {
                reversedSentence = GetReversedSentence(Sentence);

                await AddReversedSentenceToCache(Sentence, reversedSentence);

                return reversedSentence;
            }
            else
            {
                return reversedSentence;
            }
        }

        private async Task<string> GetReversedSentenceFromCache(string Sentence)
        {
            var reversedSentence = string.Empty;

            var reversedSentenceFromCache = await _reversedSentenceRepository.GetReversedSentenceCache(Sentence);

            if (reversedSentenceFromCache != null)
            {
                reversedSentence= reversedSentenceFromCache.ReversedSentence;
            }

            return reversedSentence;
        }

        private async Task AddReversedSentenceToCache(string Sentence, string reversedSentence)
        {
            await _reversedSentenceRepository.AddReversedSentenceCache(new ReversedSentenceCache
            {
                OriginalSentence = Sentence,
                ReversedSentence = reversedSentence
            });
        }

        private string GetReversedSentence(string Sentence)
        {
            return string.Join(" ", Sentence.Split(' ')
                                           .Select(word => new string(word.Reverse().ToArray())));
        }
    }
}
