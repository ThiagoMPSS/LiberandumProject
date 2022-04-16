using LiberandumAPI.Db.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models {
    [Table("T_PERFIL")]
    public class Perfil {

        [Key, Column("id_perfil")]
        public int Id { get; set; } = 0;

        [Required, Column("nm_perfil")]
        public string Nome { get; set; } = "";

        [NotMapped]
        public Usuario? Usuario { get; set; } = null;

        [Required, Column("id_user")]
        public int UsuarioId { get; set; } = -1;

        [NotMapped]
        public Categoria? Categoria { get; set; } = null;

        [Required, Column("id_categoria")]
        public int CategoriaId { get; set; } = -1;

        [NotMapped]
        public List<Evento>? Eventos = null;

        public Perfil() {

        }

        public Perfil(string Nome, Categoria Categoria) {
            this.Nome = Nome;
            this.Categoria = Categoria;
        }

        public Perfil(string Nome, Categoria Categoria, Usuario Usuario) :
                this(Nome, Categoria) {
            this.Usuario = Usuario;
        }

        public override string ToString() {
            return $"Perfil [Categoria={this.Categoria}, "
                   //+ $"Eventos={this.Eventos}, " 
                   + $"Id={this.Id}, "
                   + "Nome={this.Nome}, "
                   + "Usuario={this.Usuario}]";
        }
    }
}
