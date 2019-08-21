using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CityStatus
{
  STANDING,
  EXPLODING,
  CRATER
}

public class City : MonoBehaviour
{
  [SerializeField]
  protected CityId _id;
  // Start is called before the first frame update

  protected CityStatus _status = CityStatus.STANDING;

  private void Awake()
  {
   
  }

  public CityId Id
  {
    get { return _id; }
  }

  public void Explode()
  {
  }

  public void Unexplode()
  { 

  }

}
