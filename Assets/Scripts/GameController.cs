using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int currentLevel = 1;

	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetKeyDown("r")) {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
