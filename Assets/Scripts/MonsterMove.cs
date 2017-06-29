using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public GameController gameController;
    private Transform player;
    public float speed;
    public Transform monsterStopPosition;
    public float percentageOfJourney;

    [HideInInspector]
    public bool hitPlayer = false;

    private Vector3 playerPos;
    private Vector3 initialMonsterPos;
    private Vector3 finalPos;
    private float startTime;
    private float journeyLength;
    private float distanceToPlayer;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = player.position;
        initialMonsterPos = transform.position;
        finalPos = monsterStopPosition.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(initialMonsterPos, finalPos);
        distanceToPlayer = Vector3.Distance(initialMonsterPos, playerPos);
    }

    void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        // Monster will keep running off screen
        transform.position = Vector3.Lerp(initialMonsterPos, finalPos, fracJourney);

        // Percentage between where monster is, and total distance between
        // where the monster started and where the player is.
        percentageOfJourney = distCovered / distanceToPlayer;

        // If percentage if journey reaches 100%, the monster hit the player
        if (percentageOfJourney > 1.0f) {
            hitPlayer = true;
        }
    }
}
