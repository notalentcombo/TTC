using UnityEngine;
public static class GameConstants
{
    public static readonly int X_Columns = 4;
    public static readonly int Y_Rows = 4;
    public static readonly int White_StartingY_Row = -2;
    public static readonly int Black_StartingY_Row = 5;

    public static readonly int Total_Colors = 2;
    public static readonly int Total_Pieces = 4;

    public static readonly int Total_Turns_Before_Attacks = 6;

    public static readonly Color HighlightPieceColor = Color.cyan;
    public static readonly Color HighlightBoardCellColor = Color.green;
    public static readonly Color DefaultColor = Color.white;
}

public enum ChessPieceRank
{
    PAWN = 0,
    BISHOP = 1,
    KNIGHT = 2,
    ROOK = 3
}

public enum ChessPieceColor
{
    WHITE = 0,
    BLACK = 1
}


