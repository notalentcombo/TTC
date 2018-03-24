using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    protected GameController() {}

    #region Game Reset Handler
    public delegate void NewGame();
    public static event NewGame StartNewGame;

    public void OnNewGame()
    {
        if (StartNewGame != null)
        {
            StartNewGame();
            print(string.Format("GC: OnNewGame triggered {0} event call(s)", StartNewGame.GetInvocationList().Length));
        }
    }
    #endregion

    [SerializeField] private List<Sprite> whiteSprites;
    [SerializeField] private List<Sprite> blackSprites;

    [SerializeField] GameObject chessPrefab;



    public void Start()
    {
        InitiallyPlacePieces();
    }

    void InitiallyPlacePieces()
    {
        for (int c = 0; c < GameConstants.Colors; c++)
        {
            int startingY = (c == 0) ? GameConstants.whiteStartingYRow : GameConstants.blackStartingYRow;
            string myColor = Enum.GetName(typeof(ChessPieceColor), c).ToString();

            for (int i = 0; i < GameConstants.Pieces; i++)
            {
                GameObject go = Instantiate(chessPrefab, new Vector3(i, startingY, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().sprite = GetSprite((ChessPieceColor)c, (ChessPieceDescription)i);
                go.name = myColor + " " + Enum.GetName(typeof(ChessPieceDescription), i).ToString();
            }
        }
    }

    Sprite GetSprite(ChessPieceColor _color, ChessPieceDescription _desc)
    {
        if (_color == ChessPieceColor.WHITE)
        {
            return whiteSprites[(int)_desc];
        }
        else if (_color == ChessPieceColor.BLACK)
        {
            return blackSprites[(int)_desc];
        }
        return null;
    }
}
