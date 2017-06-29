using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public Transform LoadingBar;
    Color Bar;
    [SerializeField] private float currentAmount;
    [SerializeField]private float speed;
    // Use this for initialization
    void Start () {
        Bar = LoadingBar.GetComponent<Image>().color;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            if (currentAmount > 90 && currentAmount < 100)
            {
                Bar.g = 255;
                Bar.r = 0;
                Bar.b = 0;
               
            }
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }
}
