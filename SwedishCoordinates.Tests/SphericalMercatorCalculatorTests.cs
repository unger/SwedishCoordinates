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

        [TestCase(1325761d, 11.909510d)]
        public void XToLongitude(double x, double expectedLng)
        {
            var lng = new SphericalMercatorCalculator().XToLongitude(x);

            Assert.Less(Math.Abs(lng - expectedLng), 0.000005);
            //Assert.AreEqual(expectedLng, lng);
        }

        [TestCase(11.909510d, 1325761d)]
        public void LongitudeToX(double lng, double expectedX)
        {
            var x = new SphericalMercatorCalculator().LongitudeToX(lng);

            //Assert.Less(Math.Abs(x - expectedX), 0.5);
            Assert.AreEqual(expectedX, x);
        }

        [TestCase(7890733d, 57.633573d)]
        public void YToLatitude(double y, double expectedLat)
        {
            var lat = new SphericalMercatorCalculator().YToLatitude(y);

            Assert.Less(Math.Abs(lat - expectedLat), 0.000005);
            //Assert.AreEqual(expectedLat, lat);
        }

        [TestCase(57.633573d, 7890733d)]
        [TestCase(57.633572d, 7890733d)]
        [TestCase(57.633571d, 7890733d)]
        [TestCase(57.633570d, 7890733d)]
        [TestCase(57.633569d, 7890733d)]
        public void LatitudeToY(double lat, double expectedY)
        {
            var y = new SphericalMercatorCalculator().LatitudeToY(lat);

            //Assert.Less(Math.Abs(y - expectedY), 0.4);
            Assert.AreEqual(expectedY, y);
        }
    }
}
