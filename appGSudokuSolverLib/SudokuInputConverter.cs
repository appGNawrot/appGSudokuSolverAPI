namespace appGSudokuSolverLib;

internal static class SudokuInputConverter
{
    /// <summary>
    /// Board = 0 - empty, 1-9 data. Input row by row
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static SudokuBoard Convert(List<byte> board)
    {
        var result = new SudokuBoard();
        if (board.Count < 81)
            return result;
        int actualCell = 0, addPosition = 0, actualSquare = 0, addSquare = 0;
        foreach (var data in board)
        {
            result.Squares[actualSquare + addSquare].Data[actualCell + addPosition] = data;
            if (++actualCell > 2)
            {
                actualCell = 0;
                if (++actualSquare > 2)
                {
                    actualSquare = 0;
                    addPosition += 3;
                    if (addPosition >= 9)
                    {
                        addPosition = 0;
                        addSquare += 3;
                    }
                }
            }
        }
        return result;
    }
}
