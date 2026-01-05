namespace appGSudokuSolverLib;

internal static class SudokuHelper
{
    internal static bool CheckSquare(SudokuSquare square, bool mustBeComplete)
    {
        byte[] requiredData = new byte[10];
        foreach (var value in square.Data)
        {
            if (value > 9)
                throw new ArgumentException("Sudoku value must be 0-9.");
            requiredData[value]++;
        }
        if (mustBeComplete && requiredData[0] > 0)
            return false;
        for (int i = 1; i <= 9; i++) //skip 0
            if (requiredData[i] > 1)
                return false;
        return true;
    }

    internal static bool CheckColumn(SudokuBoard board, int columnIndex, bool mustBeComplete)
    {
        if (columnIndex < 0 || columnIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        byte[] requiredData = new byte[10];
        for (byte rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            int squareIndex = (rowIndex / 3) * 3 + (columnIndex / 3);
            int cellIndex = (rowIndex % 3) * 3 + (columnIndex % 3);
            byte value = board.Squares[squareIndex].Data[cellIndex];
            if (value > 9 || value < 0)
                throw new ArgumentException("Sudoku value must be 0-9.");
            requiredData[value]++;
        }
        if (mustBeComplete && requiredData[0] > 0)
            return false;
        for (int i = 1; i <= 9; i++) //skip 0
            if (requiredData[i] > 1)
                return false;
        return true;
    }


    internal static bool CheckRow(SudokuBoard board, int rowIndex, bool mustBeComplete)
    {
        if (rowIndex < 0 || rowIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        byte[] requiredData = new byte[10];
        for (int colIndex = 0; colIndex < 9; colIndex++)
        {
            int squareIndex = (rowIndex / 3) * 3 + (colIndex / 3);
            int cellIndex = (rowIndex % 3) * 3 + (colIndex % 3);
            byte value = board.Squares[squareIndex].Data[cellIndex];
            if (value > 9 || value < 0)
                throw new ArgumentException("Sudoku value must be 0-9.");
            requiredData[value]++;
        }
        if (mustBeComplete && requiredData[0] > 0)
            return false;
        for (int i = 1; i <= 9; i++) //skip 0
            if (requiredData[i] > 1)
                return false;
        return true;
    }

    internal static bool CheckAllBoard(SudokuBoard board, bool mustBeComplete)
    {
        //check squares
        foreach (var square in board.Squares)
            if (!CheckSquare(square, mustBeComplete))
                return false;
        //check columns and rows
        for (int i = 0; i < 9; i++)
        {
            if (!CheckColumn(board, i, mustBeComplete))
                return false;
            if (!CheckRow(board, i, mustBeComplete))
                return false;
        }
        return true;
    } 
}
