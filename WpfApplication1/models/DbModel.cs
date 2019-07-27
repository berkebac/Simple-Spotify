namespace WpfApplication1.models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<Sanat��> Sanat��lar { get; set; }
        public virtual DbSet<Alb�m> Alb�mler { get; set; }
        public virtual DbSet<Par�a> Par�alar { get; set; }
        public virtual DbSet<T�r> T�rler { get; set; }
    }
}