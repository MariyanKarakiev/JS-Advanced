using System;
using System.Collections.Generic;
using System.Linq;

namespace T02
{
    class Program
    {

        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public enum Matrix
        {
            M,
            A
        }

        static void Main(string[] args)
        {

            int armor = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());


            List<List<char>> matrix = new List<List<char>>();

            for (int i = 0; i < rows; i++)
            {
                matrix.Add(Console.ReadLine().ToList());
            }

            int cols = matrix[0].Count;

            Dictionary<Matrix, char> matrixValues = new Dictionary<Matrix, char>()
            {
                { Matrix.M, 'M' },

                { Matrix.A, 'A' },
            };

            int rowIndexHero = matrix.FindIndex(a => a.Contains(matrixValues[Matrix.A]));

            int rowIndexM = matrix.FindIndex(a => a.Contains(matrixValues[Matrix.M]));

            KeyValuePair<int, int> heroCoordinates = new KeyValuePair<int, int>(rowIndexHero, matrix[rowIndexHero].FindIndex(a => a == matrixValues[Matrix.A]));

            KeyValuePair<int, int> mCoordinates = new KeyValuePair<int, int>(rowIndexM, matrix[rowIndexM].FindIndex(a => a == matrixValues[Matrix.M]));

            bool foundM = false;

            while (true)
            {
                if (foundM)
                {
                    //Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");

                    break;
                }

                //if (armor <= 0)
                //{
                //    Console.WriteLine($"The army was defeated at {heroCoordinates.Key};{heroCoordinates.Value}");

                //    break;
                //}

                Stack<string> values = new Stack<string>(Console.ReadLine().Split());

                KeyValuePair<int, int> enemyCoordinates = new KeyValuePair<int, int>(int.Parse(values.Pop()), int.Parse(values.Pop()));

                Direction direction = Enum.Parse<Direction>(values.Pop(), true);

                enemyCoordinates = new KeyValuePair<int, int>(enemyCoordinates.Value, enemyCoordinates.Key);

                matrix[enemyCoordinates.Key][enemyCoordinates.Value] = 'O';

                Dictionary<Direction, KeyValuePair<int, int>> coordinatesValues = new Dictionary<Direction, KeyValuePair<int, int>>()
                {
                    { Direction.Up, new KeyValuePair<int, int>(-1, 0) },

                    { Direction.Down, new KeyValuePair<int, int>(1, 0) },

                    { Direction.Right, new KeyValuePair<int, int>(0, 1) },

                    { Direction.Left, new KeyValuePair<int, int>(0, -1) },
                };

                KeyValuePair<int, int> currentHeroCoordinates = new KeyValuePair<int, int>(heroCoordinates.Key + coordinatesValues[direction].Key, heroCoordinates.Value + coordinatesValues[direction].Value);

                armor--;

                try
                {
                    char current = matrix[currentHeroCoordinates.Key][currentHeroCoordinates.Value];

                    switch (current)
                    {
                        case 'M':

                            matrix[currentHeroCoordinates.Key][currentHeroCoordinates.Value] = '-';

                            matrix[heroCoordinates.Key][heroCoordinates.Value] = '-';

                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");

                            Console.WriteLine(string.Join("\n", matrix.Select(a => string.Join(string.Empty, a))));

                            foundM = true;

                            break;

                        case 'O':

                            armor -= 2;

                            matrix[currentHeroCoordinates.Key][currentHeroCoordinates.Value] = '-';

                            break;

                        case '-':

                            break;

                        default:
                            break;
                    }

                    matrix[heroCoordinates.Key][heroCoordinates.Value] = '-';

                    if (armor <= 0 && !foundM)
                    {
                        matrix[currentHeroCoordinates.Key][currentHeroCoordinates.Value] = 'X';

                        Console.WriteLine($"The army was defeated at {currentHeroCoordinates.Key};{currentHeroCoordinates.Value}.");

                        Console.WriteLine(string.Join("\n", matrix.Select(a => string.Join(string.Empty, a))));

                        break;
                    }

                    matrix[heroCoordinates.Key][heroCoordinates.Value] = '-';

                    heroCoordinates = new KeyValuePair<int, int>(currentHeroCoordinates.Key, currentHeroCoordinates.Value);
                }
                catch (Exception)
                {
                    continue;
                }

                //if (currentHeroCoordinates.Key, currentHeroCoordinates.Value}.Any(a => a < 0 || a > rows))
                ////if (new int[] { currentHeroCoordinates.Key, currentHeroCoordinates.Value}.Any(a => a < 0 || a > rows))
                //{

                //}
            }

        }
    }
}

