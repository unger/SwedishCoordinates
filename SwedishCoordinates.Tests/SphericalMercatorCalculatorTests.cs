using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCoordinates.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SphericalMercatorCalculatorTests
    {
        /*
            Välen
            7890733,1325761
            6396528,1267363
            57.633573,11.909510         
         */

        [TestCase(1325761.0, 11.909510)]
        public void XToLongitude(double x, double expectedLng)
        {
            var lng = new SphericalMercatorCalculator().XToLongitude(x);

            Assert.Less(Math.Abs(lng - expectedLng), 0.00001);
        }

        [TestCase(11.909510, 1325761.0)]
        public void LongitudeToX(double lng, double expectedX)
        {
            var x = new SphericalMercatorCalculator().LongitudeToX(lng);

            Assert.Less(Math.Abs(x - expectedX), 0.5);
        }

        [TestCase(7890733.0, 57.633573)]
        public void YToLatitude(double y, double expectedLat)
        {
            var lat = new SphericalMercatorCalculator().YToLatitude(y);

            Assert.Less(Math.Abs(lat - expectedLat), 0.00001);
        }

        [TestCase(57.633573, 7890733.0)]
        public void LatitudeToY(double lat, double expectedY)
        {
            var y = new SphericalMercatorCalculator().LatitudeToY(lat);

            Assert.Less(Math.Abs(y - expectedY), 0.4);
        }

        [TestCase(57.633573)]
        [TestCase(11.909510)]
        public void LatitudeToY_YToLatitude(double lat)
        {
            var calc = new SphericalMercatorCalculator();
            var newLat = calc.YToLatitude(calc.LatitudeToY(lat));

            Assert.Less(Math.Abs(lat - newLat), 0.0000000000001);
        }

        [TestCase(7890733.0)]
        [TestCase(1325761.0)]
        public void YToLatitude_LatitudeToY(double y)
        {
            var calc = new SphericalMercatorCalculator();
            var newY = calc.LatitudeToY(calc.YToLatitude(y));

            Assert.Less(Math.Abs(y - newY), 0.0000001);
        }
    }
}
