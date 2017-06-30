using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    public float flyOffSpeed;
    public float flyOffSpinSpeed;

    [HideInInspector]
    public MonsterMove monsterMove;
    [HideInInspector]
    public Transform currentMonster;
    public Transform cam;
    AudioSource fail;

    void Start() {

        fail = GetComponent<AudioSource>();
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
    }

    void Update() {
        if (monsterMove.hitPlayer) {
           // fail.Play();
            Debug.Log(fail.isPlaying);
            Vector3 tempPos = transform.position;
            tempPos.x += flyOffSpeed;
            tempPos.y += flyOffSpeed;
            transform.position = tempPos;

            Vector3 tempRot = transform.rotation.eulerAngles;
            tempRot.z -= flyOffSpinSpeed;
            transform.rotation = Quaternion.Euler(tempRot);
        }
    }
}
