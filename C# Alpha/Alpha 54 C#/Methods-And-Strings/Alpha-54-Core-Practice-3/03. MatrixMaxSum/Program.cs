namespace _03._MatrixMaxSum
{
    internal class Program
    {
        private static long currentSum = 0;
        private static List<long> allSums = new List<long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[] currentRow = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long[,] matrix = new long[n, currentRow.Length];

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < currentRow.Length; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }

                if (rows + 1 != n)
                {
                    currentRow = Console.ReadLine().Split().Select(long.Parse).ToArray();
                }
            }

            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            IterateTroughCoordinates(matrix, coordinates);

            Console.WriteLine(allSums.Max());
        }

        private static void IterateTroughCoordinates(long[,] matrix, int[] coordinates)
        {
            for (int i = 0; i < coordinates.Length; i = i + 2)
            {
                int rowCoordinate = coordinates[i];
                int colCoordinate = coordinates[i + 1];

                InitiateColMovement(matrix, rowCoordinate, colCoordinate);

                allSums.Add(currentSum);
                currentSum = 0;
            }
        }

        private static void InitiateColMovement(long[,] matrix, int rowCoordinate, int colCoordinate)
        {
            // Determine direction and make coordinates index appropriate value
            bool isColMovementRight = rowCoordinate >= 0;
            rowCoordinate = Math.Abs(rowCoordinate);

            bool isRowMovementUpwards = colCoordinate >= 0;
            colCoordinate = Math.Abs(colCoordinate);

            rowCoordinate--;
            colCoordinate--;

            // Starting from left
            if (isColMovementRight)
            {
                for (int col = 0; col <= colCoordinate; col++)
                {
                    currentSum += matrix[rowCoordinate, col];
                }
            }
            //Starting from right
            else if (!isColMovementRight)
            {
                for (int col = matrix.GetLength(1) - 1; col >= colCoordinate; col--)
                {
                    currentSum += matrix[rowCoordinate, col];
                }
            }

            InitiateRowMovement(matrix, rowCoordinate, colCoordinate, isRowMovementUpwards);
        }

        private static void InitiateRowMovement(long[,] matrix, int rowCoordinate, int colCoordinate, bool isRowMovementUpwards)
        {
            if (isRowMovementUpwards)
            {
                for (int row = rowCoordinate - 1; row >= 0; row--)
                {
                    currentSum += matrix[row, colCoordinate];
                }
            }
            else if (!isRowMovementUpwards)
            {
                for (int row = rowCoordinate + 1; row < matrix.GetLength(0); row++)
                {
                    currentSum += matrix[row, colCoordinate];
                }
            }
        }
    }
}