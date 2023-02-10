using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Tests.Entidades
{
    public class PlaylistTests
    {
        [Fact]
        public void DeveAdicionarUmaMusicaCorretamente()
        {
            Playlist play = new Playlist();
            Musica musica = new Musica()
            {
                Nome = "Dummy Music",
                Id = 1
            };

            play.AdicionarMusica(musica);

            Assert.True(play.Musicas.Count() > 0);
            Assert.Contains(play.Musicas, x => x.Id == musica.Id);
        }

        [Fact]
        public void DeveCriarExcecaoCasoAMusicaJatenhaSidoIncluida()
        {
            Playlist play = new Playlist();
            Musica musica = new Musica()
            {
                Nome = "Dummy Music",
                Id = 1
            };

            play.AdicionarMusica(musica);

            Assert.Throws<Exception>(() =>
            {
                play.AdicionarMusica(musica);
            });
        }

        [Fact]
        public void DeveExcluirMusicaDaPlaylist()
        {
            Playlist play = new Playlist();
            Musica musica = new Musica()
            {
                Nome = "Dummy Music",
                Id = 1
            };

            play.AdicionarMusica(musica);

            play.ExcluirMusica(musica);

            Assert.True(play.Musicas.Count == 0);
        }
    }
}
