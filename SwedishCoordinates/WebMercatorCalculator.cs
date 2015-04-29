namespace SwedishCoordinates
{
    using System;

    public class WebMercatorCalculator
    {
        private const double EarthRadius = 6378137;

        public WebMercatorCalculator()
        {
            this.Rounding = MidpointRounding.AwayFromZero;
        }

        public MidpointRounding Rounding { get; set; }

        // double y2lat_m(double y) { return rad2deg(2 * atan(exp((y / earth_radius))) - M_PI / 2); }
        public double YToLatitude(double y, int decimals = -1)
        {
            var latitude = this.RadiansToDegrees(
                (2 * Math.Atan(
                    Math.Exp(y / EarthRadius))) - (Math.PI / 2));

            return decimals == -1
                    ? latitude 
                    : Math.Round(latitude, decimals, this.Rounding);
        }

        // double lat2y_m(double lat) { return earth_radius * log(tan(M_PI / 4 + deg2rad(lat) / 2)); }
        public double LatitudeToY(double latitude, int decimals = -1)
        {
            var y = EarthRadius * 
                Math.Log(
                    Math.Tan(
                        (Math.PI / 4.0) + (this.DegreesToRadians(latitude) / 2)));

            return decimals == -1
                    ? y
                    : Math.Round(y, decimals, this.Rounding);
        }

        // double x2lon_m(double x) { return rad2deg(x / earth_radius); }
        public double XToLongitude(double x, int decimals = -1)
        {
            var longitude = this.RadiansToDegrees(x / EarthRadius);
            return decimals == -1
                    ? longitude
                    : Math.Round(longitude, decimals, this.Rounding);
        }

        // double lon2x_m(double lon) { return deg2rad(lon) * earth_radius; }
        public double LongitudeToX(double longitude, int decimals = -1)
        {
            var x = this.DegreesToRadians(longitude) * EarthRadius;
            return decimals == -1
                    ? x
                    : Math.Round(x, decimals, this.Rounding);
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        private double RadiansToDegrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}
