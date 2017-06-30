using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int score = 0;
    public PowerBar powerBar;
    //public Transform powerBarTransform;
    public Transform monsterSpawnLocation;
    public GameObject defaultMonsterPrefab;
    public RectTransform titles;
    public Text scoreText;

    private Transform currentMonster;
    private MonsterMove monsterMove;
    private Transform player;
    private PlayerHit playerHit;

    void Start () {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();
        player = GameObject.FindWithTag("Player").transform;
        playerHit = player.GetComponent<PlayerHit>();
        //powerBar = powerBarTransform.GetComponent<PowerBar>();
        monsterMove.currentLevel = score;
    }
	
	
	void Update () {
		if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene("Scene1");
        }
        if (monsterMove.makeNewMonster) {
            if (powerBar.powerBarColor == PowerBar.E_COLOR.GREEN) {
                score++;
            }
            Destroy(currentMonster.gameObject);
            currentMonster = (Instantiate(defaultMonsterPrefab, monsterSpawnLocation) as GameObject).transform;
            currentMonster.parent = null;
            monsterMove = currentMonster.GetComponent<MonsterMove>();
            monsterMove.currentLevel = score;
            monsterMove.start = true;
            powerBar.currentMonster = currentMonster;
            powerBar.monsterMove = monsterMove;
            playerHit.currentMonster = currentMonster;
            playerHit.monsterMove = monsterMove;
            powerBar.nextLevelReset();
            scoreText.text = "Score: " + score;
        }
        if (monsterMove.start && titles.anchoredPosition.y < 50000f) {
            Vector2 temp = titles.position;
            temp.y += 500f;
            titles.anchoredPosition += temp;
        }
	}
}
