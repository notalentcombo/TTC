using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    #region Constructor
    public Piece(ChessPieceColor c, ChessPieceRank r)
    {
        _color = c;
        _rank = r;
    }
    #endregion

    #region Vars
    ChessPieceColor _color;
    ChessPieceRank _rank;
    #endregion

    #region Public Methods
    public ChessPieceColor GetColor() { return _color; }
    public ChessPieceRank GetRank() { return _rank; }
    #endregion
}