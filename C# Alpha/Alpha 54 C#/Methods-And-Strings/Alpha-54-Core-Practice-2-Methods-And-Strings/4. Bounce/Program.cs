namespace _4._Bounce
{
    internal class Program
    {
        private static long currentPositionRow = 0;
        private static long currentPositionCol = 0;

        private static string currentDirection = "down right";

        private static long sum = 1;

        private static bool hasCornerBeenHit = false;

        static void Main(string[] args)
        {
            long[] dimensions = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long[,] board = new long[dimensions[0], dimensions[1]];

            FillBoard(board);

            if (!(board.GetLength(0) == 1 || board.GetLength(1) == 1))
            {
                while (!hasCornerBeenHit)
                {
                    MovementController(board);
                }
            }

            Console.WriteLine(sum);
        }

        private static void MovementController(long[,] board)
        {
            if (currentDirection == "down right")
            {
                MoveDownRight(board);
            }
            else if (currentDirection == "up right")
            {
                MoveUpRight(board);
            }
            else if (currentDirection == "down left")
            {
                MoveDownLeft(board);
            }
            else if (currentDirection == "up left")
            {
                MoveUpLeft(board);
            }
        }

        private static void MoveDownRight(long[,] board)
        {
            bool isRowOutOfBounds = false;
            bool isColOutOfBounds = false;

            if (currentPositionRow + 1 == board.GetLength(0))
            {
                isRowOutOfBounds = true;
            }
            if (currentPositionCol + 1 == board.GetLength(1))
            {
                isColOutOfBounds = true;
            }

            if (isRowOutOfBounds && isColOutOfBounds)
            {
                hasCornerBeenHit = true;
            }
            else if (isRowOutOfBounds)
            {
                currentDirection = "up right";
                MoveUpRight(board);
            }
            else if (isColOutOfBounds)
            {
                currentDirection = "down left";
                MoveDownLeft(board);
            }
            else
            {
                currentPositionRow++;
                currentPositionCol++;

                sum += board[currentPositionRow, currentPositionCol];
            }
        }

        private static void MoveUpRight(long[,] board)
        {
            bool isRowOutOfBounds = false;
            bool isColOutOfBounds = false;

            if (currentPositionRow -1 < 0)
            {
                isRowOutOfBounds = true;
            }
            if (currentPositionCol + 1 == board.GetLength(1))
            {
                isColOutOfBounds = true;
            }

            if (isRowOutOfBounds && isColOutOfBounds)
            {
                hasCornerBeenHit = true;
            }
            else if (isRowOutOfBounds)
            {
                currentDirection = "down right";
                MoveDownRight(board);
            }
            else if (isColOutOfBounds)
            {
                currentDirection = "up left";
                MoveUpLeft(board);
            }
            else
            {
                currentPositionRow--;
                currentPositionCol++;

                sum += board[currentPositionRow, currentPositionCol];
            }
        }

        private static void MoveDownLeft(long[,] board)
        {
            bool isRowOutOfBounds = false;
            bool isColOutOfBounds = false;

            if (currentPositionRow + 1 == board.GetLength(0))
            {
                isRowOutOfBounds = true;
            }
            if (currentPositionCol - 1 < 0)
            {
                isColOutOfBounds = true;
            }

            if (isRowOutOfBounds && isColOutOfBounds)
            {
                hasCornerBeenHit = true;
            }
            else if (isRowOutOfBounds)
            {
                currentDirection = "up left";
                MoveUpLeft(board);
            }
            else if (isColOutOfBounds)
            {
                currentDirection = "down right";
                MoveDownRight(board);
            }
            else
            {
                currentPositionRow++;
                currentPositionCol--;

                sum += board[currentPositionRow, currentPositionCol];
            }
        }

        private static void MoveUpLeft(long[,] board)
        {
            bool isRowOutOfBounds = false;
            bool isColOutOfBounds = false;

            if (currentPositionRow - 1 < 0)
            {
                isRowOutOfBounds = true;
            }
            if (currentPositionCol - 1 < 0)
            {
                isColOutOfBounds = true;
            }

            if (isRowOutOfBounds && isColOutOfBounds)
            {
                hasCornerBeenHit = true;
            }
            else if (isRowOutOfBounds)
            {
                currentDirection = "down left";
                MoveDownLeft(board);
            }
            else if (isColOutOfBounds)
            {
                currentDirection = "up right";
                MoveUpRight(board);
            }
            else
            {
                currentPositionRow--;
                currentPositionCol--;

                sum += board[currentPositionRow, currentPositionCol];
            }
        }

        private static void FillBoard(long[,] board)
        {
            int initialElement = 1;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                bool firstIteration = true;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (firstIteration)
                    {
                        board[row, col] = initialElement;
                        initialElement *= 2;

                        firstIteration = false;
                    }
                    else
                    {
                        board[row, col] = board[row, col - 1] * 2;
                    }
                }
            }
        }
    }
}