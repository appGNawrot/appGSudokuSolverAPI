namespace appGSudokuSolverLib;

internal sealed class SudokuSquare
{
    internal byte[] Data = new byte[9];     
    internal SudokuSquare Copy()
    {
        var copy = new SudokuSquare();
        for(int i=0;i<9;i++)
            copy.Data[i] = Data[i];
        return copy;
    }
}
