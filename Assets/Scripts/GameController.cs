using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int currentLevel = 1;
    public PowerBar powerBar;
    public Transform monsterSpawnLocation;
    public GameObject defaultMonsterPrefab;

    private Transform currentMonster;
    private MonsterMove monsterMove;
    private Transform player;
    private PlayerHit playerHit;

    void Start () {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
        player = GameObject.FindWithTag("Player").transform;
        playerHit = player.GetComponent<PlayerHit>();
    }
	
	
	void Update () {
		if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene("Scene1");
        }
        if (monsterMove.makeNewMonster) {
            //monsterMove.makeNewMonster = false;
            Destroy(currentMonster.gameObject);
            currentMonster = (Instantiate(defaultMonsterPrefab, monsterSpawnLocation) as GameObject).transform;
            currentMonster.parent = null;
            monsterMove = currentMonster.GetComponent<MonsterMove>();
            powerBar.currentMonster = currentMonster;
            powerBar.monsterMove = monsterMove;
            playerHit.currentMonster = currentMonster;
            playerHit.monsterMove = monsterMove;
            powerBar.nextLevelReset();
        }
	}
}
