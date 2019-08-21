using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour {

  public static event Action<int> OnScoreChanged = delegate { };

  private int _score = 0;

  //protected int Score { get => _score; set => _score = value; }

  
  void Start () {
    // For testing purposes, let's make up a score and declare it to anyone listening.
    _score = 333333;
    OnScoreChanged(_score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
