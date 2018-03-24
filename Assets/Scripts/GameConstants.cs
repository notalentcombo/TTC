using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static readonly int XColumns = 4;
    public static readonly int YRows = 4;

    public static readonly int Colors = 2;
    public static readonly int Pieces = 4;

    public static readonly int whiteStartingYRow = -2;
    public static readonly int blackStartingYRow = 5;

    /* probably not needed but I'll leave it for reference right now*/
    public static readonly Vector2 startingWhitePawnPosition = new Vector2(0, -2);
    public static readonly Vector2 startingWhiteBishopPosition = new Vector2(1, -2);
    public static readonly Vector2 startingWhiteKnightPosition = new Vector2(2, -2);
    public static readonly Vector2 startingWhiteRookPosition = new Vector2(3, -2);

    public static readonly Vector2 startingBlackPawnPosition = new Vector2(0, 5);
    public static readonly Vector2 startingBlackBishopPosition = new Vector2(1, 5);
    public static readonly Vector2 startingBlackKnightPosition = new Vector2(2, 5);
    public static readonly Vector2 startingBlackRookPosition = new Vector2(3, 5);

}
