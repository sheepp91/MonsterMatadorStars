using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public GameController gameController;
    private Transform player;
    public float speed;
    public Transform monsterStopAfterHitPosition;
    public Transform monsterStopAfterMissPosition;
    public float percentageOfJourney;
    public PowerBar powerBarScript;

    [HideInInspector]
    public bool hitPlayer = false;

    private Vector3 playerPos;
    private Vector3 initialMonsterPos;
    private float startTime;
    private float journeyLengthIfHit;
    private float journeyLengthIfMiss;
    private float distanceToPlayer;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = player.position;
        initialMonsterPos = transform.position;
        //finalPos = monsterStopPosition.position;
        startTime = Time.time;
        journeyLengthIfHit = Vector3.Distance(initialMonsterPos, monsterStopAfterHitPosition.position);
        journeyLengthIfMiss = Vector3.Distance(initialMonsterPos, monsterStopAfterMissPosition.position);
        distanceToPlayer = Vector3.Distance(initialMonsterPos, playerPos);
    }

    void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourneyIfHit = distCovered / journeyLengthIfHit;
        float fracJourneyIfMiss = distCovered / journeyLengthIfMiss;

        

        // Percentage between where monster is, and total distance between
        // where the monster started and where the player is.
        percentageOfJourney = distCovered / distanceToPlayer;

        // If percentage if journey reaches 100%, the monster hit the player
        if (percentageOfJourney >= 1.0f && powerBarScript.powerBarColor == PowerBar.E_COLOR.RED) {
            hitPlayer = true;
            transform.position = Vector3.Lerp(initialMonsterPos, monsterStopAfterHitPosition.position, fracJourneyIfHit);
            
        } else {
            // Monster will keep running off screen
            transform.position = Vector3.Lerp(initialMonsterPos, monsterStopAfterMissPosition.position, fracJourneyIfMiss);
        }


    }
}
