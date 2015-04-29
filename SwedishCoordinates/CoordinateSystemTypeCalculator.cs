namespace SwedishCoordinates
{
    public class CoordinateSystemTypeCalculator
    {
        public CoordinateSystemType GetCoordinateSystemType(double lat, double lng)
        {
            if (lng >= CoordinateConst.Sweref99LongitudeMin &&
                lng <= CoordinateConst.Sweref99LongitudeMax)
            {
                return CoordinateSystemType.Sweref99;
            }

            if (lat >= CoordinateConst.Wgs84LatitudeMin && 
                lat <= CoordinateConst.Wgs84LatitudeMax &&
                lng >= CoordinateConst.Wgs84LongitudeMin &&
                lng <= CoordinateConst.Wgs84LongitudeMax)
            {
                return CoordinateSystemType.Wgs84;
            }

            if (lat > CoordinateConst.Rt90LatitudeMax)
            {
                return CoordinateSystemType.WebMercator;
            }

            if (lat < CoordinateConst.WebMercatorLatitudeMin &&
                lat >= CoordinateConst.Rt90LatitudeMin)
            {
                return CoordinateSystemType.Rt90;
            } 

            if (lng > CoordinateConst.Rt90LongitudeMax &&
                lng <= CoordinateConst.WebMercatorLongitudeMax)
            {
                return CoordinateSystemType.WebMercator;
            }

            if (lng < CoordinateConst.WebMercatorLongitudeMin &&
                lng >= CoordinateConst.Rt90LongitudeMin)
            {
                return CoordinateSystemType.Rt90;
            }

            return CoordinateSystemType.Undefined;
        }
    }
}
