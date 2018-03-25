using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputController : Singleton<InputController>
{
    protected InputController() { }

    #region Broadcast Mouse Click Events
    public delegate void BroadcastMouseClick(GridPosition clickPos);
    public static event BroadcastMouseClick OnBroadcastMouseClick = delegate { };

    public void MouseClick(GridPosition pos)
    {
        OnBroadcastMouseClick(pos);
        print(string.Format("IC: OnMouseClick triggered {0} event call(s)", OnBroadcastMouseClick.GetInvocationList().Length));
    }

    #endregion

    #region Unity Methods
    void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.CeilToInt(pos.x) - 1;
            int y = Mathf.CeilToInt(pos.y) - 1;
            MouseClick(new GridPosition(x,y));
        }
	}
    #endregion
}
