using Microsoft.EntityFrameworkCore;
using ReverseWord.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedWord.Repository
{
    public class ReversedSentenceRepository : IReversedSentenceRepository
    {
        public readonly ApplicationContext _context;

        public ReversedSentenceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReversedSentenceCache(ReversedSentenceCache reversedSentenceCache)
        {
            using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.ReversedSentenceCache.Add(reversedSentenceCache);
                    var result = await _context.SaveChangesAsync();
                    transaction.Commit();
                    return result > 0 ? true : false;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                
            }
            
        }

        public async Task<ReversedSentenceCache> GetReversedSentenceCache(string Sentence)
        {
            return await _context.ReversedSentenceCache.FirstOrDefaultAsync(x => x.OriginalSentence == Sentence);
        }
    }
}
