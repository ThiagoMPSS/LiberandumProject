using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models.Enums;

namespace WebApplication3.Models {
    [Table("T_USUARIO")]
    public class Usuario {

        [Key, Column("id_user")]
        public int Id { get; set; } = 0;

        [Required, Column("email_user")]
        public string Email { get; set; } = "";

        [Required, Column("senha_user")]
        public string Senha { get; set; } = "";

        [Required, Column("dtnasc_user")]
        public DateTime? DtNasc { get; set; } = null;

        [Required, Column("sexo_user")]
        public SexoEnum? Sexo { get; set; } = null;

        [Required, Column("nrcontato_user")]
        public string NrContato { get; set; } = "";

        //[OneToMany(mappedBy = "usuario", cascade = CascadeType.PERSIST, orphanRemoval = true)]
        [NotMapped]
        public List<Perfil>? Perfis = null;

        public Usuario() {

        }

        public Usuario(string Email, string Senha, DateTime DtNasc, SexoEnum Sexo, string NrContato) {
            this.Email = Email;
            this.Senha = Senha;
            this.DtNasc = DtNasc;
            this.Sexo = Sexo;
            this.NrContato = NrContato;
        }

        public Usuario(string Email, string Senha, DateTime DtNasc, SexoEnum Sexo, string NrContato, List<Perfil> Perfis) :
                this(Email, Senha, DtNasc, Sexo, NrContato) {
            this.Perfis = Perfis;
        }

        public void addPerfil(Perfil Perfil) {
            if ((this.Perfis == null)) {
                this.Perfis = new List<Perfil>();
            }

            this.Perfis.Add(Perfil);
        }

        public void removePerfil(Perfil Perfil) {
            this.Perfis?.Remove(Perfil);
        }

        public void RemovePerfil(int Index) {
            this.Perfis?.RemoveAt(Index);
        }

        public override string ToString() {
            return $"Usuario [dt_nasc={this.DtNasc.GetValueOrDefault()}, "
                   + $"email={this.Email}, "
                   + $"id={this.Id}, "
                   + $"nr_contato={this.NrContato}, "
                   //+ $"perfis={this.Perfis}, "
                   + $"senha={this.Senha}, "
                   + $"sexo={this.Sexo}]";
        }
    }
}
