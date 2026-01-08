namespace appGSudokuSolverLibTest;

public class SudokuInputConverterTest
{
    private static List<byte> TestData()
    {
        byte[] data = [ 0,6,9,0,0,1,7,3,0,
                        0,7,0,0,2,4,0,0,1,
                        0,1,0,0,0,0,0,6,4,
                        3,5,0,0,4,0,6,0,0,
                        0,9,0,0,0,6,0,5,0,
                        0,0,7,9,3,0,0,0,0,
                        0,0,0,0,0,3,2,0,0,
                        0,0,0,0,1,0,0,9,0,
                        0,0,0,0,0,0,4,0,0];
        return data.ToList();
    }

    private static SudokuBoard TestBoard()
    {
        var result =  new SudokuBoard();
        result.Squares[0].Data = new byte[] { 0, 6, 9, 0, 7, 0, 0, 1, 0 };
        result.Squares[1].Data = new byte[] { 0, 0, 1, 0, 2, 4, 0, 0, 0 };
        result.Squares[2].Data = new byte[] { 7, 3, 0, 0, 0, 1, 0, 6, 4 };

        result.Squares[3].Data = new byte[] { 3, 5, 0, 0, 9, 0, 0, 0, 7 };
        result.Squares[4].Data = new byte[] { 0, 4, 0, 0, 0, 6, 9, 3, 0 };
        result.Squares[5].Data = new byte[] { 6, 0, 0, 0, 5, 0, 0, 0, 0 };

        result.Squares[6].Data = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        result.Squares[7].Data = new byte[] { 0, 0, 3, 0, 1, 0, 0, 0, 0 };
        result.Squares[8].Data = new byte[] { 2, 0, 0, 0, 9, 0, 4, 0, 0 };

        return result;
    }


    [Fact]
    public void Convert()
    {
        var converted = SudokuInputConverter.Convert(TestData());
        Assert.True(BoardIsEquals(TestBoard(), converted));
        
    }


    private bool IsEquals(SudokuSquare a, SudokuSquare b)
    {
        return SudokuHelperTest.ArrayIsEquals(a.Data, b.Data);
    }

    private bool BoardIsEquals(SudokuBoard a, SudokuBoard b)
    {
        for (int i = 0; i < 9; i++)
            if (!IsEquals(a.Squares[i], b.Squares[i]))
                return false;
        return true;
    }
}
