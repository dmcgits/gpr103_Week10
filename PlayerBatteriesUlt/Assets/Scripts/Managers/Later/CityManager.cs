using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum CityId
{
  CITY_1 = 0,
  CITY_2,
  CITY_3,
  CITY_4,
  CITY_5,
  CITY_6,

  CITY_COUNT
}

public class CityManager : MonoBehaviour
{
  protected City[] _cities;

  private void Awake()
  {
    // Find children with City components and sort them by id.
    _cities = GetComponentsInChildren<City>();
    _cities = _cities.OrderBy(city => city.Id).ToArray();

    // Listen out for destruction of city
    //AlienMissile.OnHitTarget += AlienMissile_OnHitTarget;
  }

  public City GetCityById( CityId id )
  {
    foreach (City city in _cities)
    {
      if ( id == city.Id ) return city;
    }
    return null;
  }

  private void AlienMissile_OnHitTarget() // {AlienMissile missile )
  {
    //City hitCity = GetCityById( missile.TargetCityId);
    //if (hitCity.Standing)
    //{
      // tell city fall down
      //hitCity.Explode(); 
      
      // make an explosion sprite also
      // Instantiate(ExplosionPrefab, hitCity.transform);
    //}
  }

  // City positions need to be located by the alien wave manager
  // so it can target.
  public Vector2 GetCityPosition( CityId id )
  {
    return (_cities[(int)id].transform.position);
  }
}
