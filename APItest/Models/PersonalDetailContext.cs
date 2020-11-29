using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItest.Models
{
    public class PersonalDetailContext : DbContext
    {
        public PersonalDetailContext(DbContextOptions<PersonalDetailContext> options) : base(options)
        { }

        public DbSet<PersonalDetail> PersonalDetails { get; set; }
    }
}
