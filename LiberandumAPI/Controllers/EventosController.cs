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
        public IActionResult GetEventos(int perfilId, int eventoId = -1, int index = -1, int limit = -1) {
            if (eventoId != -1)
                return Get<Evento>(eventoId);
            else
                try {
                    var eventos = Db.Evento?.Where(e => e.PerfilId == perfilId);
                    if (index > -1)
                        eventos = eventos?.Skip(index);
                    if (limit > -1)
                        eventos = eventos?.Take(limit);
                    return Ok(eventos);
                } catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
        }

        [HttpPut]
        public IActionResult AlterarEvento(Evento evento) {
            return Alterar(evento);
        }

        [HttpDelete]
        public IActionResult DeletarEvento(int eventoId) {
            return Deletar<Evento>(eventoId);
        }

        [HttpPost, Route("Necessidade")]
        public IActionResult CriarNecessidade(Necessidade necessidade) {
            return Criar(necessidade);
        }

        [HttpGet, Route("Necessidade")]
        public IActionResult GetNecessidades(int Id = -1) {
            if (Id != -1)
                return Get<Necessidade>(Id);
            else
                try {
                    return Ok(Db.Necessidade?.ToList());
                } catch (Exception ex) {
                    return BadRequest(ex);
                }
        }

        [HttpPut, Route("Necessidade")]
        public IActionResult AlterarNecessidade(Necessidade necessidade) {
            return Alterar(necessidade);
        }

        [HttpDelete, Route("Necessidade")]
        public IActionResult DeletarNecessidade(int Id) { 
            return Deletar<Necessidade>(Id);
        }

    }
}
