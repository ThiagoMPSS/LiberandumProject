using LiberandumAPI.Db.Context;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace LiberandumAPI.Controllers {

    [ApiController, Route("api/[controller]")]
    public class CadastroController : DefaultCadastroController {

        //Perfil
        [HttpPost, Route("Perfil")]
        public IActionResult CriarPerfil(Perfil perfil) {
            return Criar(perfil);
        }

        [HttpGet, Route("Perfil")]
        public IActionResult GetPerfil(int id) {
            return Get<Perfil>(id);
        }

        [HttpPut, Route("Perfil")]
        public IActionResult AlterarPerfil(Perfil perfil) {
            return Alterar(perfil);
        }

        [HttpDelete, Route("Perfil")]
        public IActionResult DeletarPerfil(int id) {
            return Deletar<Perfil>(id);
        }

        //Usuario
        [HttpPost, Route("Usuario")]
        public IActionResult CriarUsuario(Usuario usuario) {
            return Criar(usuario);
        }

        [HttpGet, Route("Usuario")]
        public IActionResult GetUsuario(int id) {
            return Get<Usuario>(id);
        }

        [HttpPut, Route("Usuario")]
        public IActionResult AlterarUsuario(Usuario usuario) {
            return AlterarUsuario(usuario);
        }

        [HttpDelete, Route("Usuario")]
        public IActionResult DeletarUsuario(int id) {
            return Deletar<Usuario>(id);
        }

        //Categoria
        [HttpPost, Route("Categoria")]
        public IActionResult CriarCategoria(Categoria categoria) {
            return Criar(categoria);
        }

        [HttpGet, Route("Categoria")]
        public IActionResult GetCategoria(int id = -1) {
            return Get<Categoria>(id);
        }

        [HttpPut, Route("Categoria")]
        public IActionResult AlterarCategoria(Categoria categoria) {
            return Alterar(categoria);
        }

        [HttpDelete, Route("Categoria")]
        public IActionResult DeletarCategoria(int id) {
            return Deletar<Categoria>(id);
        }

    }

}
