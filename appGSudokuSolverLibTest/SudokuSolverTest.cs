namespace appGSudokuSolverLibTest;

public class SudokuSolverTest
{
    private static List<byte> TestBoard()
    {
        byte[] data = [ 3,0,0,0,0,8,0,0,9,
                        7,0,0,5,0,0,0,2,0,
                        0,0,0,0,0,0,0,0,0,
                        0,4,6,0,0,0,0,0,0,
                        2,0,0,1,0,0,0,3,0,
                        0,0,3,8,0,0,4,0,0,
                        8,0,0,0,0,7,0,5,0,
                        0,0,0,0,0,6,0,4,0,
                        6,7,0,0,0,9,2,0,0];
        return data.ToList();
    }


    private static List<byte> SolvedBoard()
    {
        byte[] data = [ 3,2,5,6,4,8,7,1,9,
                        7,6,9,5,3,1,8,2,4,
                        4,1,8,9,7,2,5,6,3,
                        5,4,6,7,2,3,1,9,8,
                        2,8,7,1,9,4,6,3,5,
                        1,9,3,8,6,5,4,7,2,
                        8,3,2,4,1,7,9,5,6,
                        9,5,1,2,8,6,3,4,7,
                        6,7,4,3,5,9,2,8,1];
        return data.ToList();
    }


    [Theory]
    [InlineData("", true)]
    [InlineData("bAsic", true)]
    [InlineData("naive", true)]
    [InlineData("speed", false)]
    public void Solve(string typeSolver, bool expectedResult)
    {
        try
        {
            var solvedSudoku = SudokuSolver.Instance.Solve(TestBoard(), typeSolver);
            if(solvedSudoku == null)
            {
                if (!expectedResult)
                    Assert.True(true);
                else
                    Assert.Fail("Can't solved sudoku");
                return;
            }
            if (expectedResult)
                Assert.True(solvedSudoku.SequenceEqual(SolvedBoard()), "Invalid result");
            else
                Assert.False(solvedSudoku.SequenceEqual(SolvedBoard()));

        }
        catch
        {
            if (!expectedResult)
                Assert.True(true);
            else
                Assert.Fail("Can't solved sudoku");
        }

    }
}
