using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    public float flyOffSpeed;

    private Transform currentMonster;
    private MonsterMove monsterMove;

    void Start() {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
    }

    void Update() {
        if (monsterMove.hitPlayer) {
            print("Player Got Hit!");
            Vector3 tempPos = transform.position;
            tempPos.x += flyOffSpeed;
            tempPos.y += flyOffSpeed;
            transform.position = tempPos;
        }
    }
}
