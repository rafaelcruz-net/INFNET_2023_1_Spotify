using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome)
                   .IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email)
                    .IsRequired().HasMaxLength(200);
            builder.Property(x => x.DtNascimento)
                    .IsRequired();
            builder.Property(x => x.Password)
                    .IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.Playlists).WithOne(x => x.Usuario);
        }
    }
}
