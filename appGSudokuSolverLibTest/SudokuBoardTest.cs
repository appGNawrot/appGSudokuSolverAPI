namespace appGSudokuSolverLibTest;

public class SudokuBoardTest
{
    [Fact]
    public void Copy()
    {
        SudokuBoard board = new SudokuBoard();
        byte value = 9;
        board.Squares[0].Data[1] = value;
        var copy = board.Copy();
        Assert.True(copy.Squares[0].Data[1] == value, "Can't copy");
    }
}