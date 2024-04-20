using Microsoft.EntityFrameworkCore;
using ReverseWord.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedWord.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        public DbSet<ReversedSentenceCache> ReversedSentenceCache { get; set; }



    }
}
