using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCoordinates.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CoordinateSystemTypeCalculatorTests
    {
        [TestCase(7453389.762, 1727060.905, Result = CoordinateSystemType.RT90)]
        [TestCase(7047738.415, 1522128.637, Result = CoordinateSystemType.RT90)]
        [TestCase(6671665.273, 1441843.186, Result = CoordinateSystemType.RT90)]
        [TestCase(6249111.351, 1380573.079, Result = CoordinateSystemType.RT90)]

        [TestCase(7454204.638, 761811.242, Result = CoordinateSystemType.Sweref99)]
        [TestCase(7046077.605, 562140.337, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6669189.376, 486557.055, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6246136.458, 430374.835, Result = CoordinateSystemType.Sweref99)]

        [TestCase(58.887857, 10.929260, Result = CoordinateSystemType.Wgs84)]
        [TestCase(55.306522, 13.321236, Result = CoordinateSystemType.Wgs84)]
        [TestCase(59.458372, 19.654854, Result = CoordinateSystemType.Wgs84)]
        [TestCase(65.822498, 24.159249, Result = CoordinateSystemType.Wgs84)]
        [TestCase(69.059755, 20.547493, Result = CoordinateSystemType.Wgs84)]
        public CoordinateSystemType GetCoordinateSystemType(double lat, double lng)
        {
            return new CoordinateSystemTypeCalculator().GetCoordinateSystemType(lat, lng);
        }
    }
}
