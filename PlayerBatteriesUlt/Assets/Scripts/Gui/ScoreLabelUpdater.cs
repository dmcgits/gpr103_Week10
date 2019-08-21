using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreLabelUpdater : MonoBehaviour {

  protected TMP_Text _textMesh;

  private void Awake()
  {
    _textMesh = GetComponent<TMP_Text>();
    //_textMesh.autoSizeTextContainer = true;
    //_textMesh.SetText("WORKS");

    // Listen for score changes
    ScoreManager.OnScoreChanged += ScoreChangeHandler;
  }
  // Use this for initialization
  void Start () {
    
	}

  void ScoreChangeHandler(int score)
  {
    _textMesh.SetText( score.ToString() );
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
