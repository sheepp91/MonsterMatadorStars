using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    private Transform currentMonster;
    private MonsterMove monsterMove;

    void Start() {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
    }

    void Update() {
        if (currentMonster.GetComponent<MonsterMove>().hitPlayer) {
            print("Player Got Hit!");
        }
    }
}
