using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMissile : MonoBehaviour {

  public static event Action<PlayerMissile> OnHitTarget = delegate { };

  [SerializeField]
  protected float _speed = 4.0f; // 0.1 units per frame

  protected bool _fired = false;
  protected Vector3 _target;
 
  public void AimAtTarget( Vector2 target, Vector2 origin )
  {
    // keep a copy of the target location and origin/launch location. 
    _target = target;
    transform.position = origin;  // Move to launch pos.

    transform.rotation = Handies.GetLocalAngleBetweenVectors2((Vector2)origin, target);
  }

  public void Fire()
  {
    _fired = true;
	}
  
  void Update () {
    if (_fired)
    {
			// Move upwards a bit. Casting the Vector2 to Vector3 adds z (=0) to make transform.position happy.
  		transform.position += transform.right * 0.05f;

      // Hit a thing?
      // Announce target hit.?
      // OnHitTarget(this);
    }
  }

  protected Vector3 Target
  {
    get
    {
      return _target;
    }

    set
    {
      _target = value;
    }
  }


}
