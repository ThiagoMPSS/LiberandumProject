using Microsoft.AspNetCore.Mvc;
using WebApplication3.Db.Context;
using WebApplication3.Models;

namespace LiberandumAPI.Controllers {
    [ApiController, Route("api/[controller]")]
    public class EventosController : DefaultCadastroController {

        [HttpPost]
        public IActionResult CriarEvento(Evento evento) {
            return Criar(evento);
        }

        [HttpGet]
        public IActionResult GetEventos(int PerfilId, int EventoId = -1) {
            if (EventoId != -1)
                return Get<Evento>(EventoId);
            else
                try {
                    return Ok(Db.Evento?.Where(e => e.PerfilId == PerfilId));
                } catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
        }

        [HttpPost, Route("Necessidade")]
        public IActionResult CriarNecessidade(Necessidade necessidade) {
            return Criar(necessidade);
        }

        [HttpGet, Route("Necessidade")]
        public IActionResult GetNecessidade(int Id = -1) {
            if (Id != -1)
                return Get<Necessidade>(Id);
            else
                try {
                    return Ok(Db.Necessidade?.ToList());
                } catch (Exception ex) {
                    return BadRequest(ex);
                }
        }

    }
}
