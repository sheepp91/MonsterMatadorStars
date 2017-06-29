using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaiseFlag : MonoBehaviour {
    [HideInInspector]
    public bool raisedFlag = false;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown("space")) {
            print("Lift flag!");
            raisedFlag = true;
        }
	}
}
