namespace SwedishCoordinates
{
    using SwedishCoordinates.Positions;

    public class PositionConverter
    {
        public static RT90Position ToRt90(WGS84Position pos)
        {
            return new RT90Position(pos, RT90Position.RT90Projection.rt90_2_5_gon_v);
        }

        public static RT90Position ToRt90(SWEREF99Position pos)
        {
            return new RT90Position(pos.ToWGS84(), RT90Position.RT90Projection.rt90_2_5_gon_v);
        }

        public static RT90Position ToRt90(WebMercatorPosition pos)
        {
            var calc = new WebMercatorCalculator();
            var wgs84Pos = new WGS84Position(calc.YToLatitude(pos.Latitude), calc.XToLongitude(pos.Longitude));
            return new RT90Position(wgs84Pos, RT90Position.RT90Projection.rt90_2_5_gon_v);
        }

        public static WGS84Position ToWgs84(RT90Position pos)
        {
            return pos.ToWGS84();
        }

        public static WGS84Position ToWgs84(SWEREF99Position pos)
        {
            return pos.ToWGS84();
        }

        public static WGS84Position ToWgs84(WebMercatorPosition pos)
        {
            var calc = new WebMercatorCalculator();
            return new WGS84Position(calc.YToLatitude(pos.Latitude), calc.XToLongitude(pos.Longitude));
        }

        public static SWEREF99Position ToSweRef99(RT90Position pos)
        {
            return new SWEREF99Position(pos.ToWGS84(), SWEREF99Position.SWEREFProjection.sweref_99_tm);
        }

        public static SWEREF99Position ToSweRef99(WGS84Position pos)
        {
            return new SWEREF99Position(pos, SWEREF99Position.SWEREFProjection.sweref_99_tm);
        }

        public static SWEREF99Position ToSweRef99(WebMercatorPosition pos)
        {
            var calc = new WebMercatorCalculator();
            var wgs84Pos = new WGS84Position(calc.YToLatitude(pos.Latitude), calc.XToLongitude(pos.Longitude));
            return new SWEREF99Position(wgs84Pos, SWEREF99Position.SWEREFProjection.sweref_99_tm);
        }

        public static WebMercatorPosition ToWebMercator(RT90Position pos)
        {
            var calc = new WebMercatorCalculator();
            var wgs84 = pos.ToWGS84();

            return new WebMercatorPosition(calc.LatitudeToY(wgs84.Latitude), calc.LongitudeToX(wgs84.Longitude));
        }

        public static WebMercatorPosition ToWebMercator(SWEREF99Position pos)
        {
            var calc = new WebMercatorCalculator();
            var wgs84 = pos.ToWGS84();

            return new WebMercatorPosition(calc.LatitudeToY(wgs84.Latitude), calc.LongitudeToX(wgs84.Longitude));
        }

        public static WebMercatorPosition ToWebMercator(WGS84Position pos)
        {
            var calc = new WebMercatorCalculator();

            return new WebMercatorPosition(calc.LatitudeToY(pos.Latitude), calc.LongitudeToX(pos.Longitude));
        }
    }
}
