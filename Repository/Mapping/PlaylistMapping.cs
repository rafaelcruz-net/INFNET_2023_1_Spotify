﻿using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapping
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.IsPublica).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);

            builder.HasMany(x => x.Musicas).WithMany(x => x.Playlists);
        }
    }
}
