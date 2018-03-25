using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    protected GameController() {}

    #region Game Reset Handler
    public delegate void NewGame();
    public static event NewGame OnNewGame;

    public void StartNewGame()
    {
        if (OnNewGame != null)
            OnNewGame();

        print(string.Format("GC: OnNewGame triggered {0} event call(s)", OnNewGame.GetInvocationList().Length));

        ResetGame();
    }
    #endregion

    #region Vars
    [SerializeField] private ManagePiece chessPrefab;
    private ManagePiece currentSelectedPiece;

    public IChessPiece[,] GameGrid;

    private int totalMoves = 0;
    private int currentPlayerTurn = GameConstants.White_Color;
    #endregion

    public int GetTotalMoves() { return totalMoves; }
    public int GetCurrentPlayerTurn() { return currentPlayerTurn; }

    public void EndCurrentPlayerTurn()
    {
        //check for game over
        totalMoves++;
        currentPlayerTurn = (currentPlayerTurn == GameConstants.White_Color) ? GameConstants.Black_Color : GameConstants.White_Color;
    }

    #region UnityMethods
    public void Start()
    {
        ResetGame();
        SpawnPieces();
    }

    private void Update()
    {
        //testing stuff
        if (Input.GetButtonDown("Jump"))
            StartNewGame();
    }

    private void OnEnable()
    {
        InputController.OnClickEvent += HandleClickEvent;
    }

    private void OnDisable()
    {
        InputController.OnClickEvent -= HandleClickEvent;
    }
    #endregion

    private void HandleClickEvent(Vector3 clickPos)
    {
        var hit = Physics2D.Raycast(clickPos, Vector2.zero);
        ManagePiece hitMP = null;

        if (hit.collider != null)
            hitMP = hit.collider.GetComponent<ManagePiece>();

        //hit a current player piece so we are either selecting or deselecting
        if (hitMP != null && hitMP.GetPieceColor() == GetCurrentPlayerTurn())
        {
            HandleCurrentPlayerPieceSelection(hitMP);
            return;
        }

        //let the player know they need to sort a piece move
        if (currentSelectedPiece)
        {
            currentSelectedPiece.HandleClick(GameUtils.ConvertVector3ToGridPosition(clickPos), hitMP);
            currentSelectedPiece = null;
        }

    }

    #region Piece Selection Logic
    private void HandleCurrentPlayerPieceSelection(ManagePiece hitMP)
    {
        if (currentSelectedPiece == null || currentSelectedPiece != hitMP)
            SelectPiece(hitMP);
        else if (currentSelectedPiece == hitMP)
            ClearSelectedPiece();
    }

    private void SelectPiece(ManagePiece mp)
    {
        ClearSelectedPiece();
        currentSelectedPiece = mp;
        currentSelectedPiece.HighlightSelectedPiece();
    }

    private void ClearSelectedPiece()
    {
        if (currentSelectedPiece != null)
        {
            currentSelectedPiece.RemoveSelectedPieceHighlight();
            currentSelectedPiece = null;
        }
    }
    #endregion

    private void SpawnPieces()
    {
        for (int c = 0; c < GameConstants.Total_Colors; c++)
        {
            int startingY = (c == 0) ? GameConstants.White_StartingY_Row : GameConstants.Black_StartingY_Row;

            for (int i = 0; i < GameConstants.Total_Pieces; i++)
            {
                var go = Instantiate(chessPrefab, new Vector3(i, startingY, 0), Quaternion.identity);
                go.Init(c, i);
            }
        }
    }

    private void ResetGame()
    {
        GameGrid = new IChessPiece[GameConstants.X_Columns - 1, GameConstants.Y_Rows - 1];
        totalMoves = 0;
        currentPlayerTurn = GameConstants.White_Color;
        ClearSelectedPiece();
    }


}
