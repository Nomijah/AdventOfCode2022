namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\pette\Documents\AoC15b.txt");

            List<Point> SBList = new List<Point>();
            foreach (string s in input)
            {
                if (s != "")
                {
                    string[] temp = s.Split(" ");
                    string[] Sx = temp[2].Split("=");
                    string[] Sy = temp[3].Split("=");
                    SBList.Add(new Point(Convert.ToInt32(Sx[1].Remove(Sx[1].Length - 1)),
                        Convert.ToInt32(Sy[1].Remove(Sy[1].Length - 1)), 'S'));
                    string[] Bx = temp[8].Split("=");
                    string[] By = temp[9].Split("=");
                    SBList.Add(new Point(Convert.ToInt32(Bx[1].Remove(Bx[1].Length - 1)),
                        Convert.ToInt32(By[1]), 'B'));
                }
            }

            //foreach (Point p in SBList)
            //{
            //    Console.WriteLine($"{p.x} {p.y} {p.img}");
            //}
            //Console.ReadKey();

            // Create point map.
            Point[,] map = new Point[100, 100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i, j] = new Point(j, i, '.');
                }
            }

            //foreach (Point p in map)
            //{
            //    Console.WriteLine(p.x + " " + p.y + " " + p.img);
            //}

            foreach (Point p in SBList)
            {
                foreach (Point mp in map)
                {
                    if (p.x + 20 == mp.x && p.y + 20 == mp.y)
                    {
                        mp.img = p.img;
                    }
                }
            }

            for (int i = 0; i < SBList.Count; i += 2)
            {
                int xdif = Diff(SBList[i].x, SBList[i + 1].x);
                int ydif = Diff(SBList[i].y, SBList[i + 1].y);
                int Sx = SBList[i].x + 20;
                int Sy = SBList[i].y + 20;
                int dist = xdif + ydif;
                for (int j = 0; j < dist; j++)
                {
                    for (int k = dist - j; k > 0; k--)
                    {
                        if (map[Sy + k, Sx + j].img == '.')
                        {
                            map[Sy + k, Sx + j].img = '#';
                        }
                        if (map[Sy - k, Sx - j].img == '.')
                        {
                            map[Sy - k, Sx - j].img = '#';
                        }
                        if (map[Sy + j, Sx - k].img == '.')
                        {
                            map[Sy + j, Sx - k].img = '#';
                        }
                        if (map[Sy - j, Sx + k].img == '.')
                        {
                            map[Sy - j, Sx + k].img = '#';
                        }
                    }
                }
            }

            // Print map.
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(map[i, j].img);
                }
                Console.WriteLine();
            }
        }

        public static int Diff(int a, int b)
        {
            if (a > b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public char img;

        public Point(int X, int Y, char Img)
        {
            x = X;
            y = Y;
            img = Img;
        }
    }
}