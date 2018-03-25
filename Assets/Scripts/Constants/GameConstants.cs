
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

    public static string GetPieceColorText (int pieceColor)
    {
        if (pieceColor < 0 || pieceColor >= Total_Colors)
            return null;

        return (pieceColor == White_Color) ? "WHITE" : "BLACK";
    }

    public static string GetPieceDescriptionText(int pieceDescription)
    {
        if (pieceDescription < 0 || pieceDescription >= Total_Pieces)
            return null;

        switch (pieceDescription)
        {
            case 0:
                return "PAWN";
            case 1:
                return "BISHOP";
            case 2:
                return "KNIGHT";
            case 3:
                return "ROOK";
            default:
                return null;
        }
    }

    public static string GetPieceFullText (int pieceColor, int pieceDescription)
    {
        string c = GetPieceColorText(pieceColor);
        string d = GetPieceDescriptionText(pieceDescription);

        if (c != null && d != null)
            return c + " " + d;

        return null;
    }
}
