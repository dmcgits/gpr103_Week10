using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraShake : MonoBehaviour
{
  [Tooltip("Maximum stress the effect can inflict upon objects Range([0,1])")]
  [SerializeField]
  protected float _shakeStress = 0.3f;

  GameObject[] targets;

  private void Start()
  {
    targets = UnityEngine.Object.FindObjectsOfType<GameObject>();
  }

  public void ShakeCamera()
  {
      var receiver = Camera.main.GetComponent<StressReceiver>();
      receiver.InduceStress(_shakeStress);
    
  }
}
