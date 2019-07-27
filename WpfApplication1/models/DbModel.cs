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

        public virtual DbSet<Sanatçý> Sanatçýlar { get; set; }
        public virtual DbSet<Albüm> Albümler { get; set; }
        public virtual DbSet<Parça> Parçalar { get; set; }
        public virtual DbSet<Tür> Türler { get; set; }
    }
}