using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ClickToPlaySound : MonoBehaviour
{
  [SerializeField]
  AudioMixer pitchShifter = null;

  AudioSource source;

  int clickCount = -1;

  private void Awake()
  {
    source = gameObject.GetComponent<AudioSource>();
    
  }
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnMouseUpAsButton()
  {
    clickCount = (clickCount+1 > 2) ? 0 : clickCount + 1;
    Debug.Log("trying to move sounds to pitch_" + clickCount);
    source.outputAudioMixerGroup = pitchShifter.FindMatchingGroups("pitch_" + clickCount)[0];
    Debug.Log("Playing Sound");
    source.Play();

  }
}
