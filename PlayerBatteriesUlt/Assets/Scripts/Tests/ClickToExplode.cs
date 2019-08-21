using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToExplode : MonoBehaviour
{
  [Tooltip("Maximum stress the effect can inflict upon objects Range([0,1])")]
  public float MaximumStress = 0.6f;
  [Tooltip("Maximum distance in which objects are affected by this TraumaInducer")]
  public float Range = 45;

  GameObject[] targets;

  private void Start()
  {
    targets = UnityEngine.Object.FindObjectsOfType<GameObject>();
  }

  private void OnMouseUpAsButton()
  {
    Explode();
  }

  private void Explode()
  {
    for (int i = 0; i < targets.Length; ++i)
    {
      var receiver = targets[i].GetComponent<StressReceiver>();
      if (receiver == null) continue;
      float distance = Vector3.Distance(transform.position, targets[i].transform.position);
      /* Apply stress to the object, adjusted for the distance */
      if (distance > Range) continue;
      float distance01 = Mathf.Clamp01(distance / Range);
      float stress = (1 - Mathf.Pow(distance01, 2)) * MaximumStress;
      receiver.InduceStress(stress);
    }
  }
}
