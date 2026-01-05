namespace appGSudokuSolverLib;

internal class SudokuOutputConverter
{
    /// <summary>
    /// Board = SudokuBoard, Output is data row by row
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static List<byte> Convert(SudokuBoard board)
    {
        var result = new List<byte>();
        if(board == null)
            return result;
        int actualCell = 0, addPosition = 0,actualSquare = 0, addSquare = 0;

        while (addSquare < 9)
        {
            result.Add(board.Squares[actualSquare + addSquare].Data[actualCell + addPosition]);
            if (++actualCell > 2)
            {
                actualCell = 0;
                if (++actualSquare > 2)
                {
                    actualSquare = 0;
                    addPosition+=3;
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
