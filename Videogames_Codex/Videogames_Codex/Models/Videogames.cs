namespace Videogames_Codex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }

        public int year { get; set; }

        public int genre { get; set; }

        public Genres Genre
        {
            get
            {
                return (Genres)genre;
            }
            set
            {
                if (genre <= 5 && genre >= 0)
                {
                    genre = (int)value;
                }
            }
        }

        public int platform { get; set; }

        public Platforms Platform
        {
            get
            {
                return (Platforms)platform;
            }
            set
            {
                if (platform >= 0 && platform <= 5)
                {
                    platform = (int)value;
                }
            }
        }

        public int score { get; set; }

        public bool online { get; set; }

        public int pegi { get; set; }

        public Pegi Pegi
        {
            get
            {
                return (Pegi)pegi;
            }
            set
            {
                if (pegi >= 0 && pegi <= 4)
                { 
                    pegi = (int)value;
                }
            }
        }

        public static List<Videogames> SelectAll()
        {
            List<Videogames> videogames = new List<Videogames>();
            try
            {
                VideogamesContext context = new VideogamesContext();
                videogames = context.Videogames.OrderBy(x => x.name).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha habido un error al leer la base de datos: " + e);
            }
            return videogames;
        }

        public static Videogames Get(int id)
        {
            Videogames videogame = new Videogames();
            try
            {
                VideogamesContext context = new VideogamesContext();
                videogame = context.Videogames.Where(x => x.id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return videogame;
        }

        public void Save()
        {
            bool create = this.id == 0;
            try
            {
                VideogamesContext context = new VideogamesContext();
                if (create)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                    
                }
                else
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    
                }
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete()
        {
            try
            {
                VideogamesContext context = new VideogamesContext();
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Videogames> Ranking()
        {
            List<Videogames> ranking = new List<Videogames>();
            try
            {
                VideogamesContext context = new VideogamesContext();
                ranking = context.Videogames.OrderByDescending(x => x.score).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine("Ha habido un error al leer la base de datos: " + e);
            }
            return ranking;
        }
    }
}
