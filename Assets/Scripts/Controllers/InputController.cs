using UnityEngine;

public class InputController : Singleton<InputController>
{
    protected InputController() { }

    #region Input Handler
    public delegate void ClickEvent(Vector3 clickPos);
    public static event ClickEvent OnClickEvent;

    public void ProcessClick(Vector3 clickPos)
    {
        if(OnClickEvent != null)
            OnClickEvent(clickPos);

        print(string.Format("GC: OnClickEvent triggered {0} event call(s)", OnClickEvent.GetInvocationList().Length));
    }
    #endregion

    #region Unity Methods
    void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
            ProcessClick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
    #endregion
}
