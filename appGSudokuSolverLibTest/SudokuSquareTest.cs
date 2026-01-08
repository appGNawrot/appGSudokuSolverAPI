namespace appGSudokuSolverLibTest;

public class SudokuSquareTest
{
    [Theory]
    [InlineData(new byte[] { 1, 3, 2, 5, 4, 9, 6, 7, 8 })]
    public void Copy(byte[] data)
    {
        SudokuSquare square = new SudokuSquare();
        square.Data = data;
        var copy = square.Copy();
        Assert.True(SudokuHelperTest.ArrayIsEquals(data,copy.Data), "Can't copy");
    }
}
