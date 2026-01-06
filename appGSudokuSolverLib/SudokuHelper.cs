namespace appGSudokuSolverLib;

internal static class SudokuHelper
{
    internal static bool CheckSquare(SudokuSquare square, bool mustBeComplete)
    {
        byte[] requiredData = new byte[10];
        foreach (var value in square.Data)
        {
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

    internal static bool CheckBoard(SudokuBoard board, bool mustBeComplete)
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

    internal static List<byte> GetAvailableNumbersInSquare(SudokuSquare square)
    {
        var usedNumbers = new List<byte>();
        var availableNumbers = new List<byte>();
        foreach (var value in square.Data)
        {
            if (value > 9 || value < 0)
                throw new ArgumentException("Sudoku value must be 0-9.");
            if (usedNumbers.Contains(value))
                continue;
            usedNumbers.Add(value);
        }
        for(byte i=1;i<10;i++)
        {
            if (usedNumbers.Contains(i))
                continue;
            availableNumbers.Add(i);
        }
        return availableNumbers;
    }

    internal static List<byte> GetAvailableNumbersInRow(SudokuBoard board, int rowIndex)
    {
        if (rowIndex < 0 || rowIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        var usedNumbers = new List<byte>();
        var availableNumbers = new List<byte>();
        for (int colIndex = 0; colIndex < 9; colIndex++)
        {
            int squareIndex = (rowIndex / 3) * 3 + (colIndex / 3);
            int cellIndex = (rowIndex % 3) * 3 + (colIndex % 3);
            byte value = board.Squares[squareIndex].Data[cellIndex];
            if (value > 9 || value < 0)
                throw new ArgumentException("Sudoku value must be 0-9.");
            if (usedNumbers.Contains(value))
                continue;
            usedNumbers.Add(value);
        }
        for (byte i = 1; i < 10; i++)
        {
            if (usedNumbers.Contains(i))
                continue;
            availableNumbers.Add(i);
        }
        return availableNumbers;
    }


    internal static List<byte> GetAvailableNumbersInColumn(SudokuBoard board, int columnIndex)
    {
        if (columnIndex < 0 || columnIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        var usedNumbers = new List<byte>();
        var availableNumbers = new List<byte>();
        for (byte rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            int squareIndex = (rowIndex / 3) * 3 + (columnIndex / 3);
            int cellIndex = (rowIndex % 3) * 3 + (columnIndex % 3);
            byte value = board.Squares[squareIndex].Data[cellIndex];
            if (value > 9 || value < 0)
                throw new ArgumentException("Sudoku value must be 0-9.");
            if (usedNumbers.Contains(value))
                continue;
            usedNumbers.Add(value);
        }
        for (byte i = 1; i < 10; i++)
        {
            if (usedNumbers.Contains(i))
                continue;
            availableNumbers.Add(i);
        }
        return availableNumbers;
    }

    internal static byte GetValueInCell(SudokuBoard board, int rowIndex, int columnIndex)
    {
        if (rowIndex < 0 || rowIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        if (columnIndex < 0 || columnIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        int squareIndex = (rowIndex / 3) * 3 + (columnIndex / 3);
        int cellIndex = (rowIndex % 3) * 3 + (columnIndex % 3);
        return board.Squares[squareIndex].Data[cellIndex];
    }

    internal static List<byte> GetAvailableNumbersInCell(SudokuBoard board, int rowIndex, int columnIndex)
    {
        if(rowIndex < 0 || rowIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        if (columnIndex < 0 || columnIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(columnIndex));

        int squareIndex = (rowIndex / 3) * 3 + (columnIndex / 3);
        byte value = GetValueInCell(board, rowIndex, columnIndex);
        if (value is > 0 and < 10)
            return new List<byte>();
        var availableInSquare = GetAvailableNumbersInSquare(board.Squares[squareIndex]);
        var availableInRow = GetAvailableNumbersInRow(board, rowIndex);
        var availableInColumn = GetAvailableNumbersInColumn(board, columnIndex);

        var result = new List<byte>();
        for(byte i= 1;i<10;i++)
        {
            if (!availableInSquare.Contains(i) || !availableInRow.Contains(i) || !availableInColumn.Contains(i))
                continue;
            result.Add(i);
        }
        return result;
    }


    internal static void FillCell(SudokuBoard board, int rowIndex, int columnIndex, byte value)
    {
        if (rowIndex < 0 || rowIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        if (columnIndex < 0 || columnIndex > 8)
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        if (value < 1 || value > 9)
            throw new ArgumentException(nameof(value), "Sudoku value must be between 1 and 9.");
        int squareIndex = (rowIndex / 3) * 3 + (columnIndex / 3);
        if (GetValueInCell(board,rowIndex,columnIndex) != 0)
            throw new InvalidOperationException("Cell is already filled.");
        int cellIndex = (rowIndex % 3) * 3 + (columnIndex % 3);
        board.Squares[squareIndex].Data[cellIndex] = value;
    }
}
