namespace _04._KnightMoves
{
    internal class Program
    {
        internal static int knightPositionRow = 0;
        internal static int knightPositionCol = 0;

        internal static int movesCount = 1;

        static void Main(string[] args)
        {
            // Board Creation
            int boardSize = int.Parse(Console.ReadLine());

            int[,] chessBoard = new int[boardSize, boardSize];

            chessBoard[0,0] = movesCount;

            bool isBoardFull = false;

            // Board Actions
            while (isBoardFull == false)
            {
                // Possible Moves
                int[] upwardsLeftPosition = new int[2] { knightPositionRow - 2, knightPositionCol - 1 };

                int[] upwardsRightPosition = new int[2] { knightPositionRow - 2, knightPositionCol + 1 };

                int[] leftUpwardsPosition = new int[2] { knightPositionRow - 1, knightPositionCol - 2 };

                int[] rightUpwardsPosition = new int[2] { knightPositionRow - 1, knightPositionCol + 2 };

                int[] leftDownwardsPosition = new int[2] { knightPositionRow + 1, knightPositionCol - 2 };

                int[] rightDownwardsPosition = new int[2] { knightPositionRow + 1, knightPositionCol + 2 };

                int[] downwardsLeftPosition = new int[2] { knightPositionRow + 2, knightPositionCol - 1 };

                int[] downwardsRightPosition = new int[2] { knightPositionRow + 2, knightPositionCol + 1 };

                // Asses Most Optimal Move
                if (IsSquareLegal(upwardsLeftPosition, chessBoard))
                {
                    MakeMove(chessBoard, upwardsLeftPosition);
                }

                else if (IsSquareLegal(upwardsRightPosition, chessBoard))
                {
                    MakeMove(chessBoard, upwardsRightPosition);
                }

                else if (IsSquareLegal(leftUpwardsPosition, chessBoard))
                {
                    MakeMove(chessBoard, leftUpwardsPosition);
                }

                else if (IsSquareLegal(rightUpwardsPosition, chessBoard))
                {
                    MakeMove(chessBoard, rightUpwardsPosition);
                }

                else if (IsSquareLegal(leftDownwardsPosition, chessBoard))
                {
                    MakeMove(chessBoard, leftDownwardsPosition);
                }

                else if (IsSquareLegal(rightDownwardsPosition, chessBoard))
                {
                    MakeMove(chessBoard, rightDownwardsPosition);
                }

                else if (IsSquareLegal(downwardsLeftPosition, chessBoard))
                {
                    MakeMove(chessBoard, downwardsLeftPosition);
                }

                else if (IsSquareLegal(downwardsRightPosition, chessBoard))
                {
                    MakeMove(chessBoard, downwardsRightPosition);
                }

                else
                {
                    int[] bestAvailablePosition = ReturnTopLeftMostAvailablePosition(chessBoard);

                    if (bestAvailablePosition[0] == -1) 
                    {
                        isBoardFull = true;
                    }
                    else 
                    {
                        MakeMove(chessBoard, bestAvailablePosition);
                    }
                }
            }

            // Print Board
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write($"{chessBoard[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void MakeMove(int[,] chessBoard, int[] positionCoordinates)
        {
            movesCount++;
            chessBoard[positionCoordinates[0], positionCoordinates[1]] = movesCount;

            knightPositionRow = positionCoordinates[0];
            knightPositionCol = positionCoordinates[1];
        }

        private static bool IsSquareLegal(int[] desiredPosition, int[,] chessBoard)
        {
            // Check if outside of bounds
            if (desiredPosition[0] < 0 || desiredPosition[1] < 0 || desiredPosition[0] > chessBoard.GetLength(0) - 1 || desiredPosition[1] > chessBoard.GetLength(1) - 1)
            {
                return false;
            }

            // Check if square has already been visited
            if (chessBoard[desiredPosition[0], desiredPosition[1]] != 0)
            {
                return false;
            }

            return true;
        }

        private static int[] ReturnTopLeftMostAvailablePosition(int[,] chessBoard)
        {
            int[] position = new int[2];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    if (chessBoard[row, col] == 0)
                    {
                        position[0] = row;
                        position[1] = col;

                        return position;
                    }
                }
            }

            position[0] = -1;

            return position;
        }
    }
}