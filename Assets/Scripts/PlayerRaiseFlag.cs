using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaiseFlag : MonoBehaviour {
    [HideInInspector]
    public bool raisedFlag = false;

    private MonsterMove monsterMove;
    private Transform currentMonster;

    void Start () {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
    }
	
	void Update () {
		if (Input.GetKeyDown("space") && !monsterMove.hitPlayer) {
            print("Lift flag!");
            print(monsterMove.percentageOfJourney);
            raisedFlag = true;
        }
	}
}
