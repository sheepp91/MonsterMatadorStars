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
    public Transform sounds;
    public Transform powerBar;
    public float percentageOfJourney;
    public float endGameTimer = 3f;
    public bool start;
    [HideInInspector]
    public bool hitPlayer = false;
    [HideInInspector]
    public bool makeNewMonster = false;
    [HideInInspector]
    public int currentLevel;

    private PlaySounds playSoundsScript;
    private PowerBar powerBarScript;
    private Vector3 playerPos;
    private Vector3 initialMonsterPos;
    //private float startTime;
    private float journeyLengthIfHit;
    private float journeyLengthIfMiss;
    private float distanceToPlayer;
    private float timer;
    [HideInInspector]
    public float timer2;
    Animator anim;



    void Start() {

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        monsterStopAfterMissPosition = GameObject.FindGameObjectWithTag("MonsterStopAfterMiss").transform;
        monsterStopAfterHitPosition = GameObject.FindGameObjectWithTag("MonsterStopAfterHit").transform;
        powerBar = GameObject.FindGameObjectWithTag("PowerBar").transform;
        sounds = GameObject.FindGameObjectWithTag("GameController").transform;
        playSoundsScript = sounds.GetComponent<PlaySounds>();
        playerPos = player.position;
        initialMonsterPos = transform.position;
        //finalPos = monsterStopPosition.position;
        //startTime = Time.time;
        journeyLengthIfHit = Vector3.Distance(initialMonsterPos, monsterStopAfterHitPosition.position);
        journeyLengthIfMiss = Vector3.Distance(initialMonsterPos, monsterStopAfterMissPosition.position);
        distanceToPlayer = Vector3.Distance(initialMonsterPos, playerPos);
        powerBarScript = powerBar.GetComponent <PowerBar>();
        percentageOfJourney = 0;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            start = true;
        }
        if (start) {
            timer2 += Time.deltaTime;
            float distCovered = (timer2) * (speed + (currentLevel * levelSpeedAlteration));
            float fracJourneyIfHit = distCovered / journeyLengthIfHit;
            float fracJourneyIfMiss = distCovered / journeyLengthIfMiss;

            // Percentage between where monster is, and total distance between
            // where the monster started and where the player is.
            percentageOfJourney = distCovered / distanceToPlayer;
            
            // playSoundsScript.playSounds();

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

            }
            else {
                // Monster will keep running off screen
                if (powerBarScript.powerBarColor == PowerBar.E_COLOR.GREEN)
                    anim.Play("MinoUn");
                transform.position = Vector3.Lerp(initialMonsterPos, monsterStopAfterMissPosition.position, fracJourneyIfMiss);

                if (transform.position.x == monsterStopAfterMissPosition.position.x) {
                    makeNewMonster = true;
                }
            }
        }
   }
}
