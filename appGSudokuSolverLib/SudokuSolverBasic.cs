
namespace appGSudokuSolverLib;

internal class SudokuSolverBasic : ISudokuSolver
{
    public List<byte> Solve(List<byte> board)
    {
        var inputBoard = SudokuInputConverter.Convert(board);
        if (!SudokuHelper.CheckAllBoard(inputBoard, false))
            throw new ArgumentException("Invalid data");
        return SudokuOutputConverter.Convert(inputBoard);
    }
}
