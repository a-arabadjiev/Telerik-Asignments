namespace _03._Navigation
{
    using System.Numerics;

    internal class Program
    {
        private static int currentPositionRow = 4;
        private static int currentPositionCol = 0;

        private static BigInteger sum = 1;

        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            int c = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int[] codes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> coordinates = new List<int>();

            int coeff = Math.Max(r, c);

            for (int i = 0; i < n; i++)
            {
                int col = codes[i] % coeff;
                int row = codes[i] / coeff;

                coordinates.Add(col);
                coordinates.Add(row);
            }

            BigInteger[,] matrix = new BigInteger[r, c];

            FillMatrix(matrix);

            InitiateMovements(matrix, coordinates);

            Console.WriteLine(sum);
        }

        private static void InitiateMovements(BigInteger[,] matrix, List<int> coordinates)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                // Column Movements
                if (i % 2 == 0)
                {
                    if (currentPositionCol < coordinates[i])
                    {
                        for (int col = currentPositionCol + 1; col <= coordinates[i]; col++)
                        {
                            sum += matrix[currentPositionRow, col];
                            matrix[currentPositionRow, col] = 0;
                            currentPositionCol++;
                        }
                    }
                    else if (currentPositionCol > coordinates[i])
                    {
                        for (int col = currentPositionCol - 1; col >= coordinates[i]; col--)
                        {
                            sum += matrix[currentPositionRow, col];
                            matrix[currentPositionRow, col] = 0;
                            currentPositionCol--;
                        }
                    }
                }
                // Row Movements
                else
                {
                    if (currentPositionRow < coordinates[i])
                    {
                        for (int row = currentPositionRow + 1; row <= coordinates[i]; row++)
                        {
                            sum += matrix[row, currentPositionCol];
                            matrix[row, currentPositionCol] = 0;
                            currentPositionRow++;
                        }
                    }
                    else if (currentPositionRow > coordinates[i])
                    {
                        for (int row = currentPositionRow - 1; row >= coordinates[i]; row--)
                        {
                            sum += matrix[row, currentPositionCol];
                            matrix[row, currentPositionCol] = 0;
                            currentPositionRow--;
                        }
                    }
                }
            }
        }

        private static void FillMatrix(BigInteger[,] matrix)
        {
            ulong initialElement = 1;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                bool firstIteration = true;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (firstIteration)
                    {
                        matrix[row, col] = initialElement;
                        initialElement *= 2;

                        firstIteration = false;
                    }
                    else
                    {
                        matrix[row, col] = matrix[row, col - 1] * 2;
                    }
                }
            }

            matrix[0, 0] = 0;
        }
    }
}