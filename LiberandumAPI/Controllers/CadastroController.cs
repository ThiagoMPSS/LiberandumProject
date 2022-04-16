using LiberandumAPI.Db.Context;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace LiberandumAPI.Controllers {

    [ApiController, Route("api/[controller]")]
    public class CadastroController : ControllerBase {

        //Perfil
        [HttpPost, Route("Perfil")]
        public IActionResult CriarPerfil(Perfil perfil) {
            var db = DatabaseContext.Instance;
            try {
                db.Perfil?.Add(perfil);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

        [HttpGet, Route("Perfil")]
        public IActionResult GetPerfil(int id) {
            var db = DatabaseContext.Instance;
            try {
                return Ok(db.Perfil?.Find(id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("Perfil")]
        public IActionResult AlterarPerfil(Perfil perfil) {
            var db = DatabaseContext.Instance;
            try {
                db.Update(perfil);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

        //Usuario
        [HttpPost, Route("Usuario")]
        public IActionResult CriarUsuario(Usuario usuario) {
            var db = DatabaseContext.Instance;
            try {
                db.Usuario?.Add(usuario);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

        [HttpGet, Route("Usuario")]
        public IActionResult GetUsuario(int id) {
            var db = DatabaseContext.Instance;
            try {
                return Ok(db.Usuario?.Find(id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("Usuario")]
        public IActionResult AlterarUsuario(Usuario usuario) {
            var db = DatabaseContext.Instance;
            try {
                db.Update(usuario);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

        //Categoria
        [HttpPost, Route("Categoria")]
        public IActionResult CriarCategoria(Categoria categoria) {
            var db = DatabaseContext.Instance;
            try {
                db.Categoria?.Add(categoria);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

        [HttpGet, Route("Categoria")]
        public IActionResult GetCategoria(int id) {
            var db = DatabaseContext.Instance;
            try {
                return Ok(db.Categoria?.Find(id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("Categoria")]
        public IActionResult AlterarCategoria(Categoria categoria) {
            var db = DatabaseContext.Instance;
            try {
                db.Update(categoria);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                db.ChangeTracker.Clear();
            }
        }

    }

}
