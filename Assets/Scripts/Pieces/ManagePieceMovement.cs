using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePieceMovement : MonoBehaviour
{
    #region Vars
    Piece piece;
    IChessPieceMovement currentPieceControl;

    #endregion

    public void Init (Piece p)
    {
        piece = p;
        GetInterface();
    }

    private void GetInterface()
    {
        switch (piece.GetRank())
        {
            case ChessPieceRank.PAWN:
                currentPieceControl = new PawnMovement();
                break;
            case ChessPieceRank.BISHOP:
                currentPieceControl = new BishopMovement();
                break;
            case ChessPieceRank.KNIGHT:
                currentPieceControl = new KnightMovement();
                break;
            case ChessPieceRank.ROOK:
                currentPieceControl = new RookMovement();
                break;
            default:
                break;
        }
    }

    public void SetStartingLocation()
    {
        transform.position = GameUtils.Vector2IntToVector3(GameUtils.GetStartingGridPosition(piece));
    }
}
