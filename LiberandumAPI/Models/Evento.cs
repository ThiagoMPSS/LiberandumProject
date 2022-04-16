using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Db.Context;

namespace WebApplication3.Models {
    [Table("T_EVENTO")]
    public class Evento {

        [Key, Column("id_evento")]
        public int Id { get; set; } = 0;

        [Required, Column("tp_evento")]
        public string Tipo { get; set; } = "";

        [Required, Column("dt_evento")]
        public DateTime? DataHora { get; set; } = null;

        [Required, Column("latitude_evento")]
        public double Latitude { get; set; } = 0;

        [Required, Column("longitude_evento")]
        public double Longitude { get; set; } = 0;

        [NotMapped]
        public Perfil? Perfil { get; set; } = null;

        [Required, Column("id_perfil")]
        public int PerfilId { get; set; } = -1;

        [NotMapped]
        public Necessidade? Necessidade { get; set; } = null;

        [Required, Column("id_necessidade")]
        public int NecessidadeId { get; set; } = -1;

        public Evento() {

        }

        public Evento(string Tipo, DateTime DataHora, GeoCoord Coords) {
            this.Tipo = Tipo;
            this.DataHora = DataHora;
            this.Latitude = Coords.Latitude;
            this.Longitude = Coords.Longitude;
        }

        public Evento(string Tipo, DateTime DataHora, GeoCoord Coords, Perfil Perfil, Necessidade Necessidade) : this(Tipo, DataHora, Coords) {
            this.Perfil = Perfil;
            this.Necessidade = Necessidade;
        }

        public GeoCoord getCoords() {
            return new GeoCoord(this.Latitude, this.Longitude);
        }

        public void setCoords(GeoCoord Coords) {
            this.Latitude = Coords.Latitude;
            this.Longitude = Coords.Longitude;
        }

        public override string ToString() {
            return $"Evento [Data={DataHora}, "
                   + $"Id={Id}, "
                   + $"Coords={getCoords()}, "
                   + $"Necessidade={Necessidade?.Tipo}, "
                   + $"Perfil={Perfil?.Id}, "
                   + $"Tipo={Tipo}]";
        }
    }
}
