using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public enum E_COLOR
    {
        RED = 0,
        BLUE,
        GREEN
    };

    public Transform LoadingBar;
    public float greenStartRange = 30.0f;
    public float greenEndRange = 70.0f;
    public float greenSize = 10.0f;
    public float blueRange = 10.0f;

    public E_COLOR powerBarColor = E_COLOR.RED;

    private float Perfect = 90;
    private MonsterMove monsterMove;
    private Transform currentMonster;

    private float greenStart;

    bool pressed = false;
    [SerializeField] private float currentAmount;
    [SerializeField]public float speed;
    
    

    void Start()
    {
        currentMonster = GameObject.FindWithTag("Monster").transform;
        monsterMove = currentMonster.GetComponent<MonsterMove>();

        greenStart = Random.Range(greenStartRange, greenEndRange);
    }
	void Update () {

        powerBarColour();
        
    }

    void setUpTimer()
    {
        if (Input.GetKeyDown("space")) {
            LoadingBar.GetComponent<Image>().fillAmount = currentAmount;
            pressed = true;

            if (currentAmount > greenStart && currentAmount < greenStart + greenSize) {
                powerBarColor = E_COLOR.GREEN;
                print("GREEN");
            } else if (currentAmount > greenStart - blueRange && currentAmount < greenStart + greenSize + blueRange) {
                powerBarColor = E_COLOR.BLUE;
                print("BLUE");
            } else {
                powerBarColor = E_COLOR.RED;
                print("RED");
            }
        }
        else{
            if (!pressed) {
                currentAmount = monsterMove.percentageOfJourney * 100;
            }
        }
    }

    void powerBarColour() {
        if (currentAmount < 100) {
            setUpTimer();
            if (currentAmount > greenStart && currentAmount < greenStart + greenSize) {
                LoadingBar.GetComponent<Image>().color = new Color32(0, 255, 0, 255); // Green
            } else if (currentAmount > greenStart - blueRange && currentAmount < greenStart + greenSize + blueRange) {
                LoadingBar.GetComponent<Image>().color = new Color32(0, 09, 255, 255); // Blue
            } else {
                LoadingBar.GetComponent<Image>().color = new Color(255, 0, 0, 255); // Red
            }
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

    void newLevelReset() {
        pressed = false;
        powerBarColor = E_COLOR.RED;
        greenStart = Random.Range(greenStartRange, greenEndRange);
        LoadingBar.GetComponent<Image>().fillAmount = 0.0f;
    }
}
