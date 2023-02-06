using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Entidades
{
    public class UsuarioTests
    {
        [Fact]
        public void DeveCriarUmaPlaylistComSucesso()
        {
            var user = new Usuario();
            user.CriarPlaylist("XPTO", true);

            Assert.True(user.Playlists.Count > 0);
        }

        [Fact]
        public void DeveExcluirUmaPlaylistComSucesso()
        {
            var user = new Usuario();
            user.CriarPlaylist("XPTO", true);

            var playlist = user.Playlists.First();

            user.ExcluirPlaylist(playlist);

            Assert.True(user.Playlists.Count == 0);

        }
    }
}
