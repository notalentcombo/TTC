using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardCell
{
    #region Constructor
    public BoardCell(Vector2Int gridPos, Vector3Int realPos, Tilemap tilemap)
    {
        gridPosition = gridPos;
        realPosition = realPos;
        tileMap = tilemap;
        tileMap.RemoveTileFlags(realPos, TileFlags.LockColor);
        IsHighlighted = false;
    }
    #endregion

    #region Vars
    public bool IsHighlighted { get; private set; }

    Vector2Int gridPosition;
    Vector3Int realPosition;
    Tilemap tileMap;
    #endregion

    #region Public Methods
    public void Highlight()
    {
        tileMap.SetColor(realPosition, GameConstants.HighlightBoardCellColor);
        IsHighlighted = true;
    }

    public void RemoveHighlight()
    {
        tileMap.SetColor(realPosition, GameConstants.DefaultColor);
        IsHighlighted = false;
    }
    #endregion

}

