using UnityEngine;
public static class GameConstants
{
    public static readonly int X_Columns = 4;
    public static readonly int Y_Rows = 4;
    public static readonly int White_StartingY_Row = -2;
    public static readonly int Black_StartingY_Row = 5;

    public static readonly int Total_Colors = 2;
    public static readonly int White_Color = 0;
    public static readonly int Black_Color = 1;

    public static readonly int Total_Pieces = 4;
    public static readonly int Pawn_Piece = 0;
    public static readonly int Bishop_Piece = 1;
    public static readonly int Knight_Piece = 2;
    public static readonly int Rook_Piece = 3;

    public static readonly int Turns_Before_Attacks = 6;

    public static readonly Color HighlightPieceColor = Color.cyan;
    public static readonly Color HighlightBoardCellColor = Color.green;
}
