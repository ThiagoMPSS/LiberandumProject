using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models {
    [Table("T_CATEGORIA")]
    public class Categoria {

        [Key, Column("id_categoria")]
        public int Id { get; set; } = 0;

        [Required, Column("nm_categoria")]
        public string Nome { get; set; } = "";

        //@OneToMany(mappedBy= "categoria", cascade= CascadeType.PERSIST)
        public Collection<Perfil>? Perfis = null;

        public Categoria() { }

        public Categoria(string nome) {
            this.Nome = nome;
        }

        public override string ToString() {
            return $"Categoria [Id={Id}, Nome={Nome}]";
        }
    }
}
