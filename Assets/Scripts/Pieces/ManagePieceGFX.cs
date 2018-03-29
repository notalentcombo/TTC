using UnityEngine;

public class ManagePieceGFX : MonoBehaviour
{
    #region Constructor
    public void Init (Piece p)
    {
        piece = p;
        SetSprite();
        SetGameObject();
    }
    #endregion

    #region Vars
    Piece piece;
    SpriteRenderer spriteRenderer;
    Material mat;
    Color originalMaterialColor;
    #endregion

    #region Public Methods
    public void SetSortOrder(int order)
    {
        spriteRenderer.sortingOrder = order;
    }

    public void Select()
    {
        mat.color = GameConstants.HighlightPieceColor;
    }

    public void Deselect()
    {
        mat.color = originalMaterialColor;
    }
    #endregion

    #region Private Methods
    private void SetSprite()
    {
        spriteRenderer.sprite = SpriteController.Instance.GetSprite(piece);
    }

    private void SetGameObject()
    {
        gameObject.tag = GameUtils.GetPieceColorText(piece.GetColor());
        gameObject.name = GameUtils.GetPieceFullText(piece);
    }
    #endregion
    
    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mat = GetComponent<SpriteRenderer>().material;
        originalMaterialColor = mat.color;
    }
    #endregion
}
