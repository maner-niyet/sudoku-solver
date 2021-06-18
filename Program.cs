using System;

namespace SudokuSolver
{
    class Program
    {
        public static bool isValid(int[,] board, int row, int col, int num)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[row, i] == num) 
                    return false;
 
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, col] == num)
                    return false;

            int squareroot = (int)Math.Sqrt(board.GetLength(0));
            int rowStart = row - row % squareroot;
            int colStart = col - col % squareroot;

            for (int i = rowStart; i < rowStart + squareroot; i++)
                for (int j = colStart; j < colStart + squareroot; j++)
                    if (board[i, j] == num)
                        return false; 
            return true;
        }

        public static bool isSolved(int[,] board, int n)
        {
            int row = 0;
            int col = 0;

            bool isEmpty = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) 
                {
                    if (board[i, j] == 0) 
                    {
                        row = i; 
                        col = j;
                        isEmpty = false; 
                        break;
                    }
                }
                if (!isEmpty) 
                {
                    break;
                }
            }

            if (isEmpty) 
            {
                return true;
            }

            for (int num = 1; num <= n; num++)
            {
                if (isValid(board, row, col, num)) 
                {
                    board[row, col] = num; 
                    if (isSolved(board, n)) 
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0; 
                    }
                }
            }
            return false;
        }

        public static void printSolution(int[,] board, int N)
        {
         
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");

                if ((i + 1) % (int)Math.Sqrt(N) == 0)
                {
                    Console.Write("");
                }
            }
        }
        public static void Main(String[] args)
        {

            int[,] board = new int[,]
            {
            {3, 0, 0, 0, 0, 8, 0, 0, 0},
            {7, 0, 8, 3, 2, 0, 0, 0, 5},
            {0, 0, 0, 9, 0, 0, 0, 1, 0},
            {9, 0, 0, 0, 0, 4, 0, 2, 0},
            {0, 0, 0, 0, 1, 0, 0, 0, 0},
            {0, 7, 0, 8, 0, 0, 0, 0, 9},
            {0, 5, 0, 0, 0, 3, 0, 0, 0},
            {8, 0, 0, 0, 4, 7, 5, 0, 3},
            {0, 0, 0, 5, 0, 0, 0, 0, 6}
            };

            int N = board.GetLength(0); 

            if (isSolved(board, N))
                printSolution(board, N);
            else
                Console.Write("No solution");
        }
    }
}