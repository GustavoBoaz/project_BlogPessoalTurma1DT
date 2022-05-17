using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogPessoal.src.modelos;
using System.Linq;
using BlogPessoal.src.utilidades;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Karol Boaz";
            usuario.Email = "karol@email.com";
            usuario.Senha = "134652";
            usuario.Foto = "AKITAOLINKDAFOTO";
            usuario.Tipo = TipoUsuario.NORMAL;

            _contexto.Usuarios.Add(usuario); // Adcionando usuario

            _contexto.SaveChanges(); // Commita cria��o

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "karol@email.com"));
        }
    }
}
