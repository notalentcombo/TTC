using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePiece : MonoBehaviour
{
    int myPieceColor = 0;
    int myPieceDesc = 0;

    Sprite pieceSprite;

    GridPosition startingGridPosition;
    GridPosition currentGridPosition;
    bool onBoard = false;

    public void Init (int pieceColor, int pieceDesc)
    {
        myPieceColor = pieceColor;
        myPieceDesc = pieceDesc;

        //should only be run once when the pieces are spawned
        this.GetComponent<SpriteRenderer>().sprite = SpriteController.Instance.GetSprite(myPieceColor, myPieceDesc);
        this.gameObject.tag = GameConstants.GetPieceColorText(myPieceColor);
        this.gameObject.name = GameConstants.GetPieceFullText(myPieceColor, myPieceDesc);
        InitStartPosition();
    }

    public void ResetToStartingPosition()
    {
        onBoard = false;
        currentGridPosition = startingGridPosition;
        transform.position = new Vector3(currentGridPosition.X, currentGridPosition.Y, transform.position.z);
    }


    //TODO: in reality only the active piece needs to listen for subsequent mouse clicks
    public void ListenForMouseClick(GridPosition pos)
    {
        if (pos.Equals(currentGridPosition))
            Debug.Log(this.name + " was clicked.");
    }

    #region Unity Methods
    private void OnEnable()
    {
        GameController.OnNewGame += ResetToStartingPosition;
        InputController.OnBroadcastMouseClick += ListenForMouseClick;
    }

    private void OnDisable()
    {
        GameController.OnNewGame -= ResetToStartingPosition;
        InputController.OnBroadcastMouseClick -= ListenForMouseClick;
    }

    #endregion  

    private void InitStartPosition()
    {
        int startingY = (myPieceColor == 0) ? GameConstants.White_StartingY_Row : GameConstants.Black_StartingY_Row;

        startingGridPosition.X = myPieceDesc;
        startingGridPosition.Y = startingY;
        ResetToStartingPosition();
    }
}
