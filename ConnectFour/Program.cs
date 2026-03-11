static void InitialiseBoard(char[,] board)
{
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 7; c++)
        {
            board[r, c] = '.';
        }
    }
}

static void PrintBoard(char[,] board)
{
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 7; c++)
        {
            Console.Write(board[r, c] + " ");
        }

        Console.WriteLine();
    }

    Console.WriteLine("1 2 3 4 5 6 7");
}


char[,] board = new char[6,7];
InitialiseBoard(board);
PrintBoard(board);

Console.Write("Choose a column (1-7): ");
int column = int.Parse(Console.ReadLine());

column--;