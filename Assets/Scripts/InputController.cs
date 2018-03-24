using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputController : Singleton<InputController>
{
    protected InputController() { }

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 tilePos = new Vector2((int)pos.x, (int)pos.y);
            Debug.Log(tilePos.ToString());
        }
	}
}
