using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AlienBatteryId
{
  BATTERY_1 = 0,
  BATTERY_2,
  BATTERY_3,
  BATTERY_4,
  // etc
  // etc
  BATTERY_COUNT
}
public class AlienWaveManager : MonoBehaviour
{
  protected List<Vector2> _batteryLocations = new List<Vector2>();

  

  private void Awake()
  {
    Debug.Log("AlienWaveManager here.");
  }

  // Start is called before the first frame update
  void Start()
  {
    
  }

  private void AlienMissile_OnHitTarget( GameObject alienMissile )
  {
    
  }

  // A function to be called by the GameManager or LevelManager,
  // passing us a bunch of waves to launch
  public void LaunchWaves( GameObject[] waves )
  {
    // We control timing now, so call a coroutine to 
    // Launch delayed waves
    
  }

  // Make waves an array of AlienMissileWaves
  // Using GameObjects as a place holder
  private IEnumerator LaunchDelayedWaves ( GameObject[] waves )
  {
    // Step through each wave of missiles defined for this level
    foreach (var wave in waves)
    {
      // Wait for delay
      yield return new WaitForSeconds(1.0f);

      // launch missiles
      // for each missile launch spot and target city in list
        // Launch missile from spot to target
        Debug.Log("Pew!");
      
    }
  }

  // Fire the missile, returning.. a missile
  // Return an AlienMissile object we can track. Pass in an object with targeting info.
  protected GameObject FireAlienMissile(GameObject targetingInfo)
  {
    // get launch spot and target location, id from targetInfo
    // AlienMissile missile = get an alien missile instance
    // aim and fire
    return (new GameObject()); // return a real alienMissile

  }



}
