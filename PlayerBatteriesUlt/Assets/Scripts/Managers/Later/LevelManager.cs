using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState
{
  MAIN_SCREEN,
  WAVES_LAUNCHING,
  WAVES_LAUNCHED,
  END_LEVEL_SCORING,
  END_GAME,
  PAUSED,
  
  STATECOUNT
}

public class LevelManager : MonoBehaviour
{
  private AlienWaveManager _waveManager;


  private static LevelManager _instance;

  private LevelState _state;

  public static LevelManager Instance
  {
    get
    {
      return _instance;
    }
    private set
    {
      _instance = value;
    }
  }

  void Awake()
  {


    // If this is the first class instance, burrow into static instance
    if (Instance == null)
    {
      Instance = this;
    }
    // If not, self-destruct because that static position has been filled.
    else if (Instance != this)
    {
      Destroy(gameObject);
    }

    _state = LevelState.MAIN_SCREEN;
    //_atlasses[BATTERY_ATLAS] = _batteryAtlas;
    //Sets this one to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
    
  }

  // Start is called before the first frame update
  void Start()
  {
    _waveManager = GameObject.FindObjectOfType<AlienWaveManager>();

    _state = LevelState.WAVES_LAUNCHING;

    // Get the next level's info from somewhere. A function, another class? JSON?
    GameObject[] level = { new GameObject(), new GameObject() };

    // Ask wavemanager to start launching (waves)
    _waveManager.LaunchWaves(level);

  }

  public LevelState State
  {
    get { return _state; }
  }

 
}
