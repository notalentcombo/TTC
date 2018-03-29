using UnityEngine;

public static class GameUtils
{
    public static string GetPieceColorText(ChessPieceColor pieceColor)
    {
        switch (pieceColor)
        {
            case ChessPieceColor.WHITE:
                return "WHITE";
            case ChessPieceColor.BLACK:
                return "BLACK";
        }

        return null;
    }

    public static string GetPieceRankText(ChessPieceRank pieceRank)
    {
        switch (pieceRank)
        {
            case ChessPieceRank.PAWN:
                return "PAWN";
            case ChessPieceRank.BISHOP:
                return "BISHOP";
            case ChessPieceRank.KNIGHT:
                return "KNIGHT";
            case ChessPieceRank.ROOK:
                return "ROOK";
        }

        return null;
    }

    public static string GetPieceFullText(Piece p)
    {
        string c = GetPieceColorText(p.GetColor());
        string d = GetPieceRankText(p.GetRank());

        if (c != null && d != null)
            return c + " " + d;

        return null;
    }

    public static bool VerifyGridPositionOnBoard (Vector2Int p)
    {
        return (p.x >= 0 && p.x < GameConstants.X_Columns && p.y >= 0 && p.y < GameConstants.Y_Rows);
    }

    public static Vector2Int GetStartingGridPosition(Piece p)
    {
        int x = (int)p.GetRank();
        int y = (p.GetColor() == ChessPieceColor.WHITE) ? GameConstants.White_StartingY_Row : GameConstants.Black_StartingY_Row;

        return new Vector2Int(x,y);
    }

    public static Vector2Int Vector3ToVector2Int(Vector3 v)
    {
        int x = Mathf.CeilToInt(v.x) - 1;
        int y = Mathf.CeilToInt(v.y) - 1;

        return new Vector2Int(x, y);
    }

    public static Vector3 Vector2IntToVector3(Vector2Int v)
    {
        return new Vector3(v.x, v.y, 0);
    }

    public static Vector3Int Vector2IntToVector3Int(Vector2Int v)
    {
        return new Vector3Int(v.x, v.y, 0);
    }
}