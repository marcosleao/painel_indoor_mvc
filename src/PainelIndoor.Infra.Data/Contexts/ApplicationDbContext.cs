using Microsoft.EntityFrameworkCore;
using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Infra.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {          
        }

        public DbSet<Filiais> GetFiliais { get; set; }
        public DbSet<Paineis> Monitores { get; set; }
        public DbSet<Conteudos> Conteudos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Aplicar as configurações de an
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
