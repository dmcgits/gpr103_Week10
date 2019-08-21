using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MouseButtons
{
  LEFT = 0,
  RIGHT = 1,
  MIDDLE = 2,
  MOUSE1 = 0,
  MOUSE2 = 2,
  MOUSE3 = 1
}

public struct MouseClick
{
  public Vector3 worldPoint;
  public MouseButtons button;

  public MouseClick(Vector2 worldPoint, MouseButtons button)
  {
    this.worldPoint = worldPoint;
    this.button = button;
  }
}

public class InputManager : MonoBehaviour {
  public static event Action<MouseClick> OnMouseClicked = delegate { };
  
  protected bool _lastMouse1 = false;
  protected bool _lastMouse2 = false;
  protected bool _lastMouse3 = false;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    // Check for mouse input
    // Input.GetMouseButton((int) MouseButtons.MOUSE1);
    
    // Any mouse pressed
    if(Input.GetMouseButton(1) || Input.GetMouseButton(2) || Input.GetMouseButton(0))
    {
      if (Input.GetMouseButton((int)MouseButtons.MOUSE1) && !_lastMouse1)
      {
        //Debug.Log("left click.");
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        OnMouseClicked(new MouseClick(point, MouseButtons.MOUSE1));
      }

      if (Input.GetMouseButton((int)MouseButtons.MOUSE2) && !_lastMouse2)
      {
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        OnMouseClicked(new MouseClick(point, MouseButtons.MOUSE2));
      }

      if (Input.GetMouseButton((int)MouseButtons.MOUSE3) && !_lastMouse3)
      {
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        OnMouseClicked(new MouseClick(point, MouseButtons.MOUSE3));
      }
    }
    _lastMouse1 = Input.GetMouseButton((int)MouseButtons.MOUSE1);
    _lastMouse2 = Input.GetMouseButton((int)MouseButtons.MOUSE2);
    _lastMouse3 = Input.GetMouseButton((int)MouseButtons.MOUSE3);
  }
}
