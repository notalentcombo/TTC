using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManagePieceGFX))]
[RequireComponent(typeof(ManagePieceMovement))]
public class ManagePiece : MonoBehaviour
{
    #region Constructor
    public void Init (ChessPieceColor pieceColor, ChessPieceRank pieceRank)
    {
        piece = new Piece(pieceColor, pieceRank);

        startingGridPosition = GameUtils.GetStartingGridPosition(piece);
        gfx.Init(piece);
        move.Init(piece);
        Move(startingGridPosition);
    }
    #endregion

    #region Vars
    public Piece piece;
    public ManagePieceGFX gfx;
    public ManagePieceMovement move;

    Vector2Int startingGridPosition;
    Vector2Int currentGridPosition;
    Vector2Int targetGridPosition;

    bool onBoard = false;
    #endregion

    public ChessPieceColor GetPieceColor() { return piece.GetColor(); }

    public void HandleNewGameEvent()
    {
        Move(startingGridPosition);
    }

    public void HandleClick(Vector2Int clickPos, ManagePiece targetPiece)
    {
        //move event
        Move(clickPos);
    }

    public void Move(Vector2Int newPos)
    {
        currentGridPosition = newPos;
        transform.position = GameUtils.Vector2IntToVector3(currentGridPosition);
        gfx.SetSortOrder(GameConstants.Total_Pieces - currentGridPosition.y);
        gfx.Deselect();
    }

    #region Unity Methods
    private void Awake()
    {
        gfx = GetComponent<ManagePieceGFX>();
        move = GetComponent<ManagePieceMovement>();
    }

    private void OnEnable()
    {
        GameController.OnNewGame += HandleNewGameEvent;
    }

    private void OnDisable()
    {
        GameController.OnNewGame -= HandleNewGameEvent;
    }
    #endregion  



}
