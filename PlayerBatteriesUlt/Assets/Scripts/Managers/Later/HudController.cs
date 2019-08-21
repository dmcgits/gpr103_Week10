using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
  [SerializeField]
  private GameObject _cursor = null;
  private SpriteRenderer _cursorSpriteRenderer = null;

  public Texture2D cursorTexture = null;
  // control what cursor is shown
  // show and hide various elements depending on game level state
  

  // Start is called before the first frame update
  void Start()
  {
    Cursor.visible = false;
    
    _cursorSpriteRenderer = _cursor.GetComponent<SpriteRenderer>();      
  }

  // Update is called once per frame
  void Update()
  {
    // Turn off vsync in your graphics quality settings or the cursor lags badly
    _cursor.transform.position = Handies.MousePosToWorldVec();

  }
  
}
