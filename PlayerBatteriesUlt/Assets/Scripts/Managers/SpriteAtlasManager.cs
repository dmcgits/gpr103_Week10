using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteAtlasManager : MonoBehaviour {

  public static readonly int BATTERY_ATLAS = 0;
  public static readonly int HUD_ATLAS = 1;

  [SerializeField]
  private SpriteAtlas _batteryAtlas = null;
  [SerializeField]
  private SpriteAtlas _hudAtlas = null;
  private List<SpriteAtlas> _atlasses = null;

  // static variable of own type: the parasite that will enforce the Singleton pattern
  private static SpriteAtlasManager _instance;

  public static SpriteAtlasManager Instance
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
    _atlasses = new List<SpriteAtlas>() { _batteryAtlas, _hudAtlas };
    //_atlasses[BATTERY_ATLAS] = _batteryAtlas;
    //Sets this one to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
  }

  public int NumberOfSprites( string name )
  {
    int numSpritesFound = 0;
    bool spriteWasFound = true;
    Sprite spriteFromAtlas = null;

    while( spriteWasFound )
    {
      // We'll check for _1 first.
      spriteFromAtlas = _batteryAtlas.GetSprite(name + "_" + (numSpritesFound+1));
      
      if (spriteFromAtlas == null)  // if nothing came from atlas
      {
        spriteWasFound = false;
      } else { 
        numSpritesFound += 1;
      }
    }
    return (numSpritesFound);
  }

  public Sprite GetSprite( int atlasId, int imageId )
  {
    string imagePrefix = "";
    switch (atlasId)
    {
      // FIX THIS .. it couldn't handle using BATTERY_ATLAS because expected const?
      case 0:
        imagePrefix = "battery_";
        break;
    }
    Sprite spriteFromAtlas = _atlasses[atlasId].GetSprite(imagePrefix + imageId);

    return (spriteFromAtlas);
  }

  public Sprite GetSpriteByName(int atlasId, string imageName)
  {
    Sprite spriteFromAtlas = _atlasses[atlasId].GetSprite(imageName);

    return (spriteFromAtlas);
  }
}
