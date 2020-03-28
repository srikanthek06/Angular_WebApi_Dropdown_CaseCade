using CaseCaddingDDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseCaddingDDL.Data
{
    public class CascadeContext : DbContext
    {
        public CascadeContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StateMaster>().ToTable("StateMaster");
            builder.Entity<CountryMaster>().ToTable("CountryMaster");
        }

        public DbSet<StateMaster> States { get; set; }
        public DbSet<CountryMaster> Country { get; set; }
    }
}
