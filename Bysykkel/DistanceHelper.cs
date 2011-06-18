using System;

namespace Bysykkel
{
    public static class DistanceHelper
    {
        // Implementation of the Haversine Forumla (http://en.wikipedia.org/wiki/Haversine_formula)
        public static double Between(double long1, double lat1, double long2, double lat2)
        {
            double R = 6378.1; // radius of earth.

            double dLat = ToRadian(lat2 - lat1);
            double dLon = ToRadian(long2 - long1);

            double a =
                Math.Sin(dLat / 2.0) * Math.Sin(dLat / 2.0) +
                Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) *
                Math.Sin(dLon / 2.0) * Math.Sin(dLon / 2.0);

            double c = 2.0 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;
            return d;
        }

        private static double ToRadian(double value)
        {
            return (Math.PI / 180.0) * value;
        }
    }
}
