namespace appGSudokuSolverLibTest;

public class SudokuHelperTest
{
    private static SudokuBoard _board = TestBoard();

    private static SudokuBoard TestBoard()
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
        return SudokuInputConverter.Convert(data.ToList());
    }


    [Theory]
    [InlineData(7,0,1,0,false)]
    [InlineData(2,0,1,0, true)]
    public void CheckSquare(byte value, int rowIndex, int columnIndex, int squareIndex, bool expectedResult)
    {
        var copyBoard = _board.Copy();
        SudokuHelper.FillCell(copyBoard, rowIndex, columnIndex, value);
        if (expectedResult)
            Assert.True(SudokuHelper.CheckSquare(copyBoard.Squares[squareIndex], false));
        else
            Assert.False(SudokuHelper.CheckSquare(copyBoard.Squares[squareIndex], false));
    }


    [Theory]
    [InlineData(4, 0, 1,  false)]
    [InlineData(2, 0, 1,  true)]
    public void CheckColumn(byte value, int rowIndex, int columnIndex, bool expectedResult)
    {
        var copyBoard = _board.Copy();
        SudokuHelper.FillCell(copyBoard, rowIndex, columnIndex, value);
        if (expectedResult)
            Assert.True(SudokuHelper.CheckColumn(copyBoard, columnIndex, false));
        else
            Assert.False(SudokuHelper.CheckColumn(copyBoard, columnIndex, false));
    }

    [Theory]
    [InlineData(9, 0, 1, false)]
    [InlineData(2, 0, 1, true)]
    public void CheckRow(byte value, int rowIndex, int columnIndex, bool expectedResult)
    {
        var copyBoard = _board.Copy();
        SudokuHelper.FillCell(copyBoard, rowIndex, columnIndex, value);
        if (expectedResult)
            Assert.True(SudokuHelper.CheckRow(copyBoard, rowIndex, false));
        else
            Assert.False(SudokuHelper.CheckRow(copyBoard, rowIndex, false));
    }


    [Theory]
    [InlineData(9, 0, 1, false)]
    [InlineData(4, 0, 1, false)]
    [InlineData(2, 0, 1, true)]
    public void CheckBoard(byte value, int rowIndex, int columnIndex, bool expectedResult)
    {
        var copyBoard = _board.Copy();
        SudokuHelper.FillCell(copyBoard, rowIndex, columnIndex, value);
        if (expectedResult)
            Assert.True(SudokuHelper.CheckBoard(copyBoard, false));
        else
            Assert.False(SudokuHelper.CheckBoard(copyBoard, false));
    }

    [Theory]
    [InlineData(new byte[] { 1, 2, 4, 5, 6, 8, 9 },0,true)]
    [InlineData(new byte[] { 1, 2, 3, 4, 5, 6, 8, 9 }, 0, false)]
    public void GetAvailableNumbersInSquare(byte[] availableNumbers, int squareIndex, bool expectedResult)
    {
        var resultAvailableNumbers = SudokuHelper.GetAvailableNumbersInSquare(_board.Squares[squareIndex]);

        if (expectedResult)
            Assert.True(ArrayIsEquals(availableNumbers,resultAvailableNumbers.ToArray()));
        else
            Assert.False(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
    }

    [Theory]
    [InlineData(new byte[] { 1, 2, 4, 5, 6, 7,}, 0, true)]
    [InlineData(new byte[] { 1, 2, 3, 4, 5, 6, 7, 9 }, 0, false)]
    public void GetAvailableNumbersInRow(byte[] availableNumbers, int rowIndex, bool expectedResult)
    {
        var resultAvailableNumbers = SudokuHelper.GetAvailableNumbersInRow(_board, rowIndex);

        if (expectedResult)
            Assert.True(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
        else
            Assert.False(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
    }

    [Theory]
    [InlineData(new byte[] { 1, 4, 5, 9, }, 0, true)]
    [InlineData(new byte[] { 1, 4, 5, 8, 9, }, 0, false)]
    public void GetAvailableNumbersInColumn(byte[] availableNumbers, int columnIndex, bool expectedResult)
    {
        var resultAvailableNumbers = SudokuHelper.GetAvailableNumbersInColumn(_board, columnIndex);

        if (expectedResult)
            Assert.True(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
        else
            Assert.False(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
    }

    [Theory]
    [InlineData(new byte[] { 2, 4, 6, 7 }, 0, 3, true)]
    [InlineData(new byte[] { 1, 4, 5, 8, 9, }, 0, 3, false)]
    public void GetAvailableNumbersInCell(byte[] availableNumbers, int rowIndex, int columnIndex, bool expectedResult)
    {
        var resultAvailableNumbers = SudokuHelper.GetAvailableNumbersInCell(_board, rowIndex, columnIndex);

        if (expectedResult)
            Assert.True(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
        else
            Assert.False(ArrayIsEquals(availableNumbers, resultAvailableNumbers.ToArray()));
    }

    [Theory]
    [InlineData(4, 0, 0, false)]
    [InlineData(7, 1, 0, true)]
    [InlineData(3, 0, 0, true)]
    public void GetValueInCell(byte value, int rowIndex, int columnIndex, bool expectedResult)
    {
        if (expectedResult)
            Assert.True(SudokuHelper.GetValueInCell(_board, rowIndex, columnIndex) == value);
        else
            Assert.False(SudokuHelper.GetValueInCell(_board, rowIndex, columnIndex) == value);
    }

    [Theory]
    [InlineData(4, 0, 0, false)]
    [InlineData(7, 1, 0, false)]
    [InlineData(7, 0, 1, true)]
    [InlineData(3, 2, 0, true)]
    public void FillCell(byte value, int rowIndex, int columnIndex, bool expectedResult)
    {
        var copyBoard = _board.Copy();
        
        try
        {
            SudokuHelper.FillCell(copyBoard, rowIndex, columnIndex, value);
            if (expectedResult)
                Assert.True(SudokuHelper.GetValueInCell(copyBoard, rowIndex, columnIndex) == value);
            else
                Assert.False(SudokuHelper.GetValueInCell(copyBoard, rowIndex, columnIndex) == value);
        }
        catch
        {
            if(expectedResult)
                Assert.True(false);
            else
                Assert.False(false);
        }
        
    }
    


    public static bool ArrayIsEquals(byte[] a, byte[] b)
    {
        if (a == null || b == null)
            return false;
        return a.OrderBy(x => x).SequenceEqual(b.OrderBy(x => x));
    }
    
}
