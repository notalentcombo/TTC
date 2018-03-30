using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardCell
{
    #region Constructor
    public BoardCell(Vector2Int gridPos, Vector3Int realPos, Tilemap tilemap)
    {
        GridPosition = gridPos;
        RealPosition = realPos;
        tileMap = tilemap;
        tileMap.RemoveTileFlags(realPos, TileFlags.LockColor);
        IsHighlighted = false;
    }
    #endregion

    #region Vars
    public bool IsHighlighted { get; private set; }
    public Vector2Int GridPosition { get; private set; }
    public Vector3Int RealPosition { get; private set; }

    private Tilemap tileMap;
    #endregion

    #region Public Methods
    public void Highlight()
    {
        tileMap.SetColor(RealPosition, GameConstants.HighlightBoardCellColor);
        IsHighlighted = true;
    }

    public void RemoveHighlight()
    {
        tileMap.SetColor(RealPosition, GameConstants.DefaultColor);
        IsHighlighted = false;
    }
    #endregion

}

