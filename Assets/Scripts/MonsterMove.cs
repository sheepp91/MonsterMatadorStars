using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {

    public GameController gameController;
    public Transform player;
    public float speed;
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
        playerPos = player.position;
        initialMonsterPos = transform.position;
        finalPos = playerPos;
        finalPos.x += 5;
        startTime = Time.time;
        journeyLength = Vector3.Distance(initialMonsterPos, finalPos);
        distanceToPlayer = Vector3.Distance(initialMonsterPos, playerPos);
    }

    void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(initialMonsterPos, finalPos, fracJourney);

        percentageOfJourney = distCovered / distanceToPlayer;

        if (percentageOfJourney > 1.0f) {
            hitPlayer = true;
        }
    }
}
