using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PainelIndoor.Application.Core.Entities;

namespace PainelIndoor.Infra.Data.Mappings
{
    public class FiliaisConfig : IEntityTypeConfiguration<Filiais>
    {
        public void Configure(EntityTypeBuilder<Filiais> builder)
        {
            // Primary key
            builder.HasKey(f => f.CodFilial);

            builder.Property(f => f.CodEmpresa)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasMaxLength(4);

            builder.Property(f => f.CodFilial)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            builder.Property(f => f.NomeFilial)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(f => f.CnpjFilial)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(c => c.ChaveCentroCusto)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(e => e.Endereco)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.ToTable("Filiais", "Cadastros");
        }
    }
}
