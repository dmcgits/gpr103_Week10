using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBattery : MonoBehaviour {
  //public static event Action<PlayerMissile> OnMissileFired = delegate { };
  [SerializeField]
  protected PlayerMissile MissilePrefab;

  public static readonly int CAPACITY = 10;
  private bool _alive = true;
  private int _rounds = 0;
  private SpriteRenderer _spriteRenderer;
 
  private void Awake()
  {
    // Grab the sprite renderer from child object
    _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    _rounds = CAPACITY;
  }

  // use private variables to answer question "IsArmed()"
  public bool IsArmed()
  {
    return (_alive && _rounds > 0);
  }

  public PlayerMissile FireMissileAt( Vector2 target, Vector2 origin )
  {

    PlayerMissile missile = null; 
    if (_rounds > 0)    // Extra check.
    {
      missile = Instantiate(MissilePrefab);
      missile.AimAtTarget(target, origin);
      missile.Fire();
      //remove a round, update round graphic
      Rounds--;
    }
    return (missile);
  }

  private int Rounds
  {
    get { return _rounds; }
    set {
      // We have 0 to 10 missiles
      if (value >= 0 && value <= CAPACITY)
      {
        _rounds = value;
        if ( _rounds > 0 )
        {
          _spriteRenderer.enabled = true;
          // get a sprite from the atlas manager

          _spriteRenderer.sprite = SpriteAtlasManager.Instance.GetSprite(SpriteAtlasManager.BATTERY_ATLAS, _rounds);
        } else
        {
          _spriteRenderer.enabled = false;
        }

      }
    }
  }
	
  public void Reset()
  {
    // Fill up with ammo, new round
    return;
  }

}
