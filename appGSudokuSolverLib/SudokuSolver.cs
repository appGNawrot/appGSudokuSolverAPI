namespace appGSudokuSolverLib;

public class SudokuSolver
{
    private static readonly Lazy<SudokuSolver> _instance = new Lazy<SudokuSolver>(() => new SudokuSolver());
    public static SudokuSolver Instance => _instance.Value;

    private Dictionary<string, ISudokuSolver> AvailableSolvers = new();
    internal SudokuSolver()
    {
        AvailableSolvers.Add("BASIC", new SudokuSolverBasic());
        AvailableSolvers.Add("NAIVE", new SudokuSolverNaive());
    }

    /// <summary>
    /// Solve Sudoku
    /// </summary>
    /// <param name="board"></param>
    /// <param name="solverType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Throw exception when solver type not found</exception>
    public List<byte> Solve(List<byte> board, string solverType = "Basic")
    {
        if (string.IsNullOrWhiteSpace(solverType))
            solverType = "Basic";
        solverType = solverType.ToUpper();  
        if (!AvailableSolvers.ContainsKey(solverType))
            throw new ArgumentException("Solver type not found");
        return AvailableSolvers[solverType].Solve(board);
    }
}
