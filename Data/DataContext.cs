using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace quizletBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<NoteSet>()
                .HasOne(n => n.User)
                .WithMany(u => u.NoteSets)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.NoteSet)
                .WithMany(n => n.Cards)
                .HasForeignKey(c => c.NoteSetId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<NoteSet> NoteSets { get; set; }
    }
}