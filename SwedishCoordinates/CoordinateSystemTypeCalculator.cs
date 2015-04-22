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

            return CoordinateSystemType.RT90;
        }
    }
}
