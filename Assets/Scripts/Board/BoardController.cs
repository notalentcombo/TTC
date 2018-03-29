using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class BoardController : Singleton<BoardController>
{
    #region Constructor
    protected BoardController() { }
    #endregion

    #region Vars
    [SerializeField] Tilemap _tm;
    BoardCell[] _board;
    Vector2Int _boardOffset;
    #endregion

    #region Public Methods
    public void HighlightBoardCell(int x, int y)
    {
        HighlightBoardCell(new Vector2Int(x, y));
    }

    public void HighlightBoardCell(Vector2Int targetPos)
    {
        _board[(targetPos.y * GameConstants.X_Columns) + targetPos.x].Highlight();
    }
    #endregion

    #region Private Methods
    private void InitBoard()
    {
        _board = new BoardCell[GameConstants.X_Columns * GameConstants.Y_Rows];
        for (int x = 0; x < GameConstants.X_Columns; x++)
        {
            for (int y = 0; y < GameConstants.Y_Rows; y++)
            {
                _board[y*GameConstants.X_Columns + x] = new BoardCell(new Vector2Int(x,y), OffsetBoardToTargetPosition(new Vector2Int(x, y)), _tm);
            }
        }
    }

    private void CalculateBoardOffset()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        _boardOffset = new Vector2Int(x, y);
    }

    Vector3Int OffsetBoardToTargetPosition (Vector2Int targetPos)
    {
        return GameUtils.Vector2IntToVector3Int(targetPos - _boardOffset);
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        CalculateBoardOffset();
        InitBoard();
        Foo();
    }

    private void Foo()
    {
        var q = (from BoardCell b in _board
                 where b.IsHighlighted == true
                 select b).Count();

        Debug.Log(q.ToString());

        HighlightBoardCell(0,1);
        HighlightBoardCell(0,2);
        HighlightBoardCell(0,3);
        HighlightBoardCell(0,0);
        HighlightBoardCell(1,1);
        HighlightBoardCell(2,2);
        HighlightBoardCell(3,3);

        q = (from BoardCell b 
             in _board
             where b.IsHighlighted == true
             select b).Count();

        Debug.Log(q.ToString());
    }
    #endregion

}
