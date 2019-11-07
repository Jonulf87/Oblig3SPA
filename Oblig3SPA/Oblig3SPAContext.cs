using Microsoft.EntityFrameworkCore;
using Oblig3SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA
{
    public class Oblig3SPAContext : DbContext
    {
        public Oblig3SPAContext(DbContextOptions<Oblig3SPAContext> options)
            : base(options)
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
