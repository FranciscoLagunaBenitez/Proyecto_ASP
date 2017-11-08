namespace Videogames_Codex.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VideogamesContext : DbContext
    {
        public VideogamesContext()
            : base("name=VideogamesContext")
        {
        }

        public virtual DbSet<Videogames> Videogames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
