using System.Linq;
using Microsoft.EntityFrameworkCore;
using PocWebApiDapperEf.Core.Domain.Entites;

namespace PocWebApiDapperEf.Infra.PersistenceEf.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Curva> Curvas {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}