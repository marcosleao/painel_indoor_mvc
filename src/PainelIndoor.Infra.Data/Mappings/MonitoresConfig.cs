using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PainelIndoor.Application.Entities;

namespace PainelIndoor.Infra.Data.Mappings
{
    public class MonitoresConfig : IEntityTypeConfiguration<Paineis>
    {
        public void Configure(EntityTypeBuilder<Paineis> b)
        {
            // Primary key
            b.HasKey(e => e.Id);

            b.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            b.Property(e => e.CodEmpresa)
                .IsRequired()
                .HasColumnType("varchar(4)")
                .HasMaxLength(4);

            b.Property(e => e.CodFilial)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            b.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            b.Property(e => e.ChaveCentroCusto)
               .HasColumnType("varchar(30)")
               .HasMaxLength(30);

            b.HasMany(m => m.Conteudo)
                .WithOne()
                .HasForeignKey(m => m.MonitorId);

            b.HasOne(m => m.Filial)
                .WithMany()
                .HasForeignKey(m => m.CodFilial);

            b.ToTable("Monitores", "Paineis");
        }
    }
}
