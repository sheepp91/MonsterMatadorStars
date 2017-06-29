using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public Transform LoadingBar;
    public float greenStartRange = 30.0f;
    public float greenEndRange = 70.0f;
    public float greenSize = 10.0f;
    public float blueRange = 10.0f;


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
        }else{
            if (!pressed)
            {
                currentAmount = monsterMove.percentageOfJourney * 100;//speed * Time.deltaTime;
                LoadingBar.GetComponent<Image>().color = new Color(255, 0, 0, 255); // Red
            }
        }
    }

    void powerBarColour()
    {
        if (currentAmount < 100)
        {
            setUpTimer();
            if (currentAmount > greenStart && currentAmount < greenStart + greenSize)
            {
                LoadingBar.GetComponent<Image>().color = new Color32(0, 255, 0, 255); // Green
            } else if (currentAmount > greenStart - blueRange && currentAmount < greenStart + greenSize + blueRange)
            {
                LoadingBar.GetComponent<Image>().color = new Color32(0, 09, 255, 255); // Blue
            } else
            {
                LoadingBar.GetComponent<Image>().color = new Color(255, 0, 0, 255); // Red
            }
            //if (currentAmount > Perfect && currentAmount < (Perfect + 10))
            //{
            //    LoadingBar.GetComponent<Image>().color = new Color32(0, 255, 0, 255); // Green
            //}
            //if (currentAmount > 60 && currentAmount < Perfect)
            //{
            //    LoadingBar.GetComponent<Image>().color = new Color32(0, 09, 255, 255); // Blue
            //}
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

    void reset()
    {
        pressed = false;

    }
}
