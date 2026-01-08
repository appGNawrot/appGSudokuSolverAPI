namespace appGSudokuSolverLib;

internal class SudokuSolverNaive : ISudokuSolver
{
    public List<byte> Solve(List<byte> board)
    {
        var inputBoard = SudokuInputConverter.Convert(board);
        if (!SudokuHelper.CheckBoard(inputBoard, false))
            throw new ArgumentException("Invalid data");
        var solvedBoard = SolveBoard(inputBoard);
        return SudokuOutputConverter.Convert(solvedBoard);
    }

    private SudokuBoard? SolveBoard(SudokuBoard? inputBoard)
    {
        if (inputBoard == null)
            return null;
        var findCellToFill = FindCellToFill(inputBoard);
        if (findCellToFill.rowIndex > 8)
        {
            if (SudokuHelper.CheckBoard(inputBoard, true))
                return inputBoard;
            return null;
        }

        var availableNumbers = SudokuHelper.GetAvailableNumbersInCell(inputBoard, findCellToFill.rowIndex, findCellToFill.columnIndex);
        foreach (var number in availableNumbers)
        {
            var actualCopy = inputBoard.Copy();
            SudokuHelper.FillCell(actualCopy, findCellToFill.rowIndex, findCellToFill.columnIndex, number);
            var solved = SolveBoard(actualCopy);
            if (solved != null)
                return solved;
        }
        return null;
    }


    private (byte columnIndex, byte rowIndex) FindCellToFill(SudokuBoard board)
    {
        for (byte i = 0; i < 9 * 9; i++)
        {
            byte rowIndex = (byte)(i / 9);
            byte columnIndex = (byte)(i % 9);
            var availableNumbers = SudokuHelper.GetAvailableNumbersInCell(board, rowIndex, columnIndex);
            if (availableNumbers.Count > 0)
                return (columnIndex, rowIndex);
        }
        return (9, 9);
    }

    
}
