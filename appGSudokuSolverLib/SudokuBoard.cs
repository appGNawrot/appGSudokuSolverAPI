namespace appGSudokuSolverLib;

internal sealed class SudokuBoard
{
    internal SudokuSquare[] Squares = Enumerable.Range(0, 9).Select(_ => new SudokuSquare()).ToArray();

    internal SudokuBoard Copy()
    {
        var copy = new SudokuBoard();
        for(int i=0;i<9;i++)
        {
            copy.Squares[i] = Squares[i].Copy();
        }
        return copy;
    }
}
