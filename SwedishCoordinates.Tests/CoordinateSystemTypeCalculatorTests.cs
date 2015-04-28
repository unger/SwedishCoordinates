using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCoordinates.Tests
{
    using System.IO;
    using System.Security.AccessControl;

    using NUnit.Framework;

    [TestFixture]
    public class CoordinateSystemTypeCalculatorTests
    {
        /*
            SWEREF 99 TM	N 6534702	E 265458
            RT90	X 6539796	Y 1219001
            WGS84 dec	58,887857°	10,929260°

            SWEREF 99 TM	N 6130185	E 393437
            RT90	X 6133534	Y 1342266
            WGS84 dec	55,306522°	13,321236°

            SWEREF 99 TM	N 6600328	E 763728
            RT90	X 6599414	Y 1718236
            WGS84 dec	59,458372°	19,654854°

            SWEREF 99 TM	N 7330648	E 917405
            RT90	X 7327815	Y 1881063
            WGS84 dec	65,822498°	24,159249°

            SWEREF 99 TM	N 7671027	E 721007
            RT90	X 7670775	Y 1689086
            WGS84 dec	69,059755°	20,547493°

            SWEREF 99 TM	N 7289089	E 476058
            RT90	X 7291923	Y 1439110
            WGS84 dec	65,722594°	14,478164°         

            SWEREF 99 TM	N 6274430	E 337417
            RT90	X 6275247	Y 1288008
            WGS84 dec	56,600000°	12,346816°

            SWEREF 99 TM	N 6274430	E 615001
            RT90	X 6275247	Y 1565594
            WGS84 dec	56,600000°	16,873183°
         */

        // RT90 Test Cases
        [TestCase(6539796, 1219001, Result = CoordinateSystemType.RT90)]
        [TestCase(6133534, 1342266, Result = CoordinateSystemType.RT90)]
        [TestCase(6599414, 1718236, Result = CoordinateSystemType.RT90)]
        [TestCase(7327815, 1881063, Result = CoordinateSystemType.RT90)]
        [TestCase(7670775, 1689086, Result = CoordinateSystemType.Undefined)] // Inconclusive with WebMercator position
        [TestCase(7291923, 1439110, Result = CoordinateSystemType.RT90)]
        [TestCase(6275247, 1439110, Result = CoordinateSystemType.RT90)]
        [TestCase(6275247, 1565594, Result = CoordinateSystemType.RT90)]

        // SWEREF99 Test Cases
        [TestCase(6534702, 265458, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6130185, 393437, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6600328, 763728, Result = CoordinateSystemType.Sweref99)]
        [TestCase(7330648, 917405, Result = CoordinateSystemType.Sweref99)]
        [TestCase(7671027, 721007, Result = CoordinateSystemType.Sweref99)]
        [TestCase(7289089, 476058, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6274430, 337417, Result = CoordinateSystemType.Sweref99)]
        [TestCase(6274430, 615001, Result = CoordinateSystemType.Sweref99)]

        // Wgs84 Test Cases
        [TestCase(58.887857, 10.929260, Result = CoordinateSystemType.Wgs84)]
        [TestCase(55.306522, 13.321236, Result = CoordinateSystemType.Wgs84)]
        [TestCase(59.458372, 19.654854, Result = CoordinateSystemType.Wgs84)]
        [TestCase(65.822498, 24.159249, Result = CoordinateSystemType.Wgs84)]
        [TestCase(69.059755, 20.547493, Result = CoordinateSystemType.Wgs84)]
        [TestCase(65.722594, 14.478164, Result = CoordinateSystemType.Wgs84)]
        [TestCase(56.600000, 12.346816, Result = CoordinateSystemType.Wgs84)]
        [TestCase(56.600000, 16.873183, Result = CoordinateSystemType.Wgs84)]

        // WebMercator Test Cases
        [TestCase(8156188, 1224086, Result = CoordinateSystemType.WebMercator)]
        [TestCase(7421584, 1496457, Result = CoordinateSystemType.Undefined)] // Inconclusive with RT90 position
        [TestCase(8280125, 2232188, Result = CoordinateSystemType.WebMercator)]
        [TestCase(9828434, 2772825, Result = CoordinateSystemType.WebMercator)]
        [TestCase(10769373, 2338003, Result = CoordinateSystemType.WebMercator)]
        [TestCase(9801332, 1611702, Result = CoordinateSystemType.WebMercator)]
        [TestCase(7678798, 1374441, Result = CoordinateSystemType.WebMercator)]
        [TestCase(7678798, 1878314, Result = CoordinateSystemType.WebMercator)]
        public CoordinateSystemType GetCoordinateSystemType(double lat, double lng)
        {
            var calc = new SphericalMercatorCalculator();
            var str = calc.LatitudeToY(lat) + "," + calc.LongitudeToX(lng);
            return new CoordinateSystemTypeCalculator().GetCoordinateSystemType(lat, lng);
        }
    }
}
