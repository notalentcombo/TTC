using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtils
{
    public static string GetPieceColorText(int pieceColor)
    {
        if (pieceColor < 0 || pieceColor >= GameConstants.Total_Colors)
            return null;

        return (pieceColor == GameConstants.White_Color) ? "WHITE" : "BLACK";
    }

    public static string GetPieceRankText(int pieceRank)
    {
        switch (pieceRank)
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

    public static string GetPieceFullText(int pieceColor, int pieceRank)
    {
        string c = GetPieceColorText(pieceColor);
        string d = GetPieceRankText(pieceRank);

        if (c != null && d != null)
            return c + " " + d;

        return null;
    }

    public static bool VerifyGridPositionOnBoard (Vector2Int p)
    {
        return (p.x >= 0 && p.x < GameConstants.X_Columns && p.y >= 0 && p.y < GameConstants.Y_Rows);
    }

    public static Vector2Int GetStartingGridPosition(int pieceColor, int pieceDescription)
    {
        int startingY = (pieceColor == GameConstants.White_Color) ? GameConstants.White_StartingY_Row : GameConstants.Black_StartingY_Row;
        return new Vector2Int(pieceDescription, startingY);
    }

    public static Vector2Int ConvertVector3ToGridPosition(Vector3 v)
    {
        int x = Mathf.CeilToInt(v.x) - 1;
        int y = Mathf.CeilToInt(v.y) - 1;

        return new Vector2Int(x, y);
    }

    public static Vector3 ConvertGridPositionToVector3(Vector2Int p)
    {
        return new Vector3(p.x, p.y, 0);
    }

}
