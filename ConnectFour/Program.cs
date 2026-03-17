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

static bool DropPiece(char[,] board, int column, char player)
{
    for (int r = 5; r >= 0; r--)
    {
        if (board[r, column] == '.')
        {
            board[r, column] = player;
            return true;
        }
    }

    return false;
}

static bool CheckWin(char[,] board, char player)
{
    for (int row = 0; row < 6; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] == player && board[row, col + 1] == player && board[row, col + 2] == player && board[row, col + 3] == player)
                return true;
        }
    }

    return false;
}

static bool CheckDraw(char[,] board)
{
    for (int c = 0; c < 7; c++)
    {
        if (board[0, c] == '.')
            return false;
    }

    return true;
}


char[,] board = new char[6,7];
InitialiseBoard(board);

char currentPlayer = 'X';

while (true)
{
    PrintBoard(board);

    Console.Write($"Player {currentPlayer}, choose column (1-7): ");
    int column = int.Parse(Console.ReadLine()) - 1;

    if (DropPiece(board, column, currentPlayer))
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
    else
    {
        Console.WriteLine("Column full.");
    }

    if (CheckWin(board, currentPlayer))
    {
        PrintBoard(board);
        Console.WriteLine($"Player {currentPlayer} wins!");
        Console.WriteLine("Game Over.");
        break;
    }
    else if (CheckDraw(board))
    {
        PrintBoard(board);
        Console.WriteLine("Draw");
        Console.WriteLine("Game Over.");
        break;

    }
}