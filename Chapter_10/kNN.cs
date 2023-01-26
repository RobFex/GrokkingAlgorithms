namespace GrokkingAlgorithms.Chapter_10
{
    public class kNN<T>
    {
        private readonly int k;
        public kNN(int k = 3)
        {
            this.k = k;
        }

        public List<MapPoint<T>> FindNearest(MapPoint<T>[] points, MapPoint<T> point)
        {
            if (points.Length == 0 || point.Coor.Length == 0)
                throw new ArgumentException("Array's length cannot be equal zero.");

            MapPoint<T> tmp;
            MapPoint<T> nearest = points[0];
            List<MapPoint<T>> nearestPoints = new List<MapPoint<T>>();

            for (int i = 1; i < k + 1; i++)
            {
                for (int j = 0; j < points.Length - i; j++)
                {
                    if (points[j] == point || nearestPoints.Contains(points[j]))
                        continue;

                    if (EuclideanDistance(point, points[j]) < EuclideanDistance(point, nearest))
                    {
                        nearest = points[j];
                        tmp = points[j];
                        points[j] = points[points.Length - 1];
                        points[points.Length - 1] = tmp;
                    }
                }
                nearestPoints.Add(nearest);
                for (int x = 0; x < points.Length - x; x++)
                {
                    if (!nearestPoints.Contains(points[x]))
                        nearest = points[x];
                }
            }
            return nearestPoints;
        }

        public double EuclideanDistance(MapPoint<T> p, MapPoint<T> q)
        {
            // d = √(x1 - x2)^2 + (y1 - y2)^2 + ...
            if (p.Coor.Length != q.Coor.Length)
                throw new ArgumentException("The coordinates aren't the same.");

            double distance = 0;
            for (int i = 0; i < p.Coor.Length; i++)
                distance += Math.Pow(p.Coor[i] - q.Coor[i], 2);

            return Math.Sqrt(distance);
        }

        public double Predict(MapPoint<int>[] points, MapPoint<int> point)
        {
            List<MapPoint<int>> nearest = FindNearest(points, point);
            double response = 0;

            for (int i = 0; i < nearest.Count; i++)
                response += nearest[i].Value;

            response = (double)response / (double)nearest.Count;
            return response;
        }

        private List<MapPoint<int>> FindNearest(MapPoint<int>[] points, MapPoint<int> point)
        {
            if (points.Length == 0 || point.Coor.Length == 0)
                throw new ArgumentException("Array's length cannot be equal zero.");

            MapPoint<int> tmp;
            MapPoint<int> nearest = points[0];
            List<MapPoint<int>> nearestPoints = new List<MapPoint<int>>();

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < points.Length - i; j++)
                {
                    if (points[j] == point || nearestPoints.Contains(points[j]))
                        continue;

                    if (EuclideanDistance(point, points[j]) < EuclideanDistance(point, nearest))
                    {
                        nearest = points[j];
                        tmp = points[j];
                        points[j] = points[points.Length - 1];
                        points[points.Length - 1] = tmp;
                    }
                }
                nearestPoints.Add(nearest);
                for (int x = 0; x < points.Length - x; x++)
                {
                    if (!nearestPoints.Contains(points[x]))
                        nearest = points[x];
                }
            }
            return nearestPoints;
        }
        private double EuclideanDistance(MapPoint<int> p, MapPoint<int> q)
        {
            if (p.Coor.Length != q.Coor.Length)
                throw new ArgumentException("The coordinates aren't the same.");

            double distance = 0;
            for (int i = 0; i < p.Coor.Length; i++)
                distance += Math.Pow(p.Coor[i] - q.Coor[i], 2);

            return Math.Sqrt(distance);
        }
    }
}
