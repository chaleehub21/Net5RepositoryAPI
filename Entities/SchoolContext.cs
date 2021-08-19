#nullable disable

using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Studen> Studens { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
