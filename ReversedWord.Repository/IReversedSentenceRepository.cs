using ReverseWord.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedWord.Repository
{
    public interface IReversedSentenceRepository
    {
        Task<ReversedSentenceCache> GetReversedSentenceCache(string Sentence);
        Task<bool> AddReversedSentenceCache(ReversedSentenceCache reversedSentenceCache);
    }
}
