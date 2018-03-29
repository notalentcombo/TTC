using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    #region Constructor
    protected GameController() {}
    #endregion

    #region Vars
    public ChessPieceColor CurrentPlayerTurn { get; private set; }
    public int TotalMoves { get; private set; }

    [SerializeField] private ManagePiece chessPrefab;
    private ManagePiece currentSelectedPiece;

    private IChessPieceMovement[,] GameGrid;
    #endregion

    #region Events
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

    #region Subscribe
    private void OnEnable()
    {
        InputController.OnClickEvent += HandleClickEvent;
    }

    private void OnDisable()
    {
        InputController.OnClickEvent -= HandleClickEvent;
    }

    private void HandleClickEvent(Vector3 clickPos)
    {
        var hit = Physics2D.Raycast(clickPos, Vector2.zero);
        ManagePiece hitMP = null;

        if (hit.collider != null)
            hitMP = hit.collider.GetComponent<ManagePiece>();

        //hit a current player piece so we are either selecting or deselecting
        if (hitMP != null && hitMP.GetPieceColor() == CurrentPlayerTurn)
        {
            HandleCurrentPlayerPieceSelection(hitMP);
            return;
        }

        //let the player know they need to sort a piece move
        if (currentSelectedPiece)
        {
            currentSelectedPiece.HandleClick(GameUtils.Vector3ToVector2Int(clickPos), hitMP);
            currentSelectedPiece = null;
        }
    }
    #endregion

    #region Public Methods
    public void EndCurrentPlayerTurn()
    {
        //check for game over
        TotalMoves++;
        CurrentPlayerTurn = (CurrentPlayerTurn == ChessPieceColor.WHITE) ? ChessPieceColor.BLACK : ChessPieceColor.WHITE;
    }
    #endregion

    #region PrivateMethods
    private void ResetGame()
    {
        GameGrid = new IChessPieceMovement[GameConstants.X_Columns - 1, GameConstants.Y_Rows - 1];
        TotalMoves = 0;
        CurrentPlayerTurn = ChessPieceColor.WHITE;
        ClearSelectedPiece();
    }

    private void SpawnPieces()
    {
        for (int c = 0; c < GameConstants.Total_Colors; c++)
        {
            for (int r = 0; r < GameConstants.Total_Pieces; r++)
            {
                var go = Instantiate(chessPrefab);
                go.Init((ChessPieceColor)c, (ChessPieceRank)r);
            }
        }
    }

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
        currentSelectedPiece.gfx.Select();
    }

    private void ClearSelectedPiece()
    {
        if (currentSelectedPiece != null)
        {
            currentSelectedPiece.gfx.Deselect();
            currentSelectedPiece = null;
        }
    }
    #endregion

    #region Unity Methods
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
    #endregion

}
