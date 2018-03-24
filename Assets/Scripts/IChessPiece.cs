using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChessPiece
{
    GridPosition GetCurrentPosition();
    ChessPieceColor GetColor();
    ChessPieceDescription GetDescription();
    void ValidateMove(GridPosition newPosition);
    void Move(GridPosition newPosition);
    List<GridPosition> GetValidPositions();
    void ResetToStartingPosition();
}
