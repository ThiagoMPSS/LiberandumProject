//using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Db.Context {

    [Table("T_NECESSIDADE")]
    public class Necessidade {
        [Key, Column("id_necessidade")]
        public int Id { get; set; } = 0;

        [Required, Column("tp_necessidade")]
        public string Tipo { get; set; } = "";

        //@OneToMany(mappedBy= "necessidade", cascade= CascadeType.PERSIST)
        [NotMapped]
        public Collection<Evento>? Eventos = null;

        public Necessidade() { }

        public Necessidade(int Id, string Tipo) {
            this.Id = Id;
            this.Tipo = Tipo;
        }

        public Necessidade(string Tipo) {
            this.Tipo = Tipo;
        }

        public override string ToString() {
            return $"Necessidade [Id={Id}, Tipo={Tipo}]";
        }

    }
}
