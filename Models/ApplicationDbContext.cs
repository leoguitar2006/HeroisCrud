using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroisCRUD.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HEROIS", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HeroisCRUD.Models.Heroi> Herois { get; set; }

        public System.Data.Entity.DbSet<HeroisCRUD.Models.Universo> Universoes { get; set; }
    }
}