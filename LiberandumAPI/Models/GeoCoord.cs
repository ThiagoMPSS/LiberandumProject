namespace WebApplication3.Models {
    public class GeoCoord {

        public double Latitude { get; private set; } = 0;

        public double Longitude { get; private set; } = 0;

        public GeoCoord(double Latitude, double Longitude) {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

        public override string ToString() {
            return $"GeoCoord [latitude={Latitude}, longitude={Longitude}]";
        }
    }
}
