
namespace appGSudokuSolverLib;

internal class SudokuSolverBasic : ISudokuSolver
{
    public List<byte> Solve(List<byte> board)
    {
        var inputBoard = SudokuInputConverter.Convert(board);
        return SudokuOutputConverter.Convert(inputBoard);
    }
}
