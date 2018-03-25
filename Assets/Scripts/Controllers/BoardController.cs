using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardController : Singleton<BoardController>
{ 
    protected BoardController() { }

    Tilemap playSpace;
    Tile [,] boardTiles;
    TileData td;
    Color oc;

    // Use this for initialization
    private void Awake()
    {
        playSpace = GetComponent<Tilemap>();
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            Foo();
	}

    void Foo()
    {
        //playSpace.SetTileFlags(new Vector2Int(0, 0), TileFlags.None);
        HighlightBoardCell(new Vector2Int(0, 0));

        //playSpace.SetColor(new Vector3Int(0, 0, 0), Color.black);

        //playSpace.color = Color.blue;
        //playSpace.GetTile(new Vector3Int(0, 0, 0)).GetTileData(new Vector3Int(0, 0, 0), playSpace, ref td);
        //td.color = Color.red;
    }

    public void HighlightBoardCell(Vector2Int targetPos)
    {
        var t = OffsetVector2IntTargetPos(targetPos);

        playSpace.RemoveTileFlags(t, TileFlags.LockColor);
        playSpace.SetColor(t, GameConstants.HighlightBoardCellColor);
    }

    Vector3Int OffsetVector2IntTargetPos (Vector2Int targetPos)
    {
        return new Vector3Int(targetPos.x - 2, targetPos.y - 2, 0);
    }
}
