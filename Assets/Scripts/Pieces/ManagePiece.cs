using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePiece : MonoBehaviour
{
    #region Vars
    int myPieceColor = 0;
    int myPieceRank = 0;

    SpriteRenderer spriteRenderer;
    Material mat;
    Color originalMaterialColor;

    Vector2Int startingGridPosition;
    Vector2Int currentGridPosition;
    Vector2Int targetGridPosition;

    IChessPiece currentPieceInterface;

    bool onBoard = false;
    #endregion

    public void Init (int pieceColor, int pieceRank)
    {
        myPieceColor = pieceColor;
        myPieceRank = pieceRank;

        spriteRenderer.sprite = SpriteController.Instance.GetSprite(myPieceColor, myPieceRank);
        gameObject.tag = GameUtils.GetPieceColorText(myPieceColor);
        gameObject.name = GameUtils.GetPieceFullText(myPieceColor, myPieceRank);
        startingGridPosition = GameUtils.GetStartingGridPosition(myPieceColor, myPieceRank);
        GetInterface();
        Move(startingGridPosition);
    }

    public void GetInterface()
    {
        switch (myPieceRank)
        {
            case 0:
                currentPieceInterface = new PawnMovement();
                break;
            case 1:
                currentPieceInterface = new BishopMovement();
                break;
            case 2:
                currentPieceInterface = new KnightMovement();
                break;
            case 3:
                currentPieceInterface = new RookMovement();
                break;
            default:
                break;
        }
    }

    public int GetPieceColor() { return myPieceColor; }

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mat = GetComponent<SpriteRenderer>().material;
        originalMaterialColor = mat.color;
    }

    private void OnEnable()
    {
        GameController.OnNewGame += HandleNewGameEvent;
    }

    private void OnDisable()
    {
        GameController.OnNewGame -= HandleNewGameEvent;
    }
    #endregion  

    public void HandleNewGameEvent()
    {
        Move(startingGridPosition);
    }

    public void HandleClick(Vector2Int clickPos, ManagePiece targetPiece)
    {
        //move event
        Move(clickPos);
    }

    public void Move(Vector2Int newPos)
    {
        currentGridPosition = newPos;
        transform.position = GameUtils.ConvertGridPositionToVector3(currentGridPosition);
        spriteRenderer.sortingOrder = GameConstants.Total_Pieces - currentGridPosition.y;
        RemoveSelectedPieceHighlight();
    }

    public void HighlightSelectedPiece()
    {
        mat.color = GameConstants.HighlightPieceColor;
        //highlight valid places to move
    }

    public void RemoveSelectedPieceHighlight()
    {
        mat.color = originalMaterialColor;
    }
}
