namespace SwedishCoordinates.Tests
{
    using System;

    using NUnit.Framework;

    using SwedishCoordinates.Positions;

    [TestFixture]
    public class PositionConverterTests
    {
        /*
            Välen
            SweRef:  6392120.265, 315499.415
            WebMerc: 7890733, 1325761
            RT90:    6396528, 1267363
            Wgs84:   57.633573, 11.909510         

         */

        [TestCase(57.633573, 11.909510, 6396528, 1267363, 0)]
        public void ToRt90_FromWgs84(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WGS84Position(lat, lng);
            var converted = PositionConverter.ToRt90(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(6392120.265, 315499.415, 6396528, 1267363, 0)]
        public void ToRt90_FromSweRef99(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new SWEREF99Position(lat, lng);
            var converted = PositionConverter.ToRt90(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(7890733, 1325761, 6396528, 1267363, 0)]
        public void ToRt90_FromWebMercator(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WebMercatorPosition(lat, lng);
            var converted = PositionConverter.ToRt90(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(6396528, 1267363, 57.633573, 11.909510, 5)]
        public void ToWgs84_FromRt90(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new RT90Position(lat, lng);
            var converted = PositionConverter.ToWgs84(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(6392120.265, 315499.415, 57.633573, 11.909510, 4)]
        public void ToWgs84_FromSweRef99(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new SWEREF99Position(lat, lng);
            var converted = PositionConverter.ToWgs84(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(7890733, 1325761, 57.633573, 11.909510, 5)]
        public void ToWgs84_FromWebMercator(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WebMercatorPosition(lat, lng);
            var converted = PositionConverter.ToWgs84(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }
/*
A: x = 7453389.762 m y = 1727060.905 m
B: x = 7047738.415 m y = 1522128.637 m
C: x = 6671665.273 m y = 1441843.186 m
D: x = 6249111.351 m y = 1380573.079 m 

A: x = 7454204.638 m y = 761811.242 m 
B: x = 7046077.605 m y = 562140.337 m 
C: x = 6669189.376 m y = 486557.055 m
D: x = 6246136.458 m y = 430374.835 m
    */

        [TestCase(7453389.762, 1727060.905, 7454204.638, 761811.242, 3)]    // Kontrollpunkt A Lantmäteriet
        [TestCase(7047738.415, 1522128.637, 7046077.605, 562140.337, 3)]    // Kontrollpunkt B Lantmäteriet
        [TestCase(6671665.273, 1441843.186, 6669189.376, 486557.055, 3)]    // Kontrollpunkt C Lantmäteriet
        [TestCase(6249111.351, 1380573.079, 6246136.458, 430374.835, 3)]    // Kontrollpunkt D Lantmäteriet
        [TestCase(6396528, 1267363, 6392120.265, 315499.415, 0)]            // Välen, Göteborg
        public void ToSweRef99_FromRt90(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new RT90Position(lat, lng);
            var converted = PositionConverter.ToSweRef99(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(57.633573, 11.909510, 6392120.265, 315499.415, 0)]
        public void ToSweRef99_FromWgs84(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WGS84Position(lat, lng);
            var converted = PositionConverter.ToSweRef99(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(7890733.208, 1325760.532, 6392120.265, 315499.415, 0)]
        public void ToSweRef99_FromWebMercator(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WebMercatorPosition(lat, lng);
            var converted = PositionConverter.ToSweRef99(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(6396528, 1267363, 7890733, 1325761, 0)]            // Välen, Göteborg
        public void ToWebMercator_FromRt90(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new RT90Position(lat, lng);
            var converted = PositionConverter.ToWebMercator(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(6392120.265, 315499.415, 7890733.208, 1325760.532, 3)]            // Välen, Göteborg
        public void ToWebMercator_FromSweRef99(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new SWEREF99Position(lat, lng);
            var converted = PositionConverter.ToWebMercator(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }

        [TestCase(57.633573, 11.909510, 7890733.208, 1325760.532, 0)]            // Välen, Göteborg
        public void ToWebMercator_FromWgs84(double lat, double lng, double expectedLat, double expectedLng, int decimals)
        {
            var pos = new WGS84Position(lat, lng);
            var converted = PositionConverter.ToWebMercator(pos);

            Assert.AreEqual(Math.Round(expectedLat, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Latitude, decimals, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(expectedLng, decimals, MidpointRounding.AwayFromZero), Math.Round(converted.Longitude, decimals, MidpointRounding.AwayFromZero));
        }
    }
}
