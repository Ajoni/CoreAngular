using System;
using Entities;
using Entities.Fields;
using Entities.Form;
using Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<FormData> FormDatas { get; set; }
        public DbSet<DataTemplate> DataTemplates { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<Validator> Validators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValidatorField>().HasKey(vf => new {vf.FieldId, vf.ValidatorId});

            //modelBuilder.Entity<ValidatorField>()
            //.HasOne(vf => vf.Field)
            //    .WithMany(f => f.Validators)
            //    .HasForeignKey(vf => vf.FieldId);

            //modelBuilder.Entity<ValidatorField>()
            //.HasOne(vf => vf.Validator)
            //    .WithMany(v => v.ValidatedFields)
            //    .HasForeignKey(vf => vf.ValidatorId);
        }
    }

}
