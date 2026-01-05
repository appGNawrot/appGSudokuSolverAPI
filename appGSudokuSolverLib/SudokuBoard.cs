using System;
using System.Collections.Generic;
using System.Linq;
namespace appGSudokuSolverLib;

internal sealed class SudokuBoard
{
    internal SudokuSquare[] Squares = Enumerable.Range(0, 9).Select(_ => new SudokuSquare()).ToArray();
}
