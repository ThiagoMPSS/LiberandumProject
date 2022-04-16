using LiberandumAPI.Db.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Db.Context;
using WebApplication3.Models;

namespace LiberandumAPI.Controllers {
    [ApiController, Route("api/[controller]")]
    public class EventosController : ControllerBase {

        [HttpPost]
        public IActionResult CriarEvento(Evento evento) {
            var Db = DatabaseContext.Instance;
            try {
                Db.Add(evento);
                Db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex);
            } finally {
                Db.ChangeTracker.Clear();
            }
        }

        [HttpGet]
        public IActionResult GetEventos(int PerfilId, int EventoId = -1) {
            var Db = DatabaseContext.Instance;
            try {
                if (EventoId == -1)
                    return Ok(Db.Evento?.Where(e => e.PerfilId == PerfilId));
                else
                    return Ok(Db.Evento?.Find(EventoId));
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Necessidade")]
        public IActionResult CriarNecessidade(Necessidade necessidade) {
            var Db = DatabaseContext.Instance;
            try {
                Db.Add(necessidade);
                Db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex);
            } finally {
                Db.ChangeTracker.Clear();
            }
        }

        [HttpGet, Route("Necessidade")]
        public IActionResult GetNecessidade(int Id = -1) {
            var Db = DatabaseContext.Instance;
            try {
                if (Id == -1)
                    return Ok(Db.Evento?.ToList());
                else
                    return Ok(Db.Evento?.Find(Id));
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

    }
}
