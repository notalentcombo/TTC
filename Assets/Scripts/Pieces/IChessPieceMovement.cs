using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChessPieceMovement
{
    bool ValidateMove(Vector2Int newPosition);
    List<Vector2Int> GetValidPositions();
}
