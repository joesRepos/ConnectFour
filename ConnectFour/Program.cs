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

char[,] board = new char[6,7];
InitialiseBoard(board);