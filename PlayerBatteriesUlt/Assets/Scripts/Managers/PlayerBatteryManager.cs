using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PlayerBatteryId
{
  BATTERY_1 = 0,
  BATTERY_2,
  BATTERY_3,
  BATTERY_COUNT,

  BATTERY_LEFT = BATTERY_1,
  BATTERY_MIDDLE = BATTERY_2,
  BATTERY_RIGHT = BATTERY_3,
  BATTERY_NONE = -1
}

// Listens for events for all 3 batteries, tracks information about them,
// releases info to querying clients like say AlienWaveManager
public class PlayerBatteryManager : MonoBehaviour
{
  private PlayerBattery[] _batteries;
  private List<PlayerMissile> _missilesAloft;
  // add list of active explosions

  private void Awake()
  {
    // create list to track all airborn player missiles
    _missilesAloft = new List<PlayerMissile>();
    
    // When missiles hit targets we can remove from aloft list
    PlayerMissile.OnHitTarget += PlayerMissile_OnHitTarget;
    
  }
 
  // Start is called before the first frame update
  void Start()
  {
    _batteries = GameObject.FindObjectsOfType<PlayerBattery>(); // Look for batterys in world

    // For later, this is the code to both get and sort them at once.
    //_batteries = GameObject.FindObjectsOfType<PlayerBattery>().OrderBy(go=>go.name).ToArray<PlayerBattery>();
    InputManager.OnMouseClicked += MouseClickHandler; // Listen for input

  }

  void MouseClickHandler( MouseClick click )
  {
    // Choose the appropriate battery to fire by mouseClick.
    // No doubt whatsoever this could be reduced to 1 or 2 lines.
    PlayerBatteryId batteryId = PlayerBatteryId.BATTERY_NONE;
    //Debug.Log("PlayerBatteryManager got a click: " + click.button);
	
    switch (click.button)
    {
      case MouseButtons.LEFT:
        batteryId = PlayerBatteryId.BATTERY_LEFT;
        break;
      case MouseButtons.MIDDLE:
        batteryId = PlayerBatteryId.BATTERY_MIDDLE;
        break;
      case MouseButtons.RIGHT:
        batteryId = PlayerBatteryId.BATTERY_RIGHT;
        break;
    }
    // Now pass the info on for firing and tracking
    FireMissileAndTrack(batteryId, click.worldPoint);
  }

  // Order the battery to fire, keep missile in _missilesAloft
  // so we can pause or eliminate at end of game.
  void FireMissileAndTrack(PlayerBatteryId batteryId, Vector2 target)
  {
    PlayerBattery battery = _batteries[(int)batteryId];

	// Fire at target point from battery location.
	PlayerMissile missile = battery.FireMissileAt(target, battery.gameObject.transform.position);

    // keep track of all Player Missiles in the air in case we need to pause, destroy, or just count them.
    if (missile != null) _missilesAloft.Add(missile);
  }

  private void PlayerMissile_OnHitTarget( PlayerMissile missile )
  {
    // Make an explosion
    // Announce hit?
    // Go away
    _missilesAloft.Remove(missile);
  }

  public int MissileCount
  {
    get { return _missilesAloft.Count; }
  }

  public int BatteryCount
  {
    get { return _batteries.Length; }
  }

}
