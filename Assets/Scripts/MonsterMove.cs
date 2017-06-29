using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMove : MonoBehaviour {

    public GameController gameController;
    private Transform player;
    public float speed, levelSpeedAlteration;
    public Transform monsterStopAfterHitPosition;
    public Transform monsterStopAfterMissPosition;
    public float percentageOfJourney;
    public Transform powerBar;
    public float endGameTimer = 3f;

    [HideInInspector]
    public bool hitPlayer = false;
    [HideInInspector]
    public bool makeNewMonster = false;
    [HideInInspector]
    public int currentLevel;

    private PowerBar powerBarScript;
    private Vector3 playerPos;
    private Vector3 initialMonsterPos;
    private float startTime;
    private float journeyLengthIfHit;
    private float journeyLengthIfMiss;
    private float distanceToPlayer;
    private float timer;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        monsterStopAfterMissPosition = GameObject.FindGameObjectWithTag("MonsterStopAfterMiss").transform;
        monsterStopAfterHitPosition = GameObject.FindGameObjectWithTag("MonsterStopAfterHit").transform;
        powerBar = GameObject.FindGameObjectWithTag("PowerBar").transform;
        playerPos = player.position;
        initialMonsterPos = transform.position;
        //finalPos = monsterStopPosition.position;
        startTime = Time.time;
        journeyLengthIfHit = Vector3.Distance(initialMonsterPos, monsterStopAfterHitPosition.position);
        journeyLengthIfMiss = Vector3.Distance(initialMonsterPos, monsterStopAfterMissPosition.position);
        distanceToPlayer = Vector3.Distance(initialMonsterPos, playerPos);
        powerBarScript = powerBar.GetComponent <PowerBar>();
    }

    void Update() {
        float distCovered = (Time.time - startTime) * (speed + (currentLevel * levelSpeedAlteration));
        float fracJourneyIfHit = distCovered / journeyLengthIfHit;
        float fracJourneyIfMiss = distCovered / journeyLengthIfMiss;

        // Percentage between where monster is, and total distance between
        // where the monster started and where the player is.
        percentageOfJourney = distCovered / distanceToPlayer;

        // If percentage if journey reaches 100%, the monster hit the player
        if (percentageOfJourney >= 1.0f && powerBarScript.powerBarColor == PowerBar.E_COLOR.RED) {
            hitPlayer = true;
            transform.position = Vector3.Lerp(initialMonsterPos, monsterStopAfterHitPosition.position, fracJourneyIfHit);

            if (transform.position.x == monsterStopAfterHitPosition.position.x) {
                timer += Time.deltaTime;
                if (timer >= endGameTimer) {
                    print("Press space to restart game");
                    if (Input.GetKeyDown("space")) {
                        SceneManager.LoadScene("Scene1");
                    }
                }
            }

        } else {
            // Monster will keep running off screen
            transform.position = Vector3.Lerp(initialMonsterPos, monsterStopAfterMissPosition.position, fracJourneyIfMiss);

            if (transform.position.x == monsterStopAfterMissPosition.position.x) {
                makeNewMonster = true;
            }
        }
    }
}
