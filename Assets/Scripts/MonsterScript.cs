using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    public Transform player;
    public float speed;

    private Vector3 playerPos;
    private Vector3 initialMonsterPos;
    private float startTime;
    private float journeyLength;

    void Start () {
        playerPos = player.position;
        initialMonsterPos = transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(initialMonsterPos, playerPos);
    }
	
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(initialMonsterPos, playerPos, fracJourney);
    }
}
