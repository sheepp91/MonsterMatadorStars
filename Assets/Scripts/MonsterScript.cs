using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    public float speed;

	void Start () {
		
	}
	
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x += speed;
        this.transform.position = temp;
    }
}
