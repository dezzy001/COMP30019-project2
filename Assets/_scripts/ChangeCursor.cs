using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour {

	public Sprite cursorSprite;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void Start () {
		Cursor.SetCursor(cursorSprite.texture, hotSpot, cursorMode);
	}
	

}
