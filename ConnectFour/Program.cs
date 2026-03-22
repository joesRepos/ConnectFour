// Set up the board.
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


// Display the board.
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

// Make a move by dropping a piece in a column.
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


// Boolean check for a win state.
static bool CheckWin(char[,] board, char player)
{
    // Horizontal check.
    for (int row = 0; row < 6; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] == player &&
                board[row, col + 1] == player &&
                board[row, col + 2] == player &&
                board[row, col + 3] == player)
                return true;
        }
    }

    // Vertical check.
    for (int col = 0; col < 7; col++)
    {
        for (int row = 0; row < 3; row++)
        {
            if (board[row, col] == player &&
                board[row + 1, col] == player &&
                board[row + 2, col] == player &&
                board[row + 3, col] == player)
                return true;
        }
    }

    // Diagonal check.
    for (int row = 3; row < 6; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] == player &&
                board[row - 1, col + 1] == player &&
                board[row - 2, col + 2] == player &&
                board[row - 3, col + 3] == player)
                return true;
        }
    }
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (board[row, col] == player &&
                board[row + 1, col + 1] == player &&
                board[row + 2, col + 2] == player &&
                board[row + 3, col + 3] == player)
                return true;
        }
    }

    return false;
}

// Boolean check for a draw state.
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


// Game loop.
while (true)
{
    PrintBoard(board);

    Console.Write($"Player {currentPlayer}, choose column (1-7): ");
    int column = int.Parse(Console.ReadLine());
    

    if (column < 1 || column > 7)
    {
        Console.WriteLine("Invalid input. Try again.");
        continue;
    }

    column -= 1;

    if (DropPiece(board, column, currentPlayer))
    {
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
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
    else
    {
        Console.WriteLine("Column full.");
    }

    
}