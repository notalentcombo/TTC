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
    public void ClearBoardHighlights()
    {
        foreach (var b in _board)
            b.RemoveHighlight();
    }

    public void HighlightBoardCell(int i)
    {
        if (i < _board.Length)
            _board[i].Highlight();
    }

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
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            HighlightRandom();
    }

    private void HighlightRandom()
    {
        ClearBoardHighlights();

        int max = _board.Length - 1;
        var rnd = new System.Random();
        HashSet<int> rndNums = new HashSet<int>();

        while (rndNums.Count < 4)
            rndNums.Add(rnd.Next(0, max));

        foreach (int r in rndNums)
            HighlightBoardCell(r);
        
        Debug.Log(Foo(GameController.Instance.CurrentPlayerTurn));
    }

    private bool Foo(ChessPieceColor colorCheck)
    {
        int checkAllCol = 
           (from BoardCell b in _board
            where b.IsHighlighted
            select b.GridPosition.x
           ).Distinct().Count();

        int checkAllRow = 
           (from BoardCell b in _board
            where b.IsHighlighted
            select b.GridPosition.y
           ).Distinct().Count();

        if ((checkAllCol == 4 && checkAllRow == 1) || (checkAllCol == 1 && checkAllRow == 4))
            return true;

        if (checkAllCol == 4 && checkAllRow == 4)
        {
            int checkBLtoTR =
               (from BoardCell b in _board
                where b.IsHighlighted
                   && b.GridPosition.y == b.GridPosition.x
                select b.GridPosition.y
               ).Distinct().Count();

            if (checkBLtoTR == 4) return true;

            int checkTLtoBR =
               (from BoardCell b in _board
                where b.IsHighlighted
                   && b.GridPosition.y == -b.GridPosition.x + 3
                select b.GridPosition.y
               ).Distinct().Count();

            if (checkTLtoBR == 4) return true;
        }

        return false;

    }
    #endregion

}
