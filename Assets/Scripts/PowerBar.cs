using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    public Transform LoadingBar;
    int red, green, blue, alpha;
    float Perfect = 90;
    [SerializeField] private float currentAmount;
    [SerializeField]private float speed;
    
	void Update () {
		
        if (currentAmount < 100)
        {
            LoadingBar.GetComponent<Image>().color = new Color(255, 0, 0, 255);
            currentAmount += speed * Time.deltaTime;
             if (currentAmount > Perfect && currentAmount < (Perfect + 10))
             {
                LoadingBar.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
             }
             if (currentAmount > 60 && currentAmount < 90)
            {
               LoadingBar.GetComponent<Image>().color = new Color32(0, 09, 255, 255);
            }
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }
}
