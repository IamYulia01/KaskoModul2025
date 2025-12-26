/* Реализация алгоритма Дейкстры для поиска кратчайших путей во взвешенном графе.
 * Входные данные:      а - матрица инцидентности взвешенного графа
 *                      v0 - номер вершины, для которой вычисляются кратчайшие расстояния
 *                           до остальных вершин
 * Выходные данные:     одномерный массив кратчайших расстояний от вершины а 
 *                      до каждой из вершин графа (включая саму вершину а)
 */

namespace kasko
{
    public class Program
    {
        public class Marshrut{
            public int first {  get; set; }
            public int second { get; set; }
            public double rasst { get; set; }
        }
        public static int n = 9;
        private static double[] Dijkstra(double[,] a, int v0)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = Double.MaxValue;
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
                    if (dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
        public static void Main(string[] args)
        {
            bool valid = true;
            int firstT = 0;
            int secondT = 0;
            double[,] matr = new double[n, n];
            Marshrut indmar = new Marshrut();
            do
            {
                Console.WriteLine("Введите первую точку: ");
                string first = Console.ReadLine();
                if (string.IsNullOrEmpty(first) || !int.TryParse(first, out firstT) || firstT > n || firstT < 1)
                {
                    valid = false;
                    Console.WriteLine("Введите число от 1 до 9");
                }
                else
                {
                    valid = true;
                    indmar.first = firstT;
                }
            } while (!valid);
            do
            {
                Console.WriteLine("Введите вторую точку");
                string second = Console.ReadLine();
                if (string.IsNullOrEmpty(second) || !int.TryParse(second, out secondT) || secondT > n || secondT < 1 || secondT == firstT)
                {
                    valid = false;
                    Console.WriteLine("Введите число от 1 до 9, отличное от первого");
                }
                else
                {
                    valid = true;
                    indmar.first = firstT;
                }
                } while (!valid);
            Marshrut[] marshrut = new Marshrut[n];
            string path = @".\tochki.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                string[] strArr;
                while ((s = sr.ReadLine()) != null)
                {
                    strArr = s.Split("\t");
                    marshrut[0].first = int.Parse(strArr[0]);
                    marshrut[0].second = int.Parse(strArr[1]);
                    marshrut[0].rasst = double.Parse(strArr[2]);

                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool trueOrFalse = false;
                    if (i == j)
                    {
                        matr[i, j] = 0;
                    }
                    else
                    {
                        foreach (var mar in marshrut)
                        {
                            if (mar.first == i && mar.second == j || mar.first == j && mar.second == i)
                            {
                                matr[i, j] = mar.rasst;
                                trueOrFalse = true;
                            }
                        }
                        if (!trueOrFalse) matr[i, j] = 100000000000;
                    }

                }
            }



        }
        

    }
}