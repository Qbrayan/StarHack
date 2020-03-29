using Microsoft.EntityFrameworkCore;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>().ToTable("Characters");
            builder.Entity<Person>().HasKey(p => p.Id);
            builder.Entity<Person>().Property(p => p.name).IsRequired();
            builder.Entity<Person>().Property(p => p.height).IsRequired();
            builder.Entity<Person>().Property(p => p.mass).IsRequired();
            builder.Entity<Person>().Property(p => p.homeworld).IsRequired();
            builder.Entity<Person>().Ignore(p => p.birth_year);
            //builder.Entity<Person>().HasMany(p => p.Products).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);



        }

    }
}
