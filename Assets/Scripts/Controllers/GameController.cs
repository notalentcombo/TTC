using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    protected GameController() {}

    #region Game Reset Handler
    public delegate void NewGame();
    public static event NewGame OnNewGame = delegate { };

    public void StartNewGame()
    {
        OnNewGame();
        print(string.Format("GC: OnNewGame triggered {0} event call(s)", OnNewGame.GetInvocationList().Length));

        ResetGame();
    }
    #endregion

    [SerializeField] ManagePiece chessPrefab;
    public IChessPiece[,] GameGrid;

    int totalMoves = 0;
    int currentPlayerTurn = GameConstants.White_Color;

    public int GetTotalMoves() { return totalMoves; }
    public int GetCurrentPlayerTurn() { return currentPlayerTurn; }

    public void EndCurrentPlayerTurn()
    {
        //if move made
        totalMoves++;
        currentPlayerTurn = (currentPlayerTurn == GameConstants.White_Color) ? GameConstants.Black_Color : GameConstants.White_Color;
    }


    #region UnityMethods
    public void Start()
    {
        SpawnPieces();
        ResetGame();
    }

    private void Update()
    {

        //testing stuff
        if (Input.GetButtonDown("Jump"))
            StartNewGame();
    }
    #endregion

    void SpawnPieces()
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

    void ResetGame()
    {
        GameGrid = new IChessPiece[GameConstants.X_Columns - 1, GameConstants.Y_Rows - 1];
        totalMoves = 0;
        currentPlayerTurn = 1;
    }
}
