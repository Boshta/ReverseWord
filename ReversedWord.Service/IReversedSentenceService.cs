using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedWord.Service
{
    public interface IReversedSentenceService
    {
        Task<String> GetRversedSentence(string Sentence);
    }
}
