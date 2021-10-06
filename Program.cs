using System;

namespace donut
{
    class Program
    {
        static double[] genZ(int height, int width)
        {
            int zSize = 4 * height * width;
            double[] z = new double[zSize];
            for (int idx = 0; idx < zSize; idx++)
            {
                z[idx] = 0;
            }

            return z;
        }

        static char[] genScreen(int height, int width)
        {
            int size = height * width;
            char[] screen = new char[size];
            for (int idx = 0; idx < size; idx++)
            {
                screen[idx] = ' ';
            }

            return screen;
        }

        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;

            int height = 24;
            int width = 80;

            Console.Clear();
            while (true)
            {
                double[] z = genZ(height, width);
                char[] screen = genScreen(height, width);

                double j = 0;
                while (j < 6.28)
                {
                    j = j + 0.07;
                    double i = 0;
                    while (i < 6.28)
                    {
                        i = i + 0.02;

                        double sinA = Math.Sin(a);
                        double cosA = Math.Cos(a);
                        double sinB = Math.Sin(b);
                        double cosB = Math.Cos(b);

                        double sinI = Math.Sin(i);
                        double cosI = Math.Cos(i);
                        double sinJ = Math.Sin(j);
                        double cosJ = Math.Cos(j);

                        double cosj2 = cosJ + 2;

                        double mess = 1 / (sinI * cosj2 * sinA + sinJ * cosA + 5);
                        double t = sinI * cosj2 * cosA - sinJ * sinA;

                        int x = ((int)(40 + 30 * mess * (cosI * cosj2 * cosB - t * sinB))); // Possible bug
                        int y = ((int)(11 + 15 * mess * (cosI * cosj2 * sinB + t * cosB)));

                        int o = (int)(x + width * y);

                        int n = (int)(8 * ((sinJ * sinA - sinI * cosJ * cosA) * cosB - sinI * cosJ * sinA - sinJ * cosA - cosI * cosJ * sinB));

                        if (y > 0 && y < height && x > 0 && x < width && z[o] < mess)
                        {
                            z[o] = mess;
                            if (n > 0)
                            {
                                screen[o] = ".,-~:;=!*#$@"[n];
                            }
                            else
                            {
                                screen[o] = ".,-~:;=!*#$@"[0];
                            }
                        }
                    }
                }

                Console.Clear();
                for (int idx = 0; idx < screen.Length; idx++)
                {
                    if (idx % width == 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(screen[idx]);
                    }
                }

                a = a + 0.04;
                b = b + 0.02;

            }
        }
    }
}