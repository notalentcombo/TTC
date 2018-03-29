using System.Collections.Generic;
using UnityEngine;

public class SpriteController : Singleton<SpriteController>
{
    #region Constructor
    protected SpriteController() { }
    #endregion

    #region Vars
    [SerializeField] private List<Sprite> whiteSprites;
    [SerializeField] private List<Sprite> blackSprites;
    #endregion

    #region Public Methods
    public Sprite GetSprite(Piece p)
    {
        var spriteColor = p.GetColor();
        int spriteDesc = (int)p.GetRank();

        if (spriteDesc < 0 || spriteDesc >= GameConstants.Total_Pieces)
            return null;
        else if (spriteColor == ChessPieceColor.WHITE)
            return whiteSprites[spriteDesc];
        else if (spriteColor == ChessPieceColor.BLACK)
            return blackSprites[spriteDesc];

        return null;
    }
    #endregion
}
