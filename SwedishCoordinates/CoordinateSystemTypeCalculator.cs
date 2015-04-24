namespace SwedishCoordinates
{
    public class CoordinateSystemTypeCalculator
    {
        public CoordinateSystemType GetCoordinateSystemType(double lat, double lng)
        {
            if (lng > 430000.0 && lng < 770000.0)
            {
                return CoordinateSystemType.Sweref99;
            }

            if (lat > 55 && lat < 70 && lng > 10.9 && lng < 24.3)
            {
                return CoordinateSystemType.Wgs84;
            }

            return CoordinateSystemType.RT90;
        }
    }
}
