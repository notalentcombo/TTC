using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChessPiece
{
    GridPosition GetCurrentPosition();
    int GetColor();
    int GetDescription();
    void ValidateMove(GridPosition newPosition);
    void Move(GridPosition newPosition);
    List<GridPosition> GetValidPositions();
    void ResetToStartingPosition();
}
