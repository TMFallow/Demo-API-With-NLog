using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teacher_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Repo
{
    public class Teacher_Repo_Context : DbContext
    {
        public Teacher_Repo_Context(DbContextOptions<Teacher_Repo_Context> options) : base(options)
        {

        }

        public Teacher_Repo_Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new Teacher_Map(modelBuilder.Entity<Teacher>());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Student_Repo_Context).Assembly);
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}