using kasko;
namespace TestModul
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            double[,] graph = {
            { 0,    1,    4,    double.MaxValue },
            { double.MaxValue, 0,    2,    6 },
            { double.MaxValue, double.MaxValue, 0,    3 },
            { double.MaxValue, double.MaxValue, double.MaxValue, 0 }
        };

            int startVertex = 0;

            double[] result = Dijkstra(graph, startVertex);

            double[] expected = { 0, 1, 3, 6 };
            Assert.Equal(expected, result);
        }

        private static double[] Dijkstra(double[,] a, int v0)
        {
            int n = a.GetLength(0);
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = double.MaxValue;
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (a[v, i] != double.MaxValue && dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
    }
}
