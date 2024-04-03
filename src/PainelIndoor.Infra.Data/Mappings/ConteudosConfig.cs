using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PainelIndoor.Application.Entities;

namespace PainelIndoor.Infra.Data.Mappings
{
    public class ConteudosConfig : IEntityTypeConfiguration<Conteudos>
    {
        public void Configure(EntityTypeBuilder<Conteudos> b)
        {
            // Primary key
            b.HasKey(e => e.Id);

            b.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            b.Property(e => e.Caminho)
                .IsRequired()
                .HasColumnType("varchar(600)")
                .HasMaxLength(600);

            b.Property(e => e.FilePath)
               //.IsRequired()
               .HasColumnType("varchar(600)")
               .HasMaxLength(600);

            b.Property(e => e.Descricao)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            b.ToTable("Conteudos", "Paineis");
        }
    }
}
