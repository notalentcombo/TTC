using System.Collections.Generic;
using UnityEngine;

public class SpriteController : Singleton<SpriteController>
{
    protected SpriteController() { }

    #region Vars
    [SerializeField] private List<Sprite> whiteSprites;
    [SerializeField] private List<Sprite> blackSprites;
    #endregion

    public Sprite GetSprite(int spriteColor, int spriteDesc)
    {
        if (spriteDesc < 0 || spriteDesc >= GameConstants.Total_Pieces)
            return null;
        else if (spriteColor == GameConstants.White_Color)
            return whiteSprites[spriteDesc];
        else if (spriteColor == GameConstants.Black_Color)
            return blackSprites[spriteDesc];

        return null;
    }
}
