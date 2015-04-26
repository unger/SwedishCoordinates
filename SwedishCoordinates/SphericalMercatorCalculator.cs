namespace SwedishCoordinates
{
    using System;

    public class SphericalMercatorCalculator
    {
        private const double EarthRadius = 6378137.0;

        // double y2lat_m(double y) { return rad2deg(2 * atan(exp((y / earth_radius))) - M_PI / 2); }
        // function y2lat($y) { return rad2deg(2.0 * atan(exp($y / 6378137.0)) - M_PI_2); }
        public double YToLatitude(double y)
        {
            return this.RadiansToDegrees(
                (2 * Math.Atan(
                    Math.Exp(y / EarthRadius))) - (Math.PI / 2));
        }

        // double lat2y_m(double lat) { return earth_radius * log(tan(M_PI / 4 + deg2rad(lat) / 2)); }
        // function lat2y($lat) { return log(tan(M_PI_4 + deg2rad($lat) / 2.0)) * 6378137.0; }
        public double LatitudeToY(double latitude)
        {
            return EarthRadius * (
                Math.Log(
                    Math.Tan(
                        (Math.PI / 4.0) + (this.DegreesToRadians(latitude) / 2))));
        }

        // double x2lon_m(double x) { return rad2deg(x / earth_radius); }
        // function x2lon($x) { return rad2deg($x / 6378137.0); }
        public double XToLongitude(double x)
        {
            return this.RadiansToDegrees(x / EarthRadius);
        }

        // double lon2x_m(double lon) { return deg2rad(lon) * earth_radius; }
        // function function lon2x($lon) { return deg2rad($lon) * 6378137.0; }
        public double LongitudeToX(double longitude)
        {
            return this.DegreesToRadians(longitude) * 6378137.0;
        }

        /*
        // double y2lat_m(double y) { return rad2deg(2 * atan(exp((y / earth_radius))) - M_PI / 2); }
        // function y2lat($y) { return rad2deg(2.0 * atan(exp($y / 6378137.0)) - M_PI_2); }
        public double YToLatitude(double y)
        {
            return this.RadiansToDegrees(2 * Math.Atan(Math.Exp(this.DegreesToRadians(y / EarthRadius)))) - (Math.PI / 2);
            return this.RadiansToDegrees(2 * Math.Atan(Math.Exp(y / EarthRadius))) - (Math.PI / 2);
        }

        // double lat2y_m(double lat) { return earth_radius * log(tan(M_PI / 4 + deg2rad(lat) / 2)); }
        // function lat2y($lat) { return log(tan(M_PI_4 + deg2rad($lat) / 2.0)) * 6378137.0; }
        public double LatitudeToY(double latitude)
        {
            return this.RadiansToDegrees(
                Math.Log(
                    Math.Tan(
                        (Math.PI / 4.0) + (this.DegreesToRadians(latitude) / 2))));
            return EarthRadius *
                Math.Log(
                    Math.Tan(
                        (Math.PI / 4.0) + (this.DegreesToRadians(latitude) / 2)));
        }*/

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
