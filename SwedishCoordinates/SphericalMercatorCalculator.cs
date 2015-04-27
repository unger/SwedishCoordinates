namespace SwedishCoordinates
{
    using System;

    public class SphericalMercatorCalculator
    {
        private const double EarthRadius = 6378137;

        public SphericalMercatorCalculator()
        {
            this.LatLngDecimals = 6;
            this.XyDecimals = 0;
            this.Rounding = MidpointRounding.AwayFromZero;
        }

        public MidpointRounding Rounding { get; set; }

        public int LatLngDecimals { get; set; }
        
        public int XyDecimals { get; set; }

        // double y2lat_m(double y) { return rad2deg(2 * atan(exp((y / earth_radius))) - M_PI / 2); }
        public double YToLatitude(double y)
        {
            var latitude = this.RadiansToDegrees(
                (2 * Math.Atan(
                    Math.Exp(y / EarthRadius))) - (Math.PI / 2));

            return Math.Round(latitude, this.LatLngDecimals, this.Rounding);
        }

        // double lat2y_m(double lat) { return earth_radius * log(tan(M_PI / 4 + deg2rad(lat) / 2)); }
        public double LatitudeToY(double latitude)
        {
            var y = EarthRadius * 
                Math.Log(
                    Math.Tan(
                        (Math.PI / 4.0) + (this.DegreesToRadians(latitude) / 2)));

            return Math.Round(y, this.XyDecimals, this.Rounding);
        }


        // double x2lon_m(double x) { return rad2deg(x / earth_radius); }
        public double XToLongitude(double x)
        {
            var longitude = this.RadiansToDegrees(x / EarthRadius);
            return Math.Round(longitude, this.LatLngDecimals, this.Rounding);
        }

        // double lon2x_m(double lon) { return deg2rad(lon) * earth_radius; }
        public double LongitudeToX(double longitude)
        {
            var x = this.DegreesToRadians(longitude) * EarthRadius;
            return Math.Round(x, this.XyDecimals, this.Rounding);
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
