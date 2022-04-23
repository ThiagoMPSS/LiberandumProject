using LiberandumAPI.Db.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiberandumAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public abstract class DefaultCadastroController : ControllerBase {
        internal readonly DatabaseContext Db = DatabaseContext.Instance;

        [NonAction]
        public virtual IActionResult Criar(object obj) {
            try {
                Db.ChangeTracker.Clear();
                Db.Add(obj);
                Db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public virtual IActionResult Get<T>(int id) {
            try {
                return Ok(Db.Find(typeof(T), id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public virtual IActionResult Alterar(object obj) {
            try {
                Db.ChangeTracker.Clear();
                Db.Update(obj);
                Db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public virtual IActionResult Deletar<T>(int id) {
            try {
                Db.ChangeTracker.Clear();
                object? obj = Db.Find(typeof(T), id);
                if (obj != null) {
                    Db.Remove(obj);
                }
                Db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
