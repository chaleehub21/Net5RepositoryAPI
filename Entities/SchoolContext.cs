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

        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Studen> Studens { get; set; }
    }
}
