using SwedishCoordinates.Classes;

namespace SwedishCoordinates
{
    public static class PositionExtensions
    {
        public static bool InsideSwedishBounds(this Position pos)
        {
            double maxLat = 0, minLat = 0, maxLng = 0, minLng = 0;

            switch (pos.GridFormat)
            {
                case Grid.RT90:
                    maxLat = CoordinateConst.Rt90LatitudeMax;
                    minLat = CoordinateConst.Rt90LatitudeMin;
                    maxLng = CoordinateConst.Rt90LongitudeMax;
                    minLng = CoordinateConst.Rt90LongitudeMin;
                    break;
                case Grid.SWEREF99:
                    maxLat = CoordinateConst.Sweref99LatitudeMax;
                    minLat = CoordinateConst.Sweref99LatitudeMin;
                    maxLng = CoordinateConst.Sweref99LongitudeMax;
                    minLng = CoordinateConst.Sweref99LongitudeMin;
                    break;
                case Grid.WGS84:
                    maxLat = CoordinateConst.Wgs84LatitudeMax;
                    minLat = CoordinateConst.Wgs84LatitudeMin;
                    maxLng = CoordinateConst.Wgs84LongitudeMax;
                    minLng = CoordinateConst.Wgs84LongitudeMin;
                    break;
                case Grid.WebMercator:
                    maxLat = CoordinateConst.WebMercatorLatitudeMax;
                    minLat = CoordinateConst.WebMercatorLatitudeMin;
                    maxLng = CoordinateConst.WebMercatorLongitudeMax;
                    minLng = CoordinateConst.WebMercatorLongitudeMin;
                    break;
            }

            return pos.Latitude > minLat 
                && pos.Latitude < maxLat 
                && pos.Longitude > minLng 
                && pos.Longitude < maxLng;
        }
    }
}
